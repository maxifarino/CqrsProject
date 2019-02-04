using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryHandler.Domicilio.States;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery.States
{
    public class StateDepartamentoOrigen : IStateDomicilio
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static StateDepartamentoOrigen _stateDepartamento;

        public static StateDepartamentoOrigen GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateDepartamento == null)
                _stateDepartamento = new StateDepartamentoOrigen(repositoryLocalScheme);

            return _stateDepartamento;
        }

        private StateDepartamentoOrigen(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }



        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            DomicilioQueryResult result = new DomicilioQueryResult();

            var query1 = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_DEPT_X_PROV(?)");

            query1.SetParameter(0, query.ProvinciaId);
            result.Departamentos = (List<IdNombreDto>)query1.List<IdNombreDto>();
            return result;
        }
    }
}
