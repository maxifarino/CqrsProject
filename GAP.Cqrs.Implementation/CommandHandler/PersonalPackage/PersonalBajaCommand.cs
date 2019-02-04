using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.PersonalPackage
{
    public class PersonalBajaCommand : ICommand
    {
        public PersonalDto Personal { get; set; }
        public int idUsuarioLogueado { get; set; }
    }
}
