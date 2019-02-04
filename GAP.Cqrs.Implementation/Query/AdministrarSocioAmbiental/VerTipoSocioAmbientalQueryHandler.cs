using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
    public class VerTipoSocioAmbientalQueryHandler : IQueryHandler<VerTipoSocioAmbientalQuery, VerTipoSocioAmbientalQueryResults>
    {
       
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public VerTipoSocioAmbientalQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public VerTipoSocioAmbientalQueryResults Retrieve(VerTipoSocioAmbientalQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new VerTipoSocioAmbientalQueryResults();

            var querySession = _repositryLocalScheme.Session.CallFunction<TipoSocioAmbientalDto>("PR_OBTENER_TIPO_SA ()");

            queryResult.TipoSocioAmbiental = (List<TipoSocioAmbientalDto>)querySession.List<TipoSocioAmbientalDto>();
            return queryResult;
        }

    }
}
