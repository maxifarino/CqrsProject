using GAP.Cqrs.Implementation.Query.SucursalQuery;
using GAP.Cqrs.Implementation.QueryResult.SucursalQueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class SucursalController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetSucursalesByIdEntidadBancaria")]
        public IHttpActionResult GetSucursalesByIdEntidadBancaria([FromUri] SucursalByEntidadBancariaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SucursalByEntidadBancariaQuery, SucursalByEntidadBancariaQueryResult>(query);

            return Ok(queryResult);
        }
    }
}
