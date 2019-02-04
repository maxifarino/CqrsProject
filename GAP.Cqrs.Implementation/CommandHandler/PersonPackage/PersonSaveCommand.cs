using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command
{
    public class PersonSaveCommand:ICommand
    {
        public Person Person { get; set; }
    }
}
