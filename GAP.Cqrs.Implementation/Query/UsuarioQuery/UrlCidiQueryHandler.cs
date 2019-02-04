using GAP.Base;
using GAP.CqrsCore.Querys;
using GAP.Repository.Cidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class UrlCidiQueryHandler : IQueryHandler<UrlCidiQuery, UrlCidiQueryResult>
    {
        private RepositoryCidi _repositryCidi;

        UrlCidiQueryResult _UrlCidiQueryResult;


        public UrlCidiQueryHandler(RepositoryCidi repositoryCidi)
        {
            _repositryCidi = repositoryCidi;
        }

        public UrlCidiQueryResult Retrieve(UrlCidiQuery query)
        {
            _UrlCidiQueryResult = new UrlCidiQueryResult();

            _UrlCidiQueryResult.UrlCidi = GlobalVars.CiDiUrl;
            _UrlCidiQueryResult.UrlCidiLogout = GlobalVars.CiDiUrlCerrarSesion;
            _UrlCidiQueryResult.UrlCidiLogin = GlobalVars.CiDiUrlIniciarSesion;

            return _UrlCidiQueryResult;
        }
    }
}
