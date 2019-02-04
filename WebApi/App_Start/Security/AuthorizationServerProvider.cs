using CiDi.SDK.Login.Service;
using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Usuario;
using GAP.Base.Helper;
using GAP.Cqrs.Implementation.Command.UsuarioPackage;
using GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities.Seguridad;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using WebApi.Controllers;
using WebApi.Models.Usuario;

namespace WebApi.App_Start.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        private IRefreshTokenFactory factory;

        public AuthorizationServerProvider()
        {
            if(GlobalVars.MockedMode)
                factory = RefreshTokenFactoryMocked.Instance; 
            else
                factory = new RefreshTokenFactory();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            Cliente cliente = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                //context.Validated();
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            cliente = factory.FindClient(context.ClientId);

            if (cliente == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }
            
            if (cliente.ApplicationType == ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (cliente.Secret != Helper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!cliente.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", cliente.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", cliente.RefreshTokenLifeTime.ToString());
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            try
            {
                bool registradoEnSalasCuna = false;
                bool logueadoEnCidi = false;

                UsuarioCidiDto usuarioCidi = UsuarioCidiFactory.ValidarUsuarioCidi();                

                if (usuarioCidi != null)
                {
                    logueadoEnCidi = true;
                    LoguinCidiQuery query = new LoguinCidiQuery
                    {
                        Cuil = usuarioCidi.Cuil
                    };

                    QueryDispatcher _QueryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
                    LoguinCidiQueryResult queryResult = _QueryDispatcher.Dispatch<LoguinCidiQuery, LoguinCidiQueryResult>(query);                    

                    if( queryResult.UsuarioDto != null && queryResult.UsuarioDto.Id != 0)
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                        queryResult.UsuarioDto.Apellido = usuarioCidi.Apellido;
                        queryResult.UsuarioDto.Nombre = usuarioCidi.Nombre;

                        Claim usuarioClimb = new Claim("User", new JavaScriptSerializer().Serialize(queryResult.UsuarioDto));
                        identity.AddClaim(new Claim(ClaimTypes.Name, usuarioCidi.Cuil.ToString()));
                        identity.AddClaim(usuarioClimb);
                        UrlCidiQueryResult urlsCidiResult = _QueryDispatcher.Dispatch<UrlCidiQuery, UrlCidiQueryResult>(null);     

                        //**//                        

                        IDictionary<string, string> data = new Dictionary<string, string>
                        {
                             //{ "Paginas", JsonConvert.SerializeObject(queryResult.FuncionalidadesDto) },
                             { "User", JsonConvert.SerializeObject(queryResult.UsuarioDto) },
                             { "UrlCidi", urlsCidiResult.UrlCidi },
                             { "UrlCerrarSesionCidi", urlsCidiResult.UrlCidiLogout },
                             { "UrlInicarSesionCidi", urlsCidiResult.UrlCidiLogin },
                             { "as:client_id", context.ClientId == null ? string.Empty : context.ClientId }
                        };
                        AuthenticationProperties properties = new AuthenticationProperties(data);

                        Microsoft.Owin.Security.AuthenticationTicket ticket = new Microsoft.Owin.Security.AuthenticationTicket(identity, properties);

                        context.Validated(ticket);
                        
                        registradoEnSalasCuna = true;
                    }
                }

                if (!logueadoEnCidi)
                {
                    //El usuario no está logueado a través de CIDI.
                    context.SetError("NO_AUTENTICADO_EN_CIDI", "");
                    context.Response.ReasonPhrase = "NO_AUTENTICADO_EN_CIDI";
                }
                else if (!registradoEnSalasCuna)
                {
                    //El usuario está logueado a través CIDI pero no se encuentra registrado en Salas Cuna.
                    context.SetError("NO_REGISTRADO_EN_SALAS_CUNA", "");
                    //context.
                    context.Response.ReasonPhrase = "NO_REGISTRADO_EN_SALAS_CUNA";               
                }
            }
            catch (Exception e)
            {
                context.SetError("Server error", e.StackTrace);
                context.Rejected();
            }
        }
        

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }


        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;
            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }
 
            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            //newId.AddClaim(new Claim("newClaim", "refreshToken"));

            //var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            //string usuario = principal.Claims.ToList()[1].ToString();
            // TODO Alvaro Actualizar funcionalidades
            /* string perfilId = "";
            foreach (RolDto role in queryResult.UsuarioDto.Roles)
                perfilId += role.Id;

            FuncionalidadesSingleton.Instance.replaceFuncionalidades(perfilId, queryResult.FuncionalidadesDto);*/


            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

    }
}