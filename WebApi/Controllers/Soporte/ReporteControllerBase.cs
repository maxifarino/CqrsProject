using GAP.Base;
using GAP.Base.Dto.Usuario;
using GAP.Base.Helper;
using GAP.Base.Reportes;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.App_Start.Security;
using WebApi.Models.Usuario;

namespace WebApi.Controllers.Soporte
{
    public class ReporteControllerBase : ApiControllerBase
    {

        public IHttpActionResult DownloadFile(string path, string fileNameOutput)
        {
            if (!File.Exists(path))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            try
            {
                MemoryStream responseStream = new MemoryStream();
                Stream fileStream = File.Open(path, FileMode.Open);
                bool fullContent = true;
                if (this.Request.Headers.Range != null)
                {
                    fullContent = false;

                    // Currently we only support a single range.
                    RangeItemHeaderValue range = this.Request.Headers.Range.Ranges.First();


                    // From specified, so seek to the requested position.
                    if (range.From != null)
                    {
                        fileStream.Seek(range.From.Value, SeekOrigin.Begin);

                        // In this case, actually the complete file will be returned.
                        if (range.From == 0 && (range.To == null || range.To >= fileStream.Length))
                        {
                            fileStream.CopyTo(responseStream);
                            fullContent = true;
                        }
                    }
                    if (range.To != null)
                    {
                        // 10-20, return the range.
                        if (range.From != null)
                        {
                            long? rangeLength = range.To - range.From;
                            int length = (int)Math.Min(rangeLength.Value, fileStream.Length - range.From.Value);
                            byte[] buffer = new byte[length];
                            fileStream.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                        // -20, return the bytes from beginning to the specified value.
                        else
                        {
                            int length = (int)Math.Min(range.To.Value, fileStream.Length);
                            byte[] buffer = new byte[length];
                            fileStream.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                    }
                    // No Range.To
                    else
                    {
                        // 10-, return from the specified value to the end of file.
                        if (range.From != null)
                        {
                            if (range.From < fileStream.Length)
                            {
                                int length = (int)(fileStream.Length - range.From.Value);
                                byte[] buffer = new byte[length];
                                fileStream.Read(buffer, 0, length);
                                responseStream.Write(buffer, 0, length);
                            }
                        }
                    }
                }
                // No Range header. Return the complete file.
                else
                {
                    fileStream.CopyTo(responseStream);
                }
                fileStream.Close();
                responseStream.Position = 0;

                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = fullContent ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
                response.Content = new StreamContent(responseStream);
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = fileNameOutput;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.Add("x-filename", fileNameOutput);
                return ResponseMessage(response);
            }
            catch (IOException ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage ExportToFile(String reportName, byte[] fileReport)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileReport)
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = reportName
                };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return result;
        }

        public IHttpActionResult GenerateExcelFromReportViewer(byte[] data, String fileNameOutput)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            MemoryStream stream = new MemoryStream(data);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileNameOutput;
            response.Content.Headers.Add("x-filename", fileNameOutput);
            return ResponseMessage(response);
        }

        public string GetEmailUsuarioLogueado()
        {
            UsuarioCidiDto usuarioCidi = UsuarioCidiFactory.ValidarUsuarioCidi();
            return usuarioCidi == null ? String.Empty : usuarioCidi.Email;
        }

        public void EnviarMail(String cuil, Boolean archivoGeneradoConExito, String nombreArchivo, String queryParams, String reportTitle)
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
            var _enviarMailQueryResult = _queryDispatcher.Dispatch<EnviarMailQuery, EnviarMailQueryResult>(_enviarMailQuery);
        }
    }
}
