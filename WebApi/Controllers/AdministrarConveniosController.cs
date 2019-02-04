using GAP.Cqrs.Implementation.Command.AdministrarConvenios;
using GAP.Cqrs.Implementation.CommandHandler.AdminisitrarConveniosPackage;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AdministrarConveniosController : ApiControllerBase
    {

        [HttpGet]
        public IHttpActionResult GetConveniosDeSalaCunaByFilter([FromUri]ConveniosDeSalaByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>(query);

            return Ok(queryResult);
        }


        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(ConveniosSaveCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }


        [HttpPost]
        [ActionName("Update")]
        public IHttpActionResult update(ConveniosUpdateCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IHttpActionResult Delete(ConveniosDeleteCommand command)
        {
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }
    }
}