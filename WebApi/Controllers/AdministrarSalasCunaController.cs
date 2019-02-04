using GAP.Cqrs.Implementation.Query.AdministrarSalaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.AdministrarSalasCunaQueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AdministrarSalasCunaController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetTableroControl")]
        public IHttpActionResult GetDatosAdministrarSalaCunaByFilter([FromUri]AdministrarSalasCunaByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<AdministrarSalasCunaByFiltersQuery, AdministrarSalasCunaByFiltersQueryResult>(query);

            return Ok(queryResult);
        }
    }
}