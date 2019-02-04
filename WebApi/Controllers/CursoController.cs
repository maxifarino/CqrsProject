using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Helper;
using GAP.Cqrs.Implementation.CommandHandler.CursoPackage;
using GAP.Cqrs.Implementation.Query.Clase;
using GAP.Cqrs.Implementation.Query.Curso;
using GAP.Cqrs.Implementation.Query.CursoQuery;
using GAP.Cqrs.Implementation.Query.Personal;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CursoController : ApiControllerBase
    {

        [HttpPost]
        [ActionName("RegistrarCurso")]
        public IHttpActionResult RegistrarCurso(CursoSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("EditarCurso")]
        public IHttpActionResult EditarCurso(CursoUpdateCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("RegistrarInscripcion")]
        public IHttpActionResult Create(InscripcionCursoCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        public IHttpActionResult GetCursoByFilter([FromUri]CursoByFiltersCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<CursoByFiltersCursoQuery, CursoByFiltersCursoQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("RegistrarAsistencia")]
        public IHttpActionResult Create(RegistrarAsistenciaCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("ObtenerInscriptoByFilter")]
        public IHttpActionResult ObtenerInscriptoByFilter([FromUri]PersonalInscriptoByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalInscriptoByFilterQuery, PersonalInscriptoByFilterQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("VerificarCantidadInscriptosDeBaja")]
        public IHttpActionResult VerificarCantidadInscriptosDeBaja([FromUri]CursoInscriptosBajaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<CursoInscriptosBajaQuery, CursoInscriptosBajaQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerCursoById")]
        public IHttpActionResult ObtenerInscriptoByFilter([FromUri]CursoByIdQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<CursoByIdQuery, CursoByIdQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerPersonalAsistioByClase")]
        public IHttpActionResult ObtenerPersonalAsistioByClase([FromUri]PersonalInscriptoByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalInscriptoByFilterQuery, PersonalAsistioByClaseQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerClasesByCurso")]
        public IHttpActionResult ObtenerClasesByCurso([FromUri]ClaseByCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<ClaseByCursoQuery, ClaseByCursoQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpPost]
        [ActionName("EliminarInscripcion")]
        public IHttpActionResult QuitarIntegrante(InscripcionDeleteCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("ObtenerPersonalInscriptoByCurso")]
        public IHttpActionResult ObtenerPersonalInscriptoByCurso([FromUri]PersonalByCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonalByCursoQuery, PersonalByCursoQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("DarBajaCurso")]
        public IHttpActionResult DarBajaPersonal(CursoBajaCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("ValidacionEliminarCurso")]
        public IHttpActionResult ValidacionEliminarCurso([FromUri]CursoValidacionBajaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<CursoValidacionBajaQuery, CursoValidacionBajaQueryResult>(query);
            return Ok(queryResult);
        }
    }
}