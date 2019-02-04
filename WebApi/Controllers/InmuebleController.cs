using GAP.Cqrs.Implementation.Command.InmueblePackage;
using GAP.Cqrs.Implementation.CommandHandler.InmueblePackage;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class InmuebleController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetInmueblesByFilters")]
        public IHttpActionResult GetInmueblesByFilters([FromUri]InmuebleByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<InmuebleByFiltersQuery, InmuebleByFiltersQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(InmuebleSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("Update")]
        public IHttpActionResult Create(InmuebleUpdateCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IHttpActionResult Delete(InmuebleDeleteCommand command)
        {
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }
    }
}