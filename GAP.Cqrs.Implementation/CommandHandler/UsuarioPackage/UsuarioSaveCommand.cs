using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.UsuarioPackage
{
    public class UsuarioSaveCommand : ICommand
    {
        public Usuario usuario { get; set; }


    }
}
