using GAP.CqrsCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class RegistrarAsistenciaCommand: ICommand
    {
        public int UsuarioLogueadoId { get; set; }
        public int ProgramaAplicacionId { get; set; }
        public string IdsPersonal { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public DateTime FechaInicio { get; set; }
        
    }
}

