using GAP.Base.Dto;
using GAP.Base.Dto.AdministrarConvenios;
using GAP.Base.Dto.AdministrarRequisitos;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Dto.ProvisionProductos;
using GAP.Base.Dto.SalasCuna;
using GAP.Base.Helper;
using GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.Cqrs.Implementation.Query.ProductoPorFamiliaQuery;
using GAP.Cqrs.Implementation.Query.ProductoPorSalaQuery;
using GAP.Cqrs.Implementation.Query.ProvisionProductosQuery;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using WebApi.Controllers.Soporte;
using WebApi.Reports.DataSet;
using GAP.Cqrs.Implementation.Query.PersonalPorSalaQuery;
using GAP.Cqrs.Implementation.Query.CursoQuery;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Cqrs.Implementation.Query.Personal;
using GAP.Cqrs.Implementation.Query.Clase;
using GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental;
using System.Globalization;
using GAP.Cqrs.Implementation.Query.InfoGlobal;
using GAP.Cqrs.Implementation.Query.ProvisionProductosCEQuery;
using GAP.Cqrs.Implementation.Query.MadresBeneficiariosQuery;
using GAP.Base;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using WebApi.Models.Usuario;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GAP.Cqrs.Implementation.CommandHandler.ReportePackage;
using GAP.Base.Enumerations;
using GAP.Base.Reportes;
using GAP.Base.Dto.Reportes;


namespace WebApi.Controllers
{
    public class ReporteController : ReporteControllerBase
    {

        public const string _mensaje = "Cuando el reporte esté listo se enviará un link para descargarlo al siguiente email: ";

        #region Beneficiarios

        [HttpGet]
        [ActionName("GenerarReporteBeneficiarios")]
        public IHttpActionResult GenerarReporteBeneficiarios([FromUri]BeneficiarioReporteQuery query)
        {

            if (query.SalaCunaId != null || !String.IsNullOrEmpty(query.Codigo))
            {
                BeneficiarioReporteQueryResult queryResult = _queryDispatcher.Dispatch<BeneficiarioReporteQuery, BeneficiarioReporteQueryResult>(query);
                ReportDataSource dsBeneficiario = new ReportDataSource("DSBeneficiario", queryResult.Beneficiarios);               
                //String _params = JsonHelper.GetJsonStringFromObject(queryResult);

                Boolean _ok = false;
                String _nombreArchivo = String.Empty;
                ReporteConfigDto _config = ReportesConfiguracion.GetReporteConfig(TiposReporte.Beneficiario.Value);
                try
                {
                    byte[] bytes = ReportViewerUtil.GenerateAndPersist(_config, ref _nombreArchivo, queryResult.Beneficiarios, null);
                    GenerateExcelFromReportViewer(bytes, _config.OutputFileName + "." + _config.Format);
                    _ok = true;
                }
                catch(Exception e){
                    Console.Write(e);
                }
                finally{
                    EnviarMail(GetUsuarioLogueado().Cuil.ToString(), _ok, _nombreArchivo, "", _config.AsuntoEmail);
                }
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                long tickDesde = (query.FechaDesde != null ? query.FechaDesde.Value : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde)).Ticks;
                builder.Append(tickDesde);
                builder.Append(",");
                long tickHasta = (query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta)).Ticks;
                builder.Append(tickHasta);
                builder.Append(",");
                builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
                builder.Append(",");
                builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
                builder.Append(",");
                builder.Append(query.Codigo);
                builder.Append(",");
                builder.Append(query.NroDocumento);
                builder.Append(",");
                builder.Append(query.DadosBaja ? 'S' : 'N');
                builder.Append(",");
                builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
                builder.Append(",");
                builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
                builder.Append(",");
                builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
                builder.Append(",");
                builder.Append(query.SituacionCritica);
                builder.Append(",");
                builder.Append(query.TipoBeneficiario != null ? query.TipoBeneficiario : "0");
                builder.Append(",");
                builder.Append(query.TipoDocumentoId);
                builder.Append(",");
                builder.Append(query.PageNumber != null ? query.PaginationFrom.Value : 0);
                builder.Append(",");
                builder.Append(query.PageNumber != null ? query.PaginationTo.Value : 10000);

