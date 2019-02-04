using GAP.CqrsCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class InscripcionDeleteCommand : ICommand
    {
        public int? PersonalId { get; set; }
        public int? CursoId { get; set; }
        public int UsuarioLogueadoId { get; set; }
        public int ProgramaAplicacionId { get; set; }
    }
}
