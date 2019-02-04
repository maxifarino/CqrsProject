using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DomicilioController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetDomicilio")]
        public IHttpActionResult GetDomicilio([FromUri]DomicilioByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetDomicilioById")]
        public IHttpActionResult GetDomicilioById([FromUri]DomicilioByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioEditQueryResult>(query);
            return Ok(queryResult);
        }
    }
}
