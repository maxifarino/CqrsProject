using GAP.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    /// <summary>
    /// Timer que se ejecuta todos los días a la misma hora.
    /// Se encarga de borrar todos los archivos del directorio [GlobalVars.TemporalDirectoryPath]
    /// con antiguedad mayor a [GlobalVars.CantDiasArchivosPersistidos]
    /// </summary>
    public class RemoveTempFilesTimer
    {
        public static void Init()
        {
            Timer timer = new Timer(86400000); //1000*60*60*24=86400000 => un día
            timer.Elapsed += async (sender, e) => await HandleTimerAsync();
            timer.Start();
        }

        private static Task<string> HandleTimerAsync()
        {
            return Task.Run<string>(() => HandleTimer());
        }

        private static string HandleTimer()
        {
            string[] files = Directory.GetFiles(ContextSingleton.Instance.TempReportsPath);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                int cantDias = GlobalVars.CantDiasArchivosPersistidos;
                if (fi.CreationTime < DateTime.Now.AddDays(-cantDias))
                    fi.Delete();
            }
            return String.Empty;
        }
    }
}
