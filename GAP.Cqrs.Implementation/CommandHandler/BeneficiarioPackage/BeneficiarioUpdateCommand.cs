using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.BeneficiarioPackage
{
    public class BeneficiarioUpdateCommand : ICommand
    {
        public Beneficiario Beneficiario { get; set; }
        public int UsuarioLogueadoId { get; set; }
        public int ProgramaAplicacionId { get; set; }
    }
}