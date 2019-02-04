using System;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Cqrs.Implementation.Command.AdministrarRequisitos;


namespace WebApi.Controllers
{
    public class AdministrarRequisitosController : ApiControllerBase
    {

        [HttpPost]
        public IHttpActionResult GetRequisitosDeSalaCunaByFilter(RequisitosDeSalaByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<RequisitosDeSalaByFiltersQuery, RequisitosDeSalaCunaQueryResult>(query);

          return Ok(queryResult);
        }


        [HttpPost]
        [ActionName("Update")]
        public IHttpActionResult Update(RequisitosSaveCommand command)
        {
            _result = _commandDispatcher.Dispatch(command);
            
            return Ok(_result);
        }


    }
}