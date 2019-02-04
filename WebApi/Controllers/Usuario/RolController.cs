using GAP.Cqrs.Implementation.Command.EntidadPersonaJuridica;
using System;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.Query.FormaJuridica;
using GAP.Cqrs.Implementation.QueryHandler.FormaJuridicaQueryHandler;
using GAP.Cqrs.Implementation.QueryResult.FormaJuridicaQueryResult;
using GAP.Cqrs.Implementation.Query.RolQuery;
using GAP.Cqrs.Implementation.QueryResult.Rol;

namespace WebApi.Controllers
{
    public class RolController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult GetAll()
        {
            var queryResult = _queryDispatcher.Dispatch<RolByFiltersQuery, RolByFiltersQueryResults>(null);
            return Ok(queryResult);
        }
    }
}