using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query
{
    public class PersonByNameLastNameQuery : IQuery
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
