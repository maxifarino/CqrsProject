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
    public class StateBarrio : IStateDomicilio
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static StateBarrio _stateBarrio;

        public static StateBarrio GetInstance(RepositoryLocalScheme repositoryLocalScheme)
        {
            if (_stateBarrio == null)
                _stateBarrio = new StateBarrio(repositoryLocalScheme);

            return _stateBarrio;
        }

        private StateBarrio(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public DomicilioQueryResult ExecuteState(DomicilioByFilterQuery query)
        {
            
            DomicilioQueryResult result = new DomicilioQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_BARRIOS(?)");
            querySession.SetParameter(0, query.LocalidadId.Value);
            
            result.Barrios = (List<IdNombreDto>)querySession.List<IdNombreDto>();


            querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_TIPOS_CALLE()");

            result.TipoCalles = (List<IdNombreDto>)querySession.List<IdNombreDto>();

            return result;
        }
    }
}
