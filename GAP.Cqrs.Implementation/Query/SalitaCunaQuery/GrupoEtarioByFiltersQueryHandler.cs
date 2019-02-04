using GAP.Base;
using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalitaCunaQuery
{
    public class GrupoEtarioByFiltersQueryHandler : IQueryHandler<GrupoEtarioByFiltersQuery, GrupoEtarioByFiltersQueryResults>
    {
        public bool DeBaja = false;
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public GrupoEtarioByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public GrupoEtarioByFiltersQueryResults Retrieve(GrupoEtarioByFiltersQuery query)
        {
            var queryResult = new GrupoEtarioByFiltersQueryResults();

            var querySession = _repositryLocalScheme.Session.CallFunction<GrupoEtarioDto>("PR_OBTENER_GRUPOS_ETARIO(?) ")
                         .SetParameter(0, query.IdTipoSalita);

            queryResult.listGrupoEtario = (List<GrupoEtarioDto>)querySession.List<GrupoEtarioDto>();
           

            return queryResult;
        }
    }
}
