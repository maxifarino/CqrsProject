using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query
{
    public class LoguinCidiQuery : IQuery
    {
        public string Cuil { get; set; }
        public string Password { get; set; }
    }
}
