using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.SalitaCunaPackage
{
   public class SalitaCunaDeleteCommand :ICommand
    {
        public SalitaCuna SalitaCuna { get; set; }
        public int UsuarioLogueadoId { get; set; }
    }
}
