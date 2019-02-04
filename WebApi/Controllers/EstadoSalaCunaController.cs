using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.Query.EstadoSalaCunaQuery;
using GAP.Cqrs.Implementation.QueryHandler.FormaJuridicaQueryHandler;
using GAP.Cqrs.Implementation.QueryResult.EstadoSalaCunaQueryResult;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;

namespace WebApi.Controllers
{
    public class EstadoSalaCunaController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetEstadoSalaCuna")]
        public IHttpActionResult GetEstadoSalaCuna()
        {
            var queryResult = _queryDispatcher.Dispatch<EstadoSalaCunaByFiltersQuery, EstadoSalaCunaByFiltersQueryResults>(null);
            return Ok(queryResult);
        }
    }
}
