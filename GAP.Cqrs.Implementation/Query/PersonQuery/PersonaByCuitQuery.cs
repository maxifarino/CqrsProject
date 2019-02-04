using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonQuery
{
    public class PersonaByCuitQuery : IQuery
    {
        public string Cuit { get; set; }
    }
}
