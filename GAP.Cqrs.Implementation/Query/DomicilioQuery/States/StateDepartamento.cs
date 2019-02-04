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
    public class StateDepartamento : IStateDomicilio
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static StateDepartamento _stateDepartamento;

        public static StateDepartamento GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateDepartamento == null)
                _stateDepartamento = new StateDepartamento(repositoryLocalScheme);

            return _stateDepartamento;
        }

        private StateDepartamento(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            DomicilioQueryResult result=new DomicilioQueryResult();

            var query1 = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_DEPARTAMENTOS_STR(?)");
            query1.SetParameter(0, StringHelper.devolverStringUpperCase(query.Nombre));

            result.Departamentos=(List<IdNombreDto>) query1.List<IdNombreDto>();

            return result;
        }
    }
}
