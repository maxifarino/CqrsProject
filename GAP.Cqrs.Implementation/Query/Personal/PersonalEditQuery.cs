using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonQuery
{
    public class PersonalEditQuery : IQuery
    {
        public int IdPersonal{ get; set; }
        public int IdSalita { get; set; }
    
    }
}
