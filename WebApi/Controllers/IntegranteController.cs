using System.Web.Http;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.Base;
using GAP.Cqrs.Implementation.CommandHandler.GrupoFamiliarPackage;

namespace WebApi.Controllers
{
    public class IntegranteController : ApiControllerBase
    {

        [HttpGet]
        [ActionName("GetVinculos")]
        public IHttpActionResult GetVinculos([FromUri]VinculoIntegranteQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<VinculoIntegranteQuery, VinculoIntegranteQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpGet]
        [ActionName("GetIntegrantes")]
        public IHttpActionResult GetIntegrantes([FromUri]IntegranteQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<IntegranteQuery, IntegranteQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetGrupoConviviente")]
        public IHttpActionResult GetGrupoConviviente([FromUri]IntegranteQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<IntegranteQuery, GrupoConvivienteQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("RegistrarIntegrante")]
        public IHttpActionResult RegistrarIntegrante(IntegranteSaveCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("QuitarIntegrante")]
        public IHttpActionResult QuitarIntegrante(IntegranteDeleteCommand command)
        {
            command.UsuarioLogueadoId = GetUsuarioLogueado().Id;
            command.ProgramaAplicacionId = GlobalVars.IdApplication;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("GetIntegrantesByTutor")]
        public IHttpActionResult GetIntegrantesByTutor(TutorCaracteristicaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<TutorCaracteristicaQuery, IntegranteQueryResult>(query);
            return Ok(queryResult);
        }


    }
}
