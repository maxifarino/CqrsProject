using GAP.Base;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.BeneficiarioPackage;
using GAP.Cqrs.Implementation.Command.EntidadPersonaJuridica;
using GAP.Cqrs.Implementation.CommandHandler.BeneficiarioPackage;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.Cqrs.Implementation.Query.TipoDocumentoQuery;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.Cqrs.Implementation.QueryResult.Beneficiario;
using GAP.Cqrs.Implementation.QueryResult.EntidadQuery;
using GAP.Cqrs.Implementation.QueryResult.TipoDocumentoResult;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace WebApi.Controllers
{
    public class BeneficiarioController : ApiControllerBase
    {
        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(BeneficiarioSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("Editar")]
        public IHttpActionResult Editar(BeneficiarioUpdateCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }


        [HttpGet]
        [ActionName("GetBeneficiariosBySalita")]
        public IHttpActionResult GetBeneficiariosBySalita([FromUri]BeneficiarioByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioByFiltersQuery, BeneficiarioByFiltersQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetBeneficiariosBySala")]
        public IHttpActionResult GetBeneficiariosBySalita([FromUri]BeneficiarioBySalaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioBySalaQuery, BeneficiarioBySalaQueryResult>(query);
            return Ok(queryResult);
        }



        [HttpGet]
        [ActionName("GetTipoDocumento")]
        public IHttpActionResult GetTipoDocumento([FromUri]TipoDocumentoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<TipoDocumentoQuery, TipoDocumentoQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetTipoDocumentoGen")]
        public IHttpActionResult GetTipoDocumentoGen([FromUri]TipoDocumentoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<TipoDocumentoQuery, TipoDocumentoRegQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetLugarOrigen")]
        public IHttpActionResult GetLugarOrigen([FromUri]LugarDeOrigenQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<LugarDeOrigenQuery, LugarDeOrigenQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("ObtenerCaracteristicaBeneficiario")]
        public IHttpActionResult ObtenerCaracteristicaBeneficiario(BeneficiarioCaracteristicaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioCaracteristicaQuery, BeneficiarioCaracteristicaQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("ObtenerCaracteristicaBeneficiarioTutor")]
        public IHttpActionResult ObtenerCaracteristicaBeneficiarioTutor(TutorCaracteristicaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<TutorCaracteristicaQuery, TutorCaracteristicaQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerDatosBeneficiarioYTutor")]
        public IHttpActionResult ObtenerDatosBeneficiarioYTutor([FromUri]BeneficiarioYTutorCaracteristicasQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioYTutorCaracteristicasQuery, BeneficiarioYTutorCaracteristicasQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerBeneficiarioYTutor")]
        public IHttpActionResult ObtenerBeneficiarioYTutor([FromUri]BeneficiarioByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioByFiltersQuery, BeneficiarioTutorByFiltersQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpGet]
        [ActionName("VerBeneficiarioYTutor")]
        public IHttpActionResult ObtenerBeneficiarioYTutor([FromUri]BeneficiarioVerQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioVerQuery, BeneficiarioVerQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("VerificarExistenciaBeneficiario")]
        public IHttpActionResult VerificarExistenciaBeneficiario(BeneficiarioCaracteristicaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioCaracteristicaQuery, BeneficiarioExistenciaQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpPost]
        [ActionName("VerificarExistenciaBeneficiarioMod")]
        public IHttpActionResult VerificarExistenciaBeneficiario(BeneficiarioCaracteristicaModQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<BeneficiarioCaracteristicaModQuery, BeneficiarioExistenciaModQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("AsignarBeneficiario")]
        public IHttpActionResult AsignarBeneficiario(AsignarBeneficiarioCommand command)
        {
            command.UsuarioId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("BajaBeneficiario")]
        public IHttpActionResult BajaBeneficiario(BajaBeneficiarioCommand command)
        {
            command.UsuarioId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("ObtenerReporteBeneficiario")]
        public IHttpActionResult ObtenerReporteBeneficiario()
        {
            BeneficiarioReporteQuery query = new BeneficiarioReporteQuery();

            BeneficiarioReporteQueryResult queryResult = _queryDispatcher.Dispatch<BeneficiarioReporteQuery, BeneficiarioReporteQueryResult>(query);
            
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerCantidadBeneficiarios")]
        public IHttpActionResult ObtenerCantidadBeneficiarios()
        {
            CantidadBeneficiariosQuery query = new CantidadBeneficiariosQuery();
            var queryResult = _queryDispatcher.Dispatch<CantidadBeneficiariosQuery, CantidadBeneficiariosQueryResult>(query);
            return Ok(queryResult);
        }
    }
}