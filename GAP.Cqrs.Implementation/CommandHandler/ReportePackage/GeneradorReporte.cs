using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.AdministrarConvenios;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Dto.ProvisionProductos;
using GAP.Base.Dto.Reportes;
using GAP.Base.Dto.SalasCuna;
using GAP.Base.Enumerations;
using GAP.Base.Helper;
using GAP.Base.Reportes;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.Query.ProvisionProductosQuery;
using GAP.Cqrs.Implementation.Query.ReporteQuery;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Reporting.WebForms;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    public class GeneradorReporte
    {
        private QueryDispatcher QueryDispatcher { get; set; }
        private String[] ParametrosSeparados { get; set; }
        private RepositoryLocalScheme _repositoryLocalScheme;

        #region Gestor reportes

        public string GenerarReporte()
        {
            QueryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();

            //1) Si no existe un reporte ejecutandose busco el reporte en estado pendiente mas antiguo.
            ConsultarReportesPendientesQueryResult rpResult = QueryDispatcher.Dispatch<ConsultarReportesPendientesQuery, ConsultarReportesPendientesQueryResult>(null);

            if (rpResult != null && rpResult.ReportesPendientesDto != null && !String.IsNullOrEmpty(rpResult.ReportesPendientesDto.NombreProceso))
            {
                ReporteConfigDto config = ReportesConfiguracion.GetReporteConfig(rpResult.ReportesPendientesDto.NombreProceso);

                //2) Se genera el reporte y se envía por email.
                Task.Run(async () => GenerarReporteAsync(rpResult.ReportesPendientesDto, config));
            }
            return String.Empty;
        }

        private void GenerarReporteAsync(ReportesPendientesDto _reportesPendientesDto, ReporteConfigDto _config)
        {
            String _nombreArchivo = String.Empty;

            //Se anexa a loa parámetros el id de proceso y luego se obtiene un array de todos los parámetros.
            String _params = _reportesPendientesDto.StringProcedimiento + "," + _reportesPendientesDto.ProcesoId;
            ParametrosSeparados = _params.Split(',');

            Boolean _ok = false;
            object _dto = null;
            try
            {
                _reportesPendientesDto.NombreProceso = _reportesPendientesDto.NombreProceso.ToUpper();
                _repositoryLocalScheme = new RepositoryLocalScheme();

                //3)Se llama al procedimiento correspondiente al reporte asociado al proceso. 
                
                //Madres beneficiarios
                if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.MadresBeneficiarios.Value.ToUpper()))
                    _dto = GenerarReporteMadresBeneficiarios<MadresBeneficiariosDto>(_config);
                //Socio ambiental
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.SocioAmbiental.Value.ToUpper()))
                    _dto = GenerarReporteSocioAmbiental<SocioAmbientalDto>(_config);

                //Info Global
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.InfoGlobal.Value.ToUpper()))
                    _dto = GenerarReporteInfoGloabal<InfoGlobalDto>(_config);

                //GrupoFamiliar
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.GrupoFamiliar.Value.ToUpper()))
                    _dto = GenerarReporteGrupoFamiliar<GrupoFamiliarDto>(_config);

                //Personal por sala
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.PersonalPorSala.Value.ToUpper()))
                    _dto = GenerarReportePersonalPorSala<PersonalPorSalaDto>(_config);

                //Producto por Sala
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorSala.Value.ToUpper()))
                    _dto = GenerarReporteProductorPorSala<ProductosPorSalaDto>(_config);

                //Productor por familia PDF
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorFamiliaPDF.Value.ToUpper()))
                    _dto = GenerarReporteProductorPorFamiliaPDF<ProductoXFamiliaXSalaDto>(_config);

                    //Productor por familia EXCEL
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorFamiliaExcel.Value.ToUpper()))
                    _dto = GenerarReporteProductorPorFamiliaExcel<ProductoXFamiliaXSalaDto>(_config);

                 //Provision de producto
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProvisionDeProducto.Value.ToUpper()))
                    _dto = GenerarReporteProvisionDeProducto<ProvisionProductosReporteDto>(_config);              

                    //Provision de producto especiales
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProvisionDeProductoCE.Value.ToUpper()))
                    _dto = GenerarReporteProvisionDeProductoCE<ProvisionProductosReporteDto>(_config);

                //Salas cuna
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.SalasCuna.Value.ToUpper()))
                    _dto = GenerarReporteSalasCuna(_config);

                //Beneficiario
                else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.Beneficiario.Value.ToUpper()))
                    _dto = GenerarReporteBeneficiario<BeneficiarioReporteDto>(_config);

                if (_dto != null)
                {
                    List<ReportParameter> _reportParams = DeterminarParametros(_reportesPendientesDto);

                    //4)Creo el reporte en disco                    
                    ReportViewerUtil.GenerateAndPersist(_config, ref _nombreArchivo, _dto, _reportParams);
                    _ok = true;                
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                FinalizarProceso(_reportesPendientesDto.ProcesoId, _ok);
                EnviarMail(_reportesPendientesDto.Cuil, _ok, _nombreArchivo, _params, _config.AsuntoEmail);
            }
        }

        private void EnviarMail(String cuil, Boolean archivoGeneradoConExito, String nombreArchivo, String queryParams, String reportTitle)
        {

            EnviarMailQuery _enviarMailQuery = new EnviarMailQuery();
            _enviarMailQuery.Cuil = cuil;
            StringBuilder _mensaje = new StringBuilder();
            if (archivoGeneradoConExito)
            {
                _enviarMailQuery.Link = FileUtil.GenerarLinkDeDescarga(nombreArchivo);
                _mensaje.Append(GlobalVars.EmailMensaje);
            }
            else
            {
                _mensaje.Append("Se produjo un error inesperado al generar el reporte '")
                .Append(nombreArchivo)
                .Append("'. Por favor pongase en contacto con un administrador del sistema.")
                .Append("\n")
                .Append("Parámetros enviados: ")
                .Append(queryParams);
            }
            _enviarMailQuery.Mensaje = _mensaje.ToString();
            _enviarMailQuery.ReportTitle = reportTitle;
            var _enviarMailQueryResult = QueryDispatcher.Dispatch<EnviarMailQuery, EnviarMailQueryResult>(_enviarMailQuery);
        }

        private void FinalizarProceso(decimal _idPorceso, Boolean _ok)
        {            
            StringBuilder builder = new StringBuilder();
            var query = _repositoryLocalScheme.Session.CallFunction(ActualizarReporteCommandHandler.SP_NAME)
                .SetParameter(0, -1)
                .SetParameter(1, (int) _idPorceso)
                .SetParameter(2, _ok ? (int) EstadoReporteEnum.Finalizado : (int) EstadoReporteEnum.Error)
                .SetParameter(3, null, NHibernateUtil.String)
                .SetParameter(4, null, NHibernateUtil.String);
            query.UniqueResult();
        }

        public static void CancelarProcesosEjecutandose()
        {
            RepositoryLocalScheme _repositoryLocalScheme = new RepositoryLocalScheme();
            var query = _repositoryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_CANCELAR_PROCESOS()");
            query.ExecuteUpdate();
        }

        #endregion Fin gestor reportes

        #region Llamadas a procedimeintos

        private object GenerarReporteMadresBeneficiarios<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParamIntNulleable(querySession, 6, Int64.Parse(ParametrosSeparados[6]));
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParamStringNulleable(querySession, 9, ParametrosSeparados[9]);
            addParamStringNulleable(querySession, 10, ParametrosSeparados[10]);
            addParamStringNulleable(querySession, 11, ParametrosSeparados[11]);
            addParam(querySession, 12, ParametrosSeparados[12]);
            addParam(querySession, 13, ParametrosSeparados[13]);            
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteSocioAmbiental<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParamDate(querySession, 1, ParametrosSeparados[1]);
            addParamDate(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParamStringNulleable(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            addParam(querySession, 12, ParametrosSeparados[12]);
            addParam(querySession, 13, ParametrosSeparados[13]);
            addParam(querySession, 14, ParametrosSeparados[14]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteInfoGloabal<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?)");
            addParamDate(querySession, 0, ParametrosSeparados[0]);
            addParamDate(querySession, 1, ParametrosSeparados[1]);
            addParam(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParamStringNulleable(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteGrupoFamiliar<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            addParamDate(querySession, 0, ParametrosSeparados[0]);
            addParamDate(querySession, 1, ParametrosSeparados[1]);
            addParam(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParamStringNulleable(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            addParam(querySession, 12, ParametrosSeparados[12]);
            addParam(querySession, 13, ParametrosSeparados[13]);
            addParam(querySession, 14, ParametrosSeparados[14]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReportePersonalPorSala<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParamStringNulleable(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteProductorPorSala<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParamStringNulleable(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteProductorPorFamiliaPDF<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteProductorPorFamiliaExcel<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            return (List<T>)querySession.List<T>();
        }

        private object GenerarReporteProvisionDeProducto<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);

            List<ProvisionProductosReporteDto> lista = (List<ProvisionProductosReporteDto>)querySession.List<ProvisionProductosReporteDto>(); 

            var queryResult = new ProvisionProductosQueryResult();

            var querySession2 = _repositoryLocalScheme.Session.CallFunction<ParametrosProvisionDto>("PR_PARAMETROS_PROVISIONES ()");
            queryResult.ParametrosProvision = querySession2.UniqueResult<ParametrosProvisionDto>();
            //Valores que en un futura seran parametros fijos.

            float paramLecheA = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramLecheA.ToString());
            float paramLecheB = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramLecheB.ToString());
            float paramPanialA = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanialA.ToString());
            float paramPanial0a2Anios = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanial0a2Anios.ToString());
            float paramPanial3Anios = (float)System.Convert.ToSingle(queryResult.ParametrosProvision.paramPanial3Anios.ToString());

            foreach (ProvisionProductosReporteDto provisionesPorEntidadYSala in lista)
                provisionesPorEntidadYSala.SetParametrosDeCalculo(paramLecheA, paramLecheB, paramPanialA, paramPanial0a2Anios, paramPanial3Anios);

            return lista;           
        }

        private object GenerarReporteProvisionDeProductoCE<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?)");
            addParam(querySession, 0, ParametrosSeparados[0]);
            addParam(querySession, 1, ParametrosSeparados[1]);
            addParamStringNulleable(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            return (List<T>)querySession.List<T>();            
        }

        private object GenerarReporteSalasCuna(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<SalasCunaReporteDto>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            addParamDate(querySession, 0, ParametrosSeparados[0]);
            addParamDate(querySession, 1, ParametrosSeparados[1]);
            addParam(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParam(querySession, 4, ParametrosSeparados[4]);
            addParam(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParamStringNulleable(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            addParam(querySession, 12, ParametrosSeparados[12]);
            addParam(querySession, 13, ParametrosSeparados[13]);
            List<SalasCunaReporteDto> listaSalasCuna = (List<SalasCunaReporteDto>)querySession.List<SalasCunaReporteDto>(); 


            foreach (SalasCunaReporteDto salasCuna in listaSalasCuna)
            {

                QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();

                //convenios
                var queryConvenios = new ConveniosDeSalaByFiltersQuery { SalaCunaId = (int)salasCuna.SalaCunaId };
                var resultadoConvenios = _queryDispatcher.Dispatch<ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>(queryConvenios);

                salasCuna.Convenios = resultadoConvenios.ConveniosDeSalaCunaDto;

                List<ConveniosDeSalasCunaDto> convenios = salasCuna.Convenios;
                if (convenios != null && convenios.Count != 0)
                {
                    StringBuilder conveniosString = new StringBuilder();
                    foreach (ConveniosDeSalasCunaDto convenio in convenios)
                    {
                        conveniosString.Append(" " + DateTimeHelper.GetShortDateTime(convenio.FechaDesde) + " - " + DateTimeHelper.GetShortDateTime(convenio.FechaHasta) + " ,");
                    }
                    conveniosString = new StringBuilder(conveniosString.ToString().Substring(0, conveniosString.ToString().Length - 1));
                    salasCuna.ConveniosString = conveniosString.ToString();
                    salasCuna.ConveniosEstado = "Correcto";
                }
                else
                {
                    salasCuna.ConveniosString = ""; 
                    salasCuna.ConveniosEstado = "Incorrecto";
                }

                //fin convenios

                //requisitos
                var queryRequisitos = new RequisitosDeSalaByFiltersQuery { IdSalaCuna = (int)salasCuna.SalaCunaId };
                var resultadoRequisitos = _queryDispatcher.Dispatch<RequisitosDeSalaByFiltersQuery, RequisitosReporteSalaCunaQueryResult>(queryRequisitos);

                salasCuna.ListRequisitos = resultadoRequisitos.RequisitosPresentadosDto;
                salasCuna.RequisitosEstado = salasCuna.DebeRequisitos == "N" ? "Completo" : "Incompleto";

                //fin requisitos

                //inmuebles
                var queryInmuebles = new InmuebleByFiltersQuery { SalaCunaId = (int)salasCuna.SalaCunaId };
                var resultadoInmuebles = _queryDispatcher.Dispatch<InmuebleByFiltersQuery, InmuebleByFiltersQueryResult>(queryInmuebles);

                double monto = 0;
                foreach (InmuebleDto inmueble in resultadoInmuebles.InmueblesDto)
                {
                    monto += inmueble.Monto;
                }

                salasCuna.MontoRefacciones = monto;
                salasCuna.Inmuebles = resultadoInmuebles.InmueblesDto;
            }


            return listaSalasCuna.Cast<object>().ToList();        
        }

        private object GenerarReporteBeneficiario<T>(ReporteConfigDto _config)
        {
            var querySession = _repositoryLocalScheme.Session.CallFunction<T>(_config.StoreProcedureName + "(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            addParamDate(querySession, 0, ParametrosSeparados[0]);
            addParamDate(querySession, 1, ParametrosSeparados[1]);
            addParam(querySession, 2, ParametrosSeparados[2]);
            addParam(querySession, 3, ParametrosSeparados[3]);
            addParamStringNulleable(querySession, 4, ParametrosSeparados[4]);
            addParamStringNulleable(querySession, 5, ParametrosSeparados[5]);
            addParam(querySession, 6, ParametrosSeparados[6]);
            addParam(querySession, 7, ParametrosSeparados[7]);
            addParam(querySession, 8, ParametrosSeparados[8]);
            addParam(querySession, 9, ParametrosSeparados[9]);
            addParam(querySession, 10, ParametrosSeparados[10]);
            addParam(querySession, 11, ParametrosSeparados[11]);
            addParamStringNulleable(querySession, 12, ParametrosSeparados[12]);
            addParam(querySession, 13, ParametrosSeparados[13]);
            addParam(querySession, 14, ParametrosSeparados[14]);
            addParam(querySession, 15, ParametrosSeparados[15]);
            return (List<T>)querySession.List<T>();   
        }


        /// <summary>
        /// Cuando se espera que en la cadena de parámetros venga un valor vacio (es decir un null) y el sp espera un number
        /// se debe invocar este método
        /// </summary>
        /// <param name="querySession"></param>
        /// <param name="idParam"></param>
        /// <param name="value"></param>
        private void addParamIntNulleable(ISQLQuery querySession, int idParam, Int64 value)
        {
            if (value == null)
                querySession.SetParameter(idParam, null, NHibernateUtil.Int64);
            else
                querySession.SetParameter(idParam, value);
        }

        /// <summary>
        /// Cuando se espera que en la cadena de parámetros venga un valor vacio (es decir un null) y el sp espera un string
        /// se debe invocar este método
        /// </summary>
        /// <param name="querySession"></param>
        /// <param name="idParam"></param>
        /// <param name="value"></param>
        private void addParamStringNulleable(ISQLQuery querySession, int idParam, string value)
        {
            if (value == null)
                querySession.SetParameter(idParam, null, NHibernateUtil.String);
            else
                querySession.SetParameter(idParam, value);
        }

        /// <summary>
        /// Cuando se espera que en la cadena de parámetros no venga con un vacio (ejemplo -1 o algún valor)
        /// se debe invocar este método
        /// </summary>
        /// <param name="querySession"></param>
        /// <param name="idParam"></param>
        /// <param name="value"></param>
        private void addParam(ISQLQuery querySession, int idParam, string value)
        {
            querySession.SetParameter(idParam, value);
        }

        private void addParamDate(ISQLQuery querySession, int idParam, string tick)
        {
            querySession.SetParameter(idParam, new DateTime(long.Parse(tick)));
        }

        //TODO Alvaro refactorizar
        private List<ReportParameter> DeterminarParametros(ReportesPendientesDto _reportesPendientesDto)
        {
            List<ReportParameter> parametros = new List<ReportParameter>();

            if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorFamiliaPDF.Value.ToUpper()))
            {                
                int mesInt = int.Parse(ParametrosSeparados[4]);
                string mes = new DateTime(2022, mesInt, 2).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes);
                parametros.Add(new ReportParameter("Mes", mes));
            }
            else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorFamiliaExcel.Value.ToUpper()))
            {
                int mesInt = int.Parse(ParametrosSeparados[4]);
                int anioInt = int.Parse(ParametrosSeparados[3]);
                string mes = new DateTime(2022, mesInt, 2).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes);
                string fecha = mes + " del " + anioInt.ToString();
                parametros.Add(new ReportParameter("Fecha", fecha));
            }
            else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.ProductoPorSala.Value.ToUpper()))
            {
                int mesInt = int.Parse(ParametrosSeparados[4]);
                string mes = new DateTime(2022, mesInt, 2).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes);
                parametros.Add(new ReportParameter("Mes", mes));
            }
            else if (_reportesPendientesDto.NombreProceso.Equals(TiposReporte.InfoGlobal.Value.ToUpper()))
            {
                string fechaCompleta = DateTimeHelper.GetFullDateAsString();
                parametros.Add(new ReportParameter("Fecha", fechaCompleta));
            }
            return parametros.Count == 0 ? null : parametros;    
        }

        #endregion
    }
}
