using GAP.Base.Dto.Reportes;
using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.ReporteQuery;
using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    public class ActualizarReporteCommand : ICommand
    {
        public int? IdUsuario { get; set; }
        public int? IdProcesoCola { get; set; }
        public int? IdEstado { get; set; }
        public String NombreProceso { get; set; }
        public String StringProceso { get; set; }         
    }
}
