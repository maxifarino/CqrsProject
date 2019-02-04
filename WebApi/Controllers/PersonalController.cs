using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.Command;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult.PersonalQueryResult;
using GAP.Base;
using GAP.Cqrs.Implementation.CommandHandler.PersonalPackage;
using GAP.Cqrs.Implementation.Query.Personal;
using GAP.Cqrs.Implementation.Query.PersonQuery;


namespace WebApi.Controllers
{
    public class PersonalController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetPersonalByFilter")]
        public IHttpActionResult GetPersonalByFilter([FromUri]PersonalByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalByFiltersQuery, PersonalByFiltersQueryResults>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetDomicilioPersona")]
        public IHttpActionResult GetDomicilioPersona([FromUri]PersonalDomicilioQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalDomicilioQuery, PersonalDomicilioQueryResult>(query);

            return Ok(queryResult);
        }


        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult RegistrarPersonal(PersonalSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("Editar")]
        public IHttpActionResult EditarPersonal(PersonalEditCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }


        [HttpPost]
        [ActionName("DarBajaPersonal")]
        public IHttpActionResult DarBajaPersonal(PersonalBajaCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("ObtenerDatosPersonal")]
        public IHttpActionResult ObtenerDatosPersonal([FromUri]PersonalVerQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalVerQuery, PersonalVerQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerDatosModificarPersonal")]
        public IHttpActionResult ObtenerDatosModificarPersonal([FromUri]PersonalEditQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalEditQuery, PersonalEditQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetAsistenciaPersonalByFilter")]
        public IHttpActionResult GetAsistenciaPersonalCertificados([FromUri]AsistenciaPersonalByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<AsistenciaPersonalByFilterQuery, AsistenciaPersonalByFilterQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("VerificarPersonalAsignadoACurso")]
        public IHttpActionResult VerificarPersonalAsignadoACurso([FromUri]PersonalVerQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalVerQuery, PersonalAsignadoACursoQueryResult>(query);

            return Ok(queryResult);
        }
    }
}
