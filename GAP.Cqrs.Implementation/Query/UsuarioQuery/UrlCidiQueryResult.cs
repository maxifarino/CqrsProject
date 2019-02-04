using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class UrlCidiQueryResult : IQueryResult
    {
        public string UrlCidi { get; set; }

        public string UrlCidiLogout { get; set; }

        public string UrlCidiLogin { get; set; }
    }
}
