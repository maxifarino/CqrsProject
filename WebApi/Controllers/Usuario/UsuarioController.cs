using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Cqrs.Implementation.Command.UsuarioPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApi.Models.Usuario;
using GAP.Cqrs.Implementation.Query.RolQuery;
using GAP.Cqrs.Implementation.QueryResult.Rol;
using System.Web;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using CiDi.SDK.Login.Service;
using GAP.Base.Dto;
using WebApi.App_Start.Security;
using GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage;

namespace WebApi.Controllers
{

    public class UsuarioController : ApiControllerBase
    {

        [HttpGet]
        [ActionName("ObtenerUsuarioActivo")]
        [AllowAnonymous]
        public IHttpActionResult ObtenerUsuarioActivo()
        {
            
            ObtenerUsuarioActivoResult queryResult = new ObtenerUsuarioActivoResult();

            //Verifico usuario logueado a través de CIDI.

            var cookie = HttpContext.Current.Request.Cookies["CiDi"];

            if (cookie != null)
            {
                ObtenerUsuarioActivoQuery query = new ObtenerUsuarioActivoQuery();
                query.Hash = cookie.Value.ToString();
                queryResult = _queryDispatcher.Dispatch<ObtenerUsuarioActivoQuery, ObtenerUsuarioActivoResult>(query);
                queryResult.Hash = cookie.Value.ToString();
            }
            //Si el usuario no está logueado a través de CIDI el objeto a devolver estará vacio.

            return Ok(queryResult);
        }

        [HttpGet]
        public IHttpActionResult GetUsuarioByFilter([FromUri]UsuariosByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<UsuariosByFiltersQuery, UsuariosByFiltersQueryResult>(query);

            return Ok(queryResult);
        }


        [HttpGet]
        [ActionName("ObtenerHash")]
        [AllowAnonymous]
        public IHttpActionResult ObtenerHash()
        {

            ObtenerUsuarioActivoResult queryResult = new ObtenerUsuarioActivoResult();

            //Verifico usuario logueado a través de CIDI.

            var cookie = HttpContext.Current.Request.Cookies["CiDi"];
            
            if (cookie != null)
            {
                queryResult.Hash = cookie.Value.ToString();
            }
            //Si el usuario no está logueado a través de CIDI el objeto a devolver estará vacio.

            return Ok(queryResult);
        }
        


        [HttpGet]
        [ActionName("CerrarSesionCidi")]
        [AllowAnonymous]
        public IHttpActionResult CerrarSesionCidi()
        {
            CiDiLoginService.CerrarSesion();
            return Ok();
        }

        [HttpGet]
        [ActionName("ObtenerUrlsCidi")]
        [AllowAnonymous]
        public IHttpActionResult ObtenerUrlsCidi()
        {
            UrlCidiQueryResult urlsCidiResult = _queryDispatcher.Dispatch<UrlCidiQuery, UrlCidiQueryResult>(null);
            return Ok(urlsCidiResult);
        }

        //TODO Añadir permiso a BD. Quitar AlowAnonymous
        [HttpGet]
        [ActionName("ObtenerPermisos")]
        [AllowAnonymous]
        public IHttpActionResult ObtenerPermisos()
        {
            Usuario usuario = GetUsuarioLogueado();
            if(usuario == null)
                return Ok();

            LoguinCidiQuery query = new LoguinCidiQuery
            {
                Cuil = usuario.Cuil.ToString()
            };
            LoguinCidiQueryResult queryResult = _queryDispatcher.Dispatch<LoguinCidiQuery, LoguinCidiQueryResult>(query);

            string perfilId = "";
            FuncionalidadesSingleton.Instance.replaceFuncionalidades(queryResult.UsuarioDto.IdRol.ToString(), queryResult.FuncionalidadesDto);
            return Ok(queryResult);            
        }



        [HttpGet]
        public IHttpActionResult SelectRol()
        {
            
            //busco las funcionalidades por rol   

            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            String[] result = {"sfsa", "asdsad"};

            //var usuarioModel = GetUsuarioLogueado();

            //var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            //recupero el Usuario del identity
            //agrego al usuario las funcionalidades encontradas
            //agrego nuevamente el usuario al identity
            //devuelvo el usuario en el resultado
                      
            return Ok();
        }


        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(UsuarioSaveCommand command)
        {
            command.usuario.Id = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }
        [HttpPost]
        [ActionName("Editar")]
        public IHttpActionResult Editar(UsuarioUpdateCommand command)
        {
            command.usuario.Id = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }

        [HttpGet]
        [ActionName("GetAllRolesUsuarioById")]
        public IHttpActionResult GetAllRolesUsuarioById([FromUri]RolByIdQuery query)
        {

            query.IdUsuarioLogueado = GetUsuarioLogueado().Id;
            var queryResult = _queryDispatcher.Dispatch<RolByIdQuery, RolByIdQueryResults>(query);
            return Ok(queryResult);
        }
        [HttpGet]
        [ActionName("GetUsuarioById")]
        public IHttpActionResult GetUsuarioById([FromUri]ObtenerUsuarioByIdQuery query)
        {

            var queryResult = _queryDispatcher.Dispatch<ObtenerUsuarioByIdQuery, ObtenerUsuarioByIdResult>(query);
            return Ok(queryResult);
        }



        [HttpGet]
        [ActionName("GetRolesAsignaUsuarioById")]
        public IHttpActionResult GetRolesAsignaUsuarioById([FromUri]RolAsignaByIdQuery query)
        {

            query.IdUsuario = GetUsuarioLogueado().Id;
            var queryResult = _queryDispatcher.Dispatch<RolAsignaByIdQuery, RolAsignaByIdQueryResult>(query);
            return Ok(queryResult);
        }
        [HttpPost]
        [ActionName("Eliminar")]
        public IHttpActionResult Eliminar(UsuarioDeleteCommand command)
        {
            command.usuario.Id = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }
    }
}
