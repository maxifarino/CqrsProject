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
   public class StateProvinciaOrigen:IStateOrigen
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static StateProvinciaOrigen _stateProvincia;
        public static StateProvinciaOrigen GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateProvincia == null)
                _stateProvincia = new StateProvinciaOrigen(repositoryLocalScheme);

            return _stateProvincia;
        }

        private StateProvinciaOrigen(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public LugarDeOrigenQueryResult ExecuteState(LugarDeOrigenQuery query)
        {
            LugarDeOrigenQueryResult result = new LugarDeOrigenQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<ProvinciasDto>("PR_OBTENER_PROVINCIAS(?)");

            querySession.SetParameter(0, query.PaisId);

            result.Provincias = (List<ProvinciasDto>)querySession.List<ProvinciasDto>();

            return result;
        }
    }
}
