
using GAP.Base.Dto.Reportes;
using GAP.Base.Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Reportes
{
    public class ReportViewerUtil
    {
        public static byte[] GenerateAndPersist(ReporteConfigDto _config, ref String _nombreArchivo, object _dto, List<ReportParameter> _reportParams)
        {
            byte[] bytes = GenerateReport(_config, ref _nombreArchivo, _dto, _reportParams);
            string rutaArchivoEnDirectorioTemporal = FileUtil.GenerarRutaArchivoEnDirectorioTemporal(_nombreArchivo);
            PersistFile(rutaArchivoEnDirectorioTemporal, bytes);
            return bytes;
        }

        public static byte[] GenerateReport(ReporteConfigDto _config, object _dto, List<ReportParameter> _reportParams)
        {
            ReportDataSource ds = new ReportDataSource(_config.DataSource, _dto);
            return GenerateFromReportViewer(_config.TiposArchivo.Value, _config.Rdlc, ds, _reportParams);
        }

        private static byte[] GenerateReport(ReporteConfigDto _config, ref String _nombreArchivo, object _dto, List<ReportParameter> _reportParams)
        {
            ReportDataSource ds = new ReportDataSource(_config.DataSource, _dto);
            _nombreArchivo = FileUtil.GenerarNombreArchivoConFecha(_config.OutputFileName, _config.Format);
            return GenerateFromReportViewer(_config.TiposArchivo.Value, _config.Rdlc, ds, _reportParams);
        }

        private static byte[] PersistFile(string pathFileNameOutput, byte[] bytes)
        {
            FileStream fs = new FileStream(pathFileNameOutput, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            return bytes;
        }

        private static byte[] GenerateFromReportViewer(string format, string fileNamePath, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = ContextSingleton.Instance.ApplicationPath + @"Reports\" + fileNamePath;
            viewer.LocalReport.DataSources.Add(dataSource);

            if (parameters != null)
                viewer.LocalReport.SetParameters(parameters);

            return viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        }
    }
}
