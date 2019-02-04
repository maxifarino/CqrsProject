using GAP.Cqrs.Implementation.Command.EntidadPersonaJuridica;
using System;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.QueryResult.EntidadQuery;
using GAP.Base.ResultValidation;
using CiDi.SDK.Common;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using GAP.Base;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using System.Web;

namespace WebApi.Controllers
{
    public class EntidadController : ApiControllerBase
    {
        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(EntidadSaveCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("GetVerEntidadByFilter")]
        public IHttpActionResult GetVerEntidadByFilter([FromUri]VerEntidadByFiltersQuery query)
        {
            query.idUsuarioLogueado = GetUsuarioLogueado().Id;
            var queryResult = _queryDispatcher.Dispatch<VerEntidadByFiltersQuery, VerEntidadByFiltersQueryResult>(query);          
            return Ok(queryResult);
        }
        


        [HttpGet]
        [ActionName("GetEntidadByFilter")]
        public IHttpActionResult GetEntidadByFilter([FromUri]EntidadByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<EntidadByFiltersQuery, EntidadByFiltersQueryResult>(query);                        
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult GetAll()
        {
            GetAllEntidadQuery query = new GetAllEntidadQuery();
            var queryResult = _queryDispatcher.Dispatch<GetAllEntidadQuery, GetAllEntidadQueryResult>(query);
            return Ok(queryResult);
        }
    }
}
