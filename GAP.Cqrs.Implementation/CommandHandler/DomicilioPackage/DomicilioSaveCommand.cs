using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.DomicilioEntity
{
    public class DomicilioSaveCommand : ICommand
    {
        public Domicilio Domicilio { get; set; }
    }
}

