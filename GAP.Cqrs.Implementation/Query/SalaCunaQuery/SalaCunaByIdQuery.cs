using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaByIdQuery : IQuery
    {
        public Int64 IdSalaCuna { get; set; }
    }
}
