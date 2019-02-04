using System;
using GAP.Cqrs.Implementation.QueryResult.SalitaCunaQueryResult;
using GAP.Cqrs.Implementation.Query.SalitaCunaQuery;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.Command.SalitaCunaPackage;
using GAP.Cqrs.Implementation.CommandHandler.SalitaCunaPackage;



namespace WebApi.Controllers
{
    public class SalitaCunaController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetSalitasByFilter")]
        public IHttpActionResult GetSalitas([FromUri] SalitaCunaByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalitaCunaByFiltersQuery, SalitaCunaByFiltersQueryResults>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(SalitaCunaSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IHttpActionResult Delete(SalitaCunaDeleteCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
            
        }
        [HttpPost]
        [ActionName("Update")]
        public IHttpActionResult Update(SalitaCunaUpdateCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("GetGrupoEtario")]
        public IHttpActionResult GetGrupoEtario([FromUri] GrupoEtarioByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<GrupoEtarioByFiltersQuery, GrupoEtarioByFiltersQueryResults>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetSalitasSinSegundoAnillo")]
        public IHttpActionResult GetSalitasSinSegundoAnillo([FromUri] SalitaCunaAdminBenTurnoQuery query)
        {
            query.IncluirSegundoAnillo = "N";
            var queryResult = _queryDispatcher.Dispatch<SalitaCunaAdminBenTurnoQuery, SalitaCunaAdminBenTurnoQueryResult>(query);
            return Ok(queryResult);
        }

    }
}