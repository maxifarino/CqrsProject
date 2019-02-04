using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.Administrar_Socio_Ambiental
{
   public class SocioAmbientalSaveCommand:ICommand
    {

       public int ProgramaAplicacionId { get; set; }
       public SocioAmbiental SocioAmbiental { get; set; }
       public int UsuarioLogueadoId { get; set; }
    }
}
