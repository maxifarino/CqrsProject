using GAP.Base.Dto;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery.States
{
   public class StateDepartamentoOrigen:IStateOrigen
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



        public LugarDeOrigenQueryResult ExecuteState(LugarDeOrigenQuery query)
        {
            LugarDeOrigenQueryResult result = new LugarDeOrigenQueryResult();

            var query1 = _repositryLocalScheme.Session.CreateSQLQuery("{ call PR_OBTENER_DEPT_X_PROV(?) }")
                        .SetResultTransformer(Transformers.AliasToBean<IdNombreDto>());

            query1.SetParameter(0, query.ProvinciaId);
            result.Departamentos = (List<IdNombreDto>)query1.List<IdNombreDto>();
            return result;
        }
    }
}
