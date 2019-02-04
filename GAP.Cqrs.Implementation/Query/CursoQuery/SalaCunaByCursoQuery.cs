using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class SalaCunaByCursoQuery : IQuery
    {
        public Int64 CursoId { get; set; }
    }
}
