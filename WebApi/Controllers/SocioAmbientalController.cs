using GAP.Base;
using GAP.Cqrs.Implementation.CommandHandler.Administrar_Socio_Ambiental;
using GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



namespace WebApi.Controllers
{
    public class SocioAmbientalController: ApiControllerBase
    {
        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(SocioAmbientalSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
           _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("GetSocioAmbientalById")]
        public IHttpActionResult GetBeneficiarioSAById([FromUri]VerSocioAmbientalByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<VerSocioAmbientalByFiltersQuery, AdministrarSocioAmbientalByFiltersQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetTipoSocioAmbiental")]
        public IHttpActionResult GetTipoSocioAmbiental()
        {
            var queryResult = _queryDispatcher.Dispatch<VerTipoSocioAmbientalQuery, VerTipoSocioAmbientalQueryResults>(null);
            return Ok(queryResult);
        }

    }
}