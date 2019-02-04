using GAP.Cqrs.Implementation.Command;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.PersonQuery;
using GAP.Cqrs.Implementation.QueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PersonController : ApiControllerBase
    {

        /*[HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult Get()
        {
            var queryResult = _queryDispatcher.Dispatch<PersonByNameLastNameQuery, PersonByNameLastNameQueryResult>(new PersonByNameLastNameQuery() { Name = "maxi" });
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(PersonByNameLastNameQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<PersonByNameLastNameQuery, PersonByNameLastNameQueryResult>(query);
            
            return Ok(queryResult);
        }

        [HttpPost]
        public IHttpActionResult Post(PersonSaveCommand command)
        {
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }


        [HttpPost]
        public IHttpActionResult Put(PersonUpdateCommand command)
        {
            _result = _commandDispatcher.Dispatch(command);

            return Ok(_result);
        }


        /// <summary>
        /// With this form, we could create a method custom for a http request
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet()]
        [ActionName("PersonByName")]
        public IHttpActionResult GetPersonByName(PersonByNameLastNameQuery query)
        {
            return Ok();
        }*/

        [Authorize]
        [HttpGet()]
        [Route("api/TestToken")]
        public IHttpActionResult TestToken()
        {
            return Ok("autentificado por mi token");
        }

        [HttpGet]
        public String GetHola()
        {
            return "Hola webpack";
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
