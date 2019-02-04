using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalVerQuery : IQuery
    {
        public int IdAsignacionPersonal{ get; set; }
        public int IdPersonal { get; set; }
    }
}
