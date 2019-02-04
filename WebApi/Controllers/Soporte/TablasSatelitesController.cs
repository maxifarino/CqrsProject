using GAP.Cqrs.Implementation.Query.TablaSatelitesQuery;
using GAP.Cqrs.Implementation.QueryResult.TablaSateliteCaracteristicaQueryResult;
using GAP.Cqrs.Implementation.QueryResult.TablasSatelitesQueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.Soporte
{
    public class TablasSatelitesController : ApiControllerBase
    {

        [HttpGet]
        [ActionName("GetTablaSatelites")]
        public IHttpActionResult GetTablaSatelites([FromUri]TablaSatelitesGenericClassQuery query)
        {
            var result = _queryDispatcher.Dispatch<TablaSatelitesGenericClassQuery, TablaSatelitesGenericClassQueryResult>(query);
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetTablaSatelitesCaracteristica")]
        public IHttpActionResult GetTablaSatelitesCaracteristica([FromUri]TablaSatelitesGenericClassQuery query)
        {
            var result = _queryDispatcher.Dispatch<TablaSatelitesGenericClassQuery, TablaSateliteCaracteristicaGenericClassQueryResult>(query);
            return Ok(result);
        }

    }
}
