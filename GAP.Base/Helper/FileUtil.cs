using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class FileUtil
    {

        public static String GenerarRutaArchivoEnDirectorioTemporal(String fileNameWithFormat)
        {
            return new StringBuilder()
            .Append(ContextSingleton.Instance.TempReportsPath)
            .Append(fileNameWithFormat)
            .ToString();
        }

        public static String GenerarNombreArchivoConFecha(String fileName, String format)
        {
            return new StringBuilder()
            .Append(fileName)
            .Append("_")
            .Append(DateTime.Now.ToString("yyyyMMddHHmmss"))
            .Append(".")
            .Append(format)
            .ToString();
        }
        
        public static String GenerarLinkDeDescarga(String fileName)
        {
            return new StringBuilder()
            .Append(ContextSingleton.Instance.BaseUrl)
            .Append(GlobalVars.ApiDescargarReporte)
            .Append("?fileName=")
            .Append(fileName)
            .ToString();
        }

        public static void GetMemoryStream()
        {

            /*MemoryStream responseStream = new MemoryStream();
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
            responseStream.Position = 0;*/

        }
    }
}
