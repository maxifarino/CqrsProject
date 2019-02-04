using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Usuario;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.CqrsCore.Querys;
using Microsoft.Owin.Security;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;
using WebApi.Models.Usuario;

namespace WebApi.App_Start.Security
{

    /// <summary>
    /// Actúa como interceptor de las peticiones rest.
    /// </summary>
    public class AuthorizationFilter : AuthorizationFilterAttribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        /// <summary>
        /// Se controla que el recurso solicitado (a tracés de un end-point) este permitido
        /// para el usuario actual autenticado.
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            ContextSingleton.InitBaseUrl();

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            // Para endpoints con atributo AllowAnonymous evitamos la autenticación.
 
            bool skipAuthorization =
                actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() ||
                actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (skipAuthorization)
            {
                return Task.FromResult<object>(null);
            }

            //Validación interna contra token.

            if (!principal.Identity.IsAuthenticated)
            {                
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            //Validación de control de cambio de usuario por fuera de la aplicación.

            var userCookie = HttpContext.Current.Request.Cookies["CiDi"];
            if (userCookie == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            //bool huboCambioDeUsuario = true;

            //UsuarioCidiDto usuarioCidi = UsuarioCidiFactory.ValidarUsuarioCidi();
            //if (usuarioCidi != null)
            //{
            //    LoguinCidiQuery query = new LoguinCidiQuery
            //    {
            //        Cuil = usuarioCidi.Cuil
            //    };

            //    QueryDispatcher _QueryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            //    LoguinCidiQueryResult queryResult = _QueryDispatcher.Dispatch<LoguinCidiQuery, LoguinCidiQueryResult>(query);

            //    if (queryResult.UsuarioDto != null && queryResult.UsuarioDto.Id != null)
            //    {

            //        if (queryResult.UsuarioDto.Cuil == usuarioCidi.Cuil)
            //        {
            //            huboCambioDeUsuario = false;                        
            //        }
            //    }
            //}

            //if(huboCambioDeUsuario)
            //{
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //Validación de autorización (verifica si el usuario tiene permisos contra URLs)

            if(GlobalVars.AuthenticationByRouteController)
            {
                string endPointAbsolutePath = actionContext.Request.RequestUri.AbsolutePath;
                int index = endPointAbsolutePath.ToLower().IndexOf("/api/");

                if (index != -1)
                {
                    // Verifico con el listado de end-points disponibles del usuario autenticado.
                    if(principal.Claims.Count() == 0)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                        //actionContext.Response.Headers.Add("X-Error", "gob-permiso-denegado");
                        return Task.FromResult<object>(null);
                    }
                    string usuario = principal.Claims.ToList()[1].ToString();
                    UsuarioCidiDto usuarioLogueado = JsonConvert.DeserializeObject<UsuarioCidiDto>(usuario.Substring(6));

                    string perfilId = "";
                    if (!FuncionalidadesSingleton.Instance.tienePermisos(usuarioLogueado.IdRol.ToString(), endPointAbsolutePath.Substring(4)))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                        //actionContext.Response.Headers.Add("X-Error", "gob-permiso-denegado");
                        return Task.FromResult<object>(null);
                    }
                }            
            }
            
            return Task.FromResult<object>(null);
        }
    }
}