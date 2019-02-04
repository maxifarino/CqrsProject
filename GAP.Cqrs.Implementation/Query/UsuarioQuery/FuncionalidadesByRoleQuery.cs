using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query
{
    public class FuncionalidadesByRoleQuery : IQuery
    {
        public int RolId { get; set; } 
    }
}
