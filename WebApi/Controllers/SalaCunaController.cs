using System;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.Cqrs.Implementation.Command.SalaCunaPackage;
using GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.Cqrs.Implementation.QueryResult.Beneficiario;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage;
using GAP.Cqrs.Implementation.Query.CursoQuery;


namespace WebApi.Controllers
{
    public class SalaCunaController : ApiControllerBase
    {
        [HttpGet]
        public IHttpActionResult GetSalasCunaByFilter([FromUri]SalasCunaByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalasCunaByFiltersQuery, SalasCunaByFiltersQueryResults >(query);

            return Ok(queryResult);
        }

        [HttpGet]
        public IHttpActionResult GetSalasCunaByFilterCurso([FromUri]SalasCunaByFiltersCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalasCunaByFiltersCursoQuery, SalasCunaByFiltersCursoQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerAsistenciaPersonal")]
        public IHttpActionResult ObtenerAsistenciaPersonal([FromUri]AsistenciaPersonalCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<AsistenciaPersonalCursoQuery, AsistenciaPersonalCursoQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult Create(SalaCunaSaveCommand command) 
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpPost]
        [ActionName("AltaDefinitiva")]
        public IHttpActionResult DarDeAltaDefinitiva(SalaCunaSaveDefinitiveCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }

        [HttpGet]
        [ActionName("GetById")]
        public IHttpActionResult GetById([FromUri]SalasCunaBandejaByIdQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalasCunaBandejaByIdQuery, SalasCunaBandejaByIdQueryResults>(query);
            return Ok(queryResult);
        }

        #region Eliminar sala cuna
        [HttpGet]
        [ActionName("TieneBeneficiariosActivos")]
        public IHttpActionResult TieneBeneficiariosActivos([FromUri]SalaCunaTieneBeneficiariosQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalaCunaTieneBeneficiariosQuery, SalaCunaTieneBeneficiariosQueryResult>(query);
            return Ok(queryResult);
        }
        [HttpPost]
        [ActionName("EliminarSalaCuna")]
        public IHttpActionResult EliminarSalaCuna(SalaCunaDeleteCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }
        #endregion

        #region Modificar sala cuna
        [HttpPost]
        [ActionName("ModificarSalaCuna")]
        public IHttpActionResult ModificarSalaCuna(SalaCunaUpdateCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }
        #endregion

        //Metodo utilizado en Ver/Eliminar/Modificar sala cuna, 
        //para cargar todos sus datos y mostrarlos.
        [HttpGet]
        [ActionName("GetDetalleSalaCuna")]
        public IHttpActionResult GetDetalleSalaCuna([FromUri]SalaCunaDetalleQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalaCunaDetalleQuery, SalaCunaDetalleQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("InitAdministrarBeneficiario")]
        public IHttpActionResult InitAdministrarBeneficiario([FromUri]DatosAdminBeneficiarioQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<DatosAdminBeneficiarioQuery, DatosAdminBeneficiarioQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("ObtenerReporteSalasCuna")]
        public IHttpActionResult ObtenerReporteSalasCuna()
        {
            SalaCunaReporteQuery query = new SalaCunaReporteQuery();

            SalaCunaReporteQueryResult queryResult = _queryDispatcher.Dispatch<SalaCunaReporteQuery, SalaCunaReporteQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetSalasCunaByEntidad")]
        public IHttpActionResult GetSalasCunaByEntidad([FromUri]SalaCunaByEntidadQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalaCunaByEntidadQuery, SalaCunaByEntidadQueryResult>(query);

            return Ok(queryResult);
        }

        [HttpPost]
        [ActionName("InaugurarSala")]
        public IHttpActionResult InaugurarSala(SalaCunaInaugurarCommand command)
        {
            command.idUsuarioLogueado = GetUsuarioLogueado().Id;
            _result = _commandDispatcher.Dispatch(command);
            return Ok(_result);
        }
        [HttpGet]
        [ActionName("GetCantidadBeneficiarios")]
        public IHttpActionResult GetCantidadBeneficiarios([FromUri]CantidadBeneficiariosPorSalaQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<CantidadBeneficiariosPorSalaQuery, CantidadBeneficiariosPorSalaQueryResult>(query);
            return Ok(queryResult);
        }

    }
}
