using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Helper;
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
    public class StateCalle
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static StateCalle _stateCalle;
        public static StateCalle GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateCalle == null)
                _stateCalle = new StateCalle(repositoryLocalScheme);

            return _stateCalle;
        }

        private StateCalle(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            DomicilioQueryResult result = new DomicilioQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_CALLES_STR(?,?,?,?)");

            querySession.SetParameter(0, query.DepartamentoId.Value);
            querySession.SetParameter(1, query.LocalidadId.Value);
            querySession.SetParameter(2, query.TipoCalleId.Value);
            querySession.SetParameter(3, StringHelper.devolverStringUpperCase(query.Nombre));

            result.Calles = (List<IdNombreDto>)querySession.List<IdNombreDto>();

            return result;
        }
    }
}
