using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.SalaCunaPackage
{
    public class SalaCunaDeleteCommand : ICommand
    {
        public SalaCuna SalaCuna { get; set; }
        public int idUsuarioLogueado { get; set; }
    }
}
