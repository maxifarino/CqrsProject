
using GAP.Cqrs.Implementation.Query.PersonaFisicaQuery;
using GAP.Cqrs.Implementation.Query.PersonQuery;
using GAP.Cqrs.Implementation.QueryResult.PersonaFisicaResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PersonaFisicaController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetPersonaFisicaByFilter")]
        public IHttpActionResult PersonaFisicaByFilter([FromUri]PersonaFisicaByFilterQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonaFisicaByFilterQuery, PersonaFisicaQueryResult>(query);

            return Ok(queryResult);
        }
        [HttpGet]
        [ActionName("GetPersonaByCuit")]
        public IHttpActionResult GetPersonaByCuit([FromUri]PersonaByCuitQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonaByCuitQuery, PersonaByCuitQueryResult>(query);
            return Ok(queryResult);
        }
    }
}