                ActualizarReporteCommand command = new ActualizarReporteCommand();
                command.IdEstado = (int)EstadoReporteEnum.Pendiente;
                command.StringProceso = builder.ToString();
                command.IdUsuario = GetUsuarioLogueado().Id;
                command.NombreProceso = TiposReporte.Beneficiario.Value;
                _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);
            }

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        [HttpGet]
        [ActionName("GetReporteBeneficiarios")]
        public IHttpActionResult GetReporteBeneficiarios([FromUri]BeneficiarioReporteQuery query)
        {
            BeneficiarioConsultaReporteQueryResult queryResult = _queryDispatcher.Dispatch<BeneficiarioReporteQuery, BeneficiarioConsultaReporteQueryResult>(query);
            return Ok(queryResult);
        }

        #endregion

        #region Salas Cuna

        [HttpGet]
        [ActionName("GenerarReporteSalasCuna")]
        public IHttpActionResult GenerarReporteSalasCuna([FromUri]SalaCunaReporteQuery query)
        {
            StringBuilder builder = new StringBuilder();

            long tickDesde = (DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde)).Ticks;
            builder.Append(tickDesde);
            builder.Append(",");
            long tickHasta = (DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta)).Ticks;
            builder.Append(tickHasta);
            builder.Append(",");
            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.EstadoCorrecto ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.DadosBaja ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.Zona == 0 ? 1 : query.Zona);
            builder.Append(",");
            builder.Append(query.PaginationFrom.Value);
            builder.Append(",");
            builder.Append(query.PaginationTo.Value);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.SalasCuna.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        [HttpGet]
        [ActionName("GetReporteSalasCuna")]
        public IHttpActionResult GetReporteSalasCuna([FromUri]SalaCunaReporteQuery query)
        {
            SalaCunaReporteQueryResult queryResult = _queryDispatcher.Dispatch<SalaCunaReporteQuery, SalaCunaReporteQueryResult>(query);
            return Ok(queryResult);
        }

        #endregion

        #region Provision de productos

        [HttpGet]
        [ActionName("GenerarReporteProvisionProductos")]
        public IHttpActionResult GenerarReporteProvisionProductos([FromUri]ProvisionProductosQuery query)
        {
            if (query.EsCE == false)
            {
                StringBuilder builder = new StringBuilder();

                builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
                builder.Append(",");
                builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
                builder.Append(",");
                builder.Append(query.Codigo);
                builder.Append(",");
                builder.Append(query.DiaDeCorte != null ? query.DiaDeCorte.Value : -1);
                builder.Append(",");
                builder.Append(query.Mes != null ? query.Mes.Value : -1);
                builder.Append(",");
                builder.Append(query.Anio != null ? query.Anio.Value : -1);
                builder.Append(",");
                builder.Append(query.Ubicacion == 0 ? 1 : query.Ubicacion);
                builder.Append(",");
                builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
                builder.Append(",");
                builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
                builder.Append(",");
                builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
                builder.Append(",");
                builder.Append(query.EdadMaxima != null ? query.EdadMaxima.Value : 11);

                ActualizarReporteCommand command = new ActualizarReporteCommand();
                command.IdEstado = (int)EstadoReporteEnum.Pendiente;
                command.StringProceso = builder.ToString();
                command.IdUsuario = GetUsuarioLogueado().Id;
                command.NombreProceso = TiposReporte.ProvisionDeProducto.Value;
                _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

                var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
                return Ok(respuesta);
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
                builder.Append(",");
                builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
                builder.Append(",");
                builder.Append(query.Codigo);
                builder.Append(",");
                builder.Append(query.DiaDeCorte != null ? query.DiaDeCorte.Value : -1);
                builder.Append(",");
                builder.Append(query.Mes != null ? query.Mes.Value : -1);
                builder.Append(",");
                builder.Append(query.Anio != null ? query.Anio.Value : -1);
                builder.Append(",");
                builder.Append(query.Ubicacion == 0 ? 1 : query.Ubicacion);
                builder.Append(",");
                builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
                builder.Append(",");
                builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
                builder.Append(",");
                builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
                builder.Append(",");
                builder.Append(query.EdadMaxima != null ? query.EdadMaxima.Value : 11);

                ActualizarReporteCommand command = new ActualizarReporteCommand();
                command.IdEstado = (int)EstadoReporteEnum.Pendiente;
                command.StringProceso = builder.ToString();
                command.IdUsuario = GetUsuarioLogueado().Id;
                command.NombreProceso = TiposReporte.ProvisionDeProductoCE.Value;
                _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

                var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
                return Ok(respuesta);
            }

        }

        [HttpGet]
        [ActionName("GetReporteProvisionProductos")]
        public IHttpActionResult GetReporteProvisionProductos([FromUri]ProvisionProductosQuery query)
        {
            ProvisionProductosQueryResult queryResult = _queryDispatcher.Dispatch<ProvisionProductosQuery, ProvisionProductosQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GetReporteProvisionProductosCE")]
        public IHttpActionResult GetReporteProvisionProductosCE([FromUri]ProvisionProductosCEQuery query)
        {
            ProvisionProductosCEQueryResult queryResult = _queryDispatcher.Dispatch<ProvisionProductosCEQuery, ProvisionProductosCEQueryResult>(query);
            return Ok(queryResult);
        }

        #endregion

        #region Productos por familia

        [HttpGet]
        [ActionName("GetReporteProductoPorFamilia")]
        public IHttpActionResult GetReporteProductoPorFamilia([FromUri]ProductoPorFamiliaQuery query)
        {
            ProductoPorFamiliaQueryResult queryResult = _queryDispatcher.Dispatch<ProductoPorFamiliaQuery, ProductoPorFamiliaQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpGet]
        [ActionName("ExportReporteProductoPorFamilia")]
        public IHttpActionResult ExportReporteProductoPorFamilia([FromUri]ProductoPorFamiliaQuery query)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != 0 ? query.SalaCunaId : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.Anio != null ? query.Anio.Value : -1);
            builder.Append(",");
            builder.Append(query.Mes != null ? query.Mes.Value : -1);
            builder.Append(",");
            builder.Append(query.DiaDeCorte != null ? query.DiaDeCorte.Value : -1);
            builder.Append(",");
            builder.Append(query.EdadMaxima != null ? query.EdadMaxima.Value : -1);
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.Ubicacion != 0 ? 1 : query.Ubicacion);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.ProductoPorFamiliaPDF.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        [HttpGet]
        [ActionName("GenerarReporteProductoPorFamilia")]
        public IHttpActionResult GenerarReporteProductoPorFamilia([FromUri]ProductoPorFamiliaQuery query)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != 0 ? query.SalaCunaId : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.Anio != null ? query.Anio.Value : -1);
            builder.Append(",");
            builder.Append(query.Mes != null ? query.Mes.Value : -1);
            builder.Append(",");
            builder.Append(query.DiaDeCorte != null ? query.DiaDeCorte.Value : -1);
            builder.Append(",");
            builder.Append(query.EdadMaxima != null ? query.EdadMaxima.Value : -1);
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.Ubicacion != 0 ? 1 : query.Ubicacion);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.ProductoPorFamiliaExcel.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        #endregion

        #region Productos por sala

        [HttpGet]
        [ActionName("GetReporteProductoPorSala")]
        public IHttpActionResult GetReporteProductoPorSala([FromUri]ProductoPorSalaQuery query)
        {
            ProductoPorSalaQueryResult queryResult = _queryDispatcher.Dispatch<ProductoPorSalaQuery, ProductoPorSalaQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GenerarReporteProductoPorSalaPDF")]
        public IHttpActionResult GenerarReporteProductoPorSalaPDF([FromUri]ProductoPorSalaQuery query)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId : null);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.Anio != null ? query.Anio.Value : -1);
            builder.Append(",");
            builder.Append(query.Mes != null ? query.Mes.Value : -1);
            builder.Append(",");
            builder.Append(query.DiaDeCorte != null ? query.DiaDeCorte.Value : -1);
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.UbicacionId != null ? query.UbicacionId.Value : 0);
            builder.Append(",");
            builder.Append(query.EdadMaxima != null ? query.EdadMaxima.Value : 11);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.ProductoPorSala.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        #endregion

        #region Personal por sala
        [HttpGet]
        [ActionName("GetReportePersonalPorSala")]
        public IHttpActionResult GetReportePersonalPorSala([FromUri]PersonalPorSalaQuery query)
        {
            PersonalPorSalaQueryResult queryResult = _queryDispatcher.Dispatch<PersonalPorSalaQuery, PersonalPorSalaQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GenerarReportePersonalPorSala")]
        public IHttpActionResult GenerarReportePersonalPorSala([FromUri]PersonalPorSalaQuery query)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.Turno != null ? query.Turno.Value : -1);
            builder.Append(",");
            builder.Append(query.Conflicto == null ? "T" : query.Conflicto);
            builder.Append(",");
            builder.Append(query.Baja ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationFrom.Value : 0);
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationTo.Value : 100000);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.PersonalPorSala.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);

        }

        #endregion

        #region Curso

        [HttpGet]
        [ActionName("GetSalasByCurso")]
        public IHttpActionResult GetSalasByCurso([FromUri]SalaCunaByCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<SalaCunaByCursoQuery, SalaCunaByCursoQueryResult>(query);
            return Ok(queryResult);
        }


        [HttpGet]
        [ActionName("GenerarReporteAsistenciaPorCusro")]
        public IHttpActionResult GenerarReporteAsistenciaPorCusro([FromUri]AsistenciaPersonalCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<AsistenciaPersonalCursoQuery, AsistenciaPersonalCursoQueryResult>(query);

            CursoByIdQuery cursoQuery = new CursoByIdQuery();
            cursoQuery.CursoId = query.CursoId;
            var queryResult2 = _queryDispatcher.Dispatch<CursoByIdQuery, CursoByIdQueryResult>(cursoQuery);

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("NombreCurso", queryResult2.CursoDto.NombreCurso));
            ReporteConfigDto _config = ReportesConfiguracion.GetReporteConfig(TiposReporte.AsistenciaPorCurso.Value);

            byte[] bytes = ReportViewerUtil.GenerateReport(_config, queryResult.ListPersonal, parametros);
            return GenerateExcelFromReportViewer(bytes, _config.OutputFileName + queryResult2.CursoDto.NombreCurso + "." + _config.Format);
        }

        [HttpGet]
        [ActionName("ExportCertificadosCurso")]
        public IHttpActionResult ExportCertificadosCurso([FromUri]AsistenciaPersonalCursoQuery query)
        {
            List<PersonalAsistenciaDto> lista = new List<PersonalAsistenciaDto>();
            if (query.imprimirTodos)
            {
                AsistenciaPersonalCursoQueryResult queryResult = _queryDispatcher.Dispatch<AsistenciaPersonalCursoQuery, AsistenciaPersonalCursoQueryResult>(query);
                lista = queryResult.ListPersonal;
            }
            else
            {
                PersonalCertificadoQueryResult queryResult = _queryDispatcher.Dispatch<AsistenciaPersonalCursoQuery, PersonalCertificadoQueryResult>(query);
                lista = queryResult.ListPersonal;
            }
            CursoByIdQuery query2 = new CursoByIdQuery();
            query2.CursoId = query.CursoId;
            var queryResult2 = _queryDispatcher.Dispatch<CursoByIdQuery, CursoByIdQueryResult>(query2);

            DateTime fechaActual = DateTime.Now;
            string nombreMes = new DateTime(2015, fechaActual.Month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes);
            string textoAgregado = "";
            int duracionTotalCurso = queryResult2.CursoDto.CantidadDias * (int)queryResult2.CursoDto.HorasPorDia;
            if (duracionTotalCurso > 0.0)
                textoAgregado = "La capacitación tuvo una duración total de " + duracionTotalCurso + "hs. reloj y se llevó a cabo en el SUM de la Secretaría de Equidad y Promoción del Empleo.-";
            else
                textoAgregado = "La capacitación se llevó a cabo en el SUM de la Secretaría de Equidad y Promoción del Empleo.-";

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("NombreCurso", queryResult2.CursoDto.NombreCurso));
            parametros.Add(new ReportParameter("Dia", fechaActual.Day.ToString()));
            parametros.Add(new ReportParameter("Mes", nombreMes));
            parametros.Add(new ReportParameter("Anio", fechaActual.Year.ToString()));
            parametros.Add(new ReportParameter("TextoAgregado", textoAgregado));

            ReporteConfigDto _config = ReportesConfiguracion.GetReporteConfig(TiposReporte.CertificadosPorCurso.Value);
            byte[] bytes = ReportViewerUtil.GenerateReport(_config, lista, parametros);
            return Ok(bytes);
        }

        [HttpGet]
        [ActionName("GenerarReporteAdministrarCursos")]
        public IHttpActionResult GenerarReporteAdministrarCursos([FromUri]CursoByFiltersCursoQuery query)
        {
            query.VieneParaExcel = 1;
            var queryResult = _queryDispatcher.Dispatch<CursoByFiltersCursoQuery, CursoByFiltersCursoQueryResult>(query);

            ReporteConfigDto _config = ReportesConfiguracion.GetReporteConfig(TiposReporte.AdministrarCursos.Value);
            byte[] bytes = ReportViewerUtil.GenerateReport(_config, queryResult.CursosDto, null);
            return GenerateExcelFromReportViewer(bytes, _config.OutputFileName + "." + _config.Format);
        }

        [HttpGet]
        [ActionName("ExportListadoInscriptos")]
        public IHttpActionResult ExportListadoInscriptos([FromUri]ClaseByCursoQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<ClaseByCursoQuery, ListadoInscriptosQueryResult>(query);
            CursoByIdQuery queryCurso = new CursoByIdQuery();
            queryCurso.CursoId = query.CursoId;
            var queryResult2 = _queryDispatcher.Dispatch<CursoByIdQuery, CursoByIdQueryResult>(queryCurso);

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("NombreCurso", queryResult2.CursoDto.NombreCurso));
            ReporteConfigDto _config = ReportesConfiguracion.GetReporteConfig(TiposReporte.ListadoInscriptosCursos.Value);
            byte[] bytes = ReportViewerUtil.GenerateReport(_config, queryResult.ListPersonal, parametros);
            return Ok(bytes);
        }

        #endregion

        #region Grupo familiar

        [HttpGet]
        [ActionName("GetReporteGrupoFamiliar")]
        public IHttpActionResult GetReporteGrupoFamiliar([FromUri]GrupoFamiliarQuery query)
        {
            query.Reporte = 0;
            GrupoFamiliarQueryResult queryResult = _queryDispatcher.Dispatch<GrupoFamiliarQuery, GrupoFamiliarQueryResult>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GenerarReporteGrupoFamiliar")]
        public IHttpActionResult ExportReporteGrupoFamiliar([FromUri]GrupoFamiliarQuery query)
        {
            Int64 cero = 0;

            StringBuilder builder = new StringBuilder();

            long tickDesde = (query.FechaDesde != null ? query.FechaDesde.Value : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde)).Ticks;
            builder.Append(tickDesde);
            builder.Append(",");
            long tickHasta = (query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta)).Ticks;
            builder.Append(tickHasta);
            builder.Append(",");
            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.NroDocumento);
            builder.Append(",");
            builder.Append(query.DadosBaja ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.DepartamentoId != cero ? query.DepartamentoId : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != cero ? query.LocalidadId : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != cero ? query.BarrioId : -1);
            builder.Append(",");
            builder.Append(query.SituacionCritica);
            builder.Append(",");
            builder.Append(query.RecibeOtroPS ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationFrom.Value : -1);
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationTo.Value : -1);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.GrupoFamiliar.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);

        }

        #endregion

        #region Socio Ambiental

        [HttpGet]
        [ActionName("GetReporteSocioAmbiental")]
        public IHttpActionResult GetReporteSocioAmbiental([FromUri]ReporteSocioAmbientalByFiltersQuery query)
        {
            var queryResult = _queryDispatcher.Dispatch<ReporteSocioAmbientalByFiltersQuery, ReporteSocioAmbientalByFiltersQueryResults>(query);
            return Ok(queryResult);
        }

        [HttpGet]
        [ActionName("GenerarReporteSocioAmbiental")]
        public IHttpActionResult GenerarReporteSocioAmbiental([FromUri]ReporteSocioAmbientalByFiltersQuery query)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(query.SocioAmbientalId != null ? query.SocioAmbientalId.Value : -1);
            builder.Append(",");
            long tickDesde = (query.FechaDesde != null ? query.FechaDesde.Value : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde)).Ticks;
            builder.Append(tickDesde);
            builder.Append(",");
            long tickHasta = (query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta)).Ticks;
            builder.Append(tickHasta);
            builder.Append(",");
            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.NroDocumento);
            builder.Append(",");
            builder.Append(query.DadosBaja ? 'S' : 'N');
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.SituacionCritica);
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationFrom.Value : 0);
            builder.Append(",");
            builder.Append(query.PageNumber != null ? query.PaginationTo.Value : 10000);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.SocioAmbiental.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        #endregion

        #region Info Global

        [HttpGet]
        [ActionName("GenerarReporteInfoGlobal")]
        public IHttpActionResult GenerarReporteInfoGlobal([FromUri]InfoGlobalQuery query)
        {
            StringBuilder builder = new StringBuilder();

            long tickDesde = (query.FechaDesde != null ? query.FechaDesde.Value : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde)).Ticks;
            builder.Append(tickDesde);
            builder.Append(",");
            long tickHasta = (query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta)).Ticks;
            builder.Append(tickHasta);
            builder.Append(",");
            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.SituacionCritica);
            builder.Append(",");
            builder.Append(query.Ubicacion);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.InfoGlobal.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);


        }

        [HttpGet]
        [ActionName("GetReporteInfoGlobal")]
        public IHttpActionResult GetReporteInfoGlobal([FromUri]InfoGlobalQuery query)
        {
            InfoGlobalQueryResults queryResult = _queryDispatcher.Dispatch<InfoGlobalQuery, InfoGlobalQueryResults>(query);
            return Ok(queryResult);
        }

        #endregion

        #region Madres beneficiarios

        [HttpGet]
        [ActionName("GenerarReporteMadresBeneficiarios")]
        public IHttpActionResult GenerarReporteMadresBeneficiarios([FromUri]MadresBeneficiariosQuery query)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(query.PersonaJuridicaId != null ? query.PersonaJuridicaId.Value : -1);
            builder.Append(",");
            builder.Append(query.SalaCunaId != null ? query.SalaCunaId.Value : -1);
            builder.Append(",");
            builder.Append(query.Codigo);
            builder.Append(",");
            builder.Append(query.DepartamentoId != null ? query.DepartamentoId.Value : -1);
            builder.Append(",");
            builder.Append(query.LocalidadId != null ? query.LocalidadId.Value : -1);
            builder.Append(",");
            builder.Append(query.BarrioId != null ? query.BarrioId.Value : -1);
            builder.Append(",");
            builder.Append(query.Ubicacion);
            builder.Append(",");
            builder.Append(query.EdadDesde != null ? query.EdadDesde.Value : -1);
            builder.Append(",");
            builder.Append(query.EdadHasta != null ? query.EdadHasta.Value : -1);
            builder.Append(",");
            builder.Append(query.NivelEscolaridad);
            builder.Append(",");
            builder.Append(query.EstadoCivil);
            builder.Append(",");
            builder.Append(query.Ocupacion);
            builder.Append(",");
            builder.Append(query.Responsable);

            ActualizarReporteCommand command = new ActualizarReporteCommand();
            command.IdEstado = (int)EstadoReporteEnum.Pendiente;
            command.StringProceso = builder.ToString();
            command.IdUsuario = GetUsuarioLogueado().Id;
            command.NombreProceso = TiposReporte.MadresBeneficiarios.Value;
            _commandDispatcher.Dispatch<ActualizarReporteCommand>(command);

            var respuesta = new { mensaje = _mensaje + GetEmailUsuarioLogueado() };
            return Ok(respuesta);
        }

        #endregion

        #region Common

        [HttpGet]
        [AllowAnonymous]
        [ActionName("GenerarReporte")]
        public IHttpActionResult GenerarReporte([FromUri]EnviarMailQuery query)
        {
            return DownloadFile(ContextSingleton.Instance.TempReportsPath + query.FileName, query.FileName);
        }

        #endregion common
    }


}