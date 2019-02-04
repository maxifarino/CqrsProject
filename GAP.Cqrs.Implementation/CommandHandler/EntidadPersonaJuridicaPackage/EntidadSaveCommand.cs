using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.EntidadPersonaJuridica
{
    public class EntidadSaveCommand : ICommand
    {
        public Entidad Entidad { get; set; }
        public int idUsuarioLogueado { get; set; }
        public int ProgramaAplicacionId { get; set; }
    }

}
