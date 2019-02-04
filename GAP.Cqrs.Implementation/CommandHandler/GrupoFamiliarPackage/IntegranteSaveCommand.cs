using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;

namespace GAP.Cqrs.Implementation.CommandHandler.GrupoFamiliarPackage
{
    public class IntegranteSaveCommand : ICommand
    {
        public Beneficiario Beneficiario { get; set; }
        public int UsuarioLogueadoId { get; set; }
        public int ProgramaAplicacionId { get; set; }
    }
}
