using GAP.Base;
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
    public class StateLocalidadOrigen:IStateOrigen
    {
           private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static StateLocalidadOrigen _stateLocalidad;
        public static StateLocalidadOrigen GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateLocalidad == null)
                _stateLocalidad = new StateLocalidadOrigen(repositoryLocalScheme);

            return _stateLocalidad;
        }

        private StateLocalidadOrigen(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public LugarDeOrigenQueryResult ExecuteState(LugarDeOrigenQuery query)
        {
            LugarDeOrigenQueryResult result = new LugarDeOrigenQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_LOCALIDADES(?)");

            querySession.SetParameter(0, query.DepartamentoId);

            result.Localidades = (List<IdNombreDto>)querySession.List<IdNombreDto>();

            return result;
        }
    }
}
