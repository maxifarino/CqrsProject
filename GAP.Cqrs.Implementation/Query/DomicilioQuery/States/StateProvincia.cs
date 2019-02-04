using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.Domicilio.States
{
    public class StateProvincia: IStateDomicilio
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static StateProvincia _stateProvincia;
        public static StateProvincia GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateProvincia == null)
                _stateProvincia = new StateProvincia(repositoryLocalScheme);

            return _stateProvincia;
        }

        private StateProvincia(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            DomicilioQueryResult result = new DomicilioQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_PROVINCIAS(?)");

            querySession.SetParameter(0, query.PaisId);

            result.Provincias = (List<IdNombreDto>)querySession.List<IdNombreDto>();

            return result;
        }
    }
}
