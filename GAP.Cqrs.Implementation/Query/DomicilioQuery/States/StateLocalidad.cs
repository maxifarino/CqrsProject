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
    public class StateLocalidad : IStateDomicilio
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static StateLocalidad _stateLocalidad;
        public static StateLocalidad GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateLocalidad == null)
                _stateLocalidad = new StateLocalidad(repositoryLocalScheme);

            return _stateLocalidad;
        }

        private StateLocalidad(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            DomicilioQueryResult result = new DomicilioQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_LOCALIDADES_STR(?,?,?)");

            querySession.SetParameter(0, query.DepartamentoId.Value);
            querySession.SetParameter(1, StringHelper.devolverStringUpperCase(query.Nombre));
            querySession.SetParameter(2, query.ProvinciaId);

            result.Localidades = (List<IdNombreDto>)querySession.List<IdNombreDto>();

            return result;
        }
    }
}
