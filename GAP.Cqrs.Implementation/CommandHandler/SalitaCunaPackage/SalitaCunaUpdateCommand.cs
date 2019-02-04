using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalitaCunaPackage
{
    public class SalitaCunaUpdateCommand :ICommand
    {
        public SalitaCuna SalitaCuna { get; set; }
        public int UsuarioLogueadoId { get; set; }
    }
}
