using GAP.CqrsCore.Querys;
using GAP.Repository.Cidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class EnviarMailQueryHandler : IQueryHandler<EnviarMailQuery, EnviarMailQueryResult>
    {
        private RepositoryCidi _repositryCidi;

        EnviarMailQueryResult _enviarMailQueryResult;


        public EnviarMailQueryHandler(RepositoryCidi repositoryCidi)
        {
            _repositryCidi = repositoryCidi;
        }


        public EnviarMailQueryResult Retrieve(EnviarMailQuery query)
        {
            _enviarMailQueryResult = new EnviarMailQueryResult();
            if (String.IsNullOrEmpty(query.Cuil))
                return null;
            RepositoryCidi _repositryCidi = new RepositoryCidi();
            var resultadoEmail = _repositryCidi.EnviarMailPorCuil(query.Cuil, query.Link, query.Mensaje, query.ReportTitle);
            return _enviarMailQueryResult;
        }
    }
}
