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

namespace WebApi.Controllers
{
    public class FormaJuridicaController : ApiControllerBase
    {
       [HttpGet]
       [ActionName("getFormaJuridica")]
        public IHttpActionResult GetFormaJuridica()
        {
            var queryResult = _queryDispatcher.Dispatch<FormaJuridicaByFiltersQuery, FormaJuridicaByFiltersQueryResults>(null);
            return Ok(queryResult);
        }
      
    }
}