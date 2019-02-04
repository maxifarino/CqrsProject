using GAP.Base.Dto;
using GAP.Base.Dto.Reportes;
using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental;
using GAP.Cqrs.Implementation.Query.MadresBeneficiariosQuery;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    public class ReportesConfiguracion
    {
        public static ReporteConfigDto GetReporteConfig(string _nombreProceso)
        {
            ReporteConfigDto config = null;

            if (String.IsNullOrEmpty(_nombreProceso))
                return config;

            _nombreProceso = _nombreProceso.ToUpper();

            //Madres beneficiarios
            if (_nombreProceso.Equals(TiposReporte.MadresBeneficiarios.Value.ToUpper()))
                config = GetReporteMadreBeneficiarioConfig();

            //Socio ambiental
            else if (_nombreProceso.Equals(TiposReporte.SocioAmbiental.Value.ToUpper()))
                config = GetReporteSocioAmbientalConfig();

            //Info Global
            else if (_nombreProceso.Equals(TiposReporte.InfoGlobal.Value.ToUpper()))
                config = GetReporteInfoGlobalConfig();

            //GrupoFamiliar
            else if (_nombreProceso.Equals(TiposReporte.GrupoFamiliar.Value.ToUpper()))
                config = GetReporteGrupoFamiliarConfig();

            //Personal por sala
            else if (_nombreProceso.Equals(TiposReporte.PersonalPorSala.Value.ToUpper()))
                config = GetReportePersonalPorSalaConfig();

            //Producto por Sala
            else if (_nombreProceso.Equals(TiposReporte.ProductoPorSala.Value.ToUpper()))
                config = GetReporteProductorPorSalaConfig();

            //Productor por familia PDF
            else if (_nombreProceso.Equals(TiposReporte.ProductoPorFamiliaPDF.Value.ToUpper()))
                config = GetReporteProductorPorFamiliaPDFConfig();

            //Productor por familia EXCEL
            else if (_nombreProceso.Equals(TiposReporte.ProductoPorFamiliaExcel.Value.ToUpper()))
                config = GetReporteProductorPorFamiliaExcelConfig();

            //Provision de producto
            else if (_nombreProceso.Equals(TiposReporte.ProvisionDeProducto.Value.ToUpper()))
                config = GetReporteProvisionDeProductoConfig();

            //Provision de producto especiales
            else if (_nombreProceso.Equals(TiposReporte.ProvisionDeProductoCE.Value.ToUpper()))
                config = GetReporteProvisionDeProductoCEConfig();

            //Salas cuna
            else if (_nombreProceso.Equals(TiposReporte.SalasCuna.Value.ToUpper()))
                config = GetReporteSalasCunaConfig();

            //Beneficiario
            else if (_nombreProceso.Equals(TiposReporte.Beneficiario.Value.ToUpper()))
                config = GetReporteBeneficiarioConfig();

            //AsistenciaPorCurso
            else if (_nombreProceso.Equals(TiposReporte.AsistenciaPorCurso.Value.ToUpper()))
                config = GetReporteAsistenciaPorCursoConfig();

            //CertificadosPorCurso
            else if (_nombreProceso.Equals(TiposReporte.CertificadosPorCurso.Value.ToUpper()))
                config = GetReporteCertificadosPorCursoConfig();

            else if (_nombreProceso.Equals(TiposReporte.AdministrarCursos.Value.ToUpper()))
                config = GetReporteAdministrarCursosConfig();

            else if (_nombreProceso.Equals(TiposReporte.ListadoInscriptosCursos.Value.ToUpper()))
                config = GetReporteListadoInscriptosCursosConfig();
            

            return config;
        }

        #region Reportes configuraciones

        private static ReporteConfigDto GetReporteMadreBeneficiarioConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSMadresBeneficiarios";
            config.OutputFileName = "MadresBeneficiariosExcel";
            config.Format = "xls";
            config.Rdlc = "MadresBeneficiariosExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_MADRES";
            config.AsuntoEmail = "Reporte madres de beneficiarios";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteSocioAmbientalConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSSocioAmbiental";
            config.OutputFileName = "ReporteSocioAmbientalExcel";
            config.Format = "xls";
            config.Rdlc = "ReporteSocioAmbiental.rdlc";
            config.StoreProcedureName = "PR_REPORTE_SOCIO_AMBIENTAL";
            config.AsuntoEmail = "Reporte socio ambiental";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteInfoGlobalConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSInfoGlobal";
            config.OutputFileName = "ReporteInfoGlobal";
            config.Format = "xls";
            config.Rdlc = "InfoGlobal.rdlc";
            config.StoreProcedureName = "PR_REPORTE_INFO_GLOBAL";
            config.AsuntoEmail = "Reporte info global";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteGrupoFamiliarConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSGrupoFamiliar";
            config.OutputFileName = "ReporteGrupoConviviente";
            config.Format = "xls";
            config.Rdlc = "GrupoFamiliarExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_GRUPO_FAMILIAR";
            config.AsuntoEmail = "Reporte grupo conviviente";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReportePersonalPorSalaConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSPersonal";
            config.OutputFileName = "ReportePersonalPorSala";
            config.Format = "xls";
            config.Rdlc = "PersonalPorSala.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PERS_X_SALA";
            config.AsuntoEmail = "Reporte personal por sala";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteProductorPorSalaConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSReporteProductoPorSala";
            config.OutputFileName = "ProductoXSala";
            config.Format = "pdf";
            config.Rdlc = "ProductoXSala.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PROD_X_SALA";
            config.AsuntoEmail = "Reporte producto por sala";
            config.TiposArchivo = TiposArchivo.PDF;
            return config;
        }

        private static ReporteConfigDto GetReporteProductorPorFamiliaPDFConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSReportePXFXS";
            config.OutputFileName = "ReporteProductosXFamiliaTotalizado";
            config.Format = "pdf";
            config.Rdlc = "ProductoXFamiliaXSala.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PROD_X_FAMILIA";
            config.AsuntoEmail = "Reporte producto por familia";
            config.TiposArchivo = TiposArchivo.PDF;
            return config;
        }

        private static ReporteConfigDto GetReporteProductorPorFamiliaExcelConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSReportePXFXS";
            config.OutputFileName = "ReporteProductosXFamiliaTotalizado";
            config.Format = "xls";
            config.Rdlc = "ExcelPxFxS.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PROD_X_FAMILIA";
            config.AsuntoEmail = "Reporte producto por familia";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteProvisionDeProductoConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSProvisionProductos";
            config.OutputFileName = "ProvisionProductos";
            config.Format = "xls";
            config.Rdlc = "ProvisionProductosExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PROVISIONES";
            config.AsuntoEmail = "Reporte provisión de producto";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteProvisionDeProductoCEConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSProvisionProductos";
            config.OutputFileName = "ProvisionProductosCE";
            config.Format = "xls";
            config.Rdlc = "ProvisionProductosCEExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_PROVISIONES_CE";
            config.AsuntoEmail = "Reporte provisión de producto especiales";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteSalasCunaConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSSalasCuna";
            config.OutputFileName = "ReporteSalasCunas";
            config.Format = "xls";
            config.Rdlc = "SalasCunaExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_SALAS_CUNA";
            config.AsuntoEmail = "Reporte salas cuna";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteBeneficiarioConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSBeneficiario";
            config.OutputFileName = "Beneficiario";
            config.Format = "xls";
            config.Rdlc = "BeneficiarioExcel.rdlc";
            config.StoreProcedureName = "PR_REPORTE_BENEFICIARIOS";
            config.AsuntoEmail = "Reporte beneficiario";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteAsistenciaPorCursoConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSAsistenciaPorCurso";
            config.OutputFileName = "ReporteAsistenciaCurso";
            config.Format = "xls";
            config.Rdlc = "AsistenciaPorCurso.rdlc";
            config.StoreProcedureName = "";
            config.AsuntoEmail = "Reporte asistencia por curso";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteCertificadosPorCursoConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSCertificadosCurso";
            config.OutputFileName = "ReporteCertificadosPorCurso";
            config.Format = "pdf";
            config.Rdlc = "CertificadosCurso.rdlc";
            config.StoreProcedureName = "";
            config.AsuntoEmail = "Reporte certificados por curso";
            config.TiposArchivo = TiposArchivo.PDF;
            return config;
        }

        private static ReporteConfigDto GetReporteAdministrarCursosConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSCursos";
            config.OutputFileName = "InformeCursos";
            config.Format = "xls";
            config.Rdlc = "CursosExcel.rdlc";
            config.StoreProcedureName = "";
            config.AsuntoEmail = "Reporte administrar curso";
            config.TiposArchivo = TiposArchivo.Excel;
            return config;
        }

        private static ReporteConfigDto GetReporteListadoInscriptosCursosConfig()
        {
            ReporteConfigDto config = new ReporteConfigDto();
            config.DataSource = "DSListadoInscriptos";
            config.OutputFileName = "InscriptosCursos";
            config.Format = "pdf";
            config.Rdlc = "ListadoInscriptos.rdlc";
            config.StoreProcedureName = "";
            config.AsuntoEmail = "Reporte inscriptos a curso";
            config.TiposArchivo = TiposArchivo.PDF;
            return config;
        }
        
        #endregion

    }
}
