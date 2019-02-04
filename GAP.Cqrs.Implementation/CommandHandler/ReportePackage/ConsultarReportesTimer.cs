using System;
using System.Threading.Tasks;
using System.Timers;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    public class ConsultarReportesTimer
    {
        public static void Init()
        {
            GeneradorReporte.CancelarProcesosEjecutandose();
            var timer = new Timer(180000); //1000*60*3=180000 => tres minutos
            timer.Elapsed += async (sender, e) => await HandleTimerAsync();
            timer.Start();
        }

        private static Task<string> HandleTimerAsync()
        {
            return Task.Run<string>(() => HandleTimer());
        }

        private static string HandleTimer()
        {
            GeneradorReporte generadorReportes = new GeneradorReporte();
            generadorReportes.GenerarReporte();
            return String.Empty;
        }
    }
}
