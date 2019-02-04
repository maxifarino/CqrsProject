using GAP.CqrsCore.Querys;
using GAP.Repository.Cidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class EnviarMailQueryResult : IQueryResult
    {
        public String Mensaje { get; set; }
    }
}
