using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage
{
   public class UsuarioDeleteCommand:ICommand
    {
       public Usuario usuario { get; set; }
    }
}
