using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.BeneficiarioPackage
{
    public class BajaBeneficiarioCommand : ICommand
    {
        public Int64 BeneficiarioId { get; set; }
        public int UsuarioId { get; set; }
        public int ProgramaAplicacionId { get; set; }
        public string ComentarioBaja { get; set; }
        public string SalitaCunaId { get; set; }
    }
}
