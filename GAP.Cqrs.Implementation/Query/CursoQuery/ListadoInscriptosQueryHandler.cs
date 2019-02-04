using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.Clase;
using GAP.Cqrs.Implementation.Query.Personal;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class ListadoInscriptosQueryHandler : IQueryHandler<ClaseByCursoQuery, ListadoInscriptosQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ListadoInscriptosQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ListadoInscriptosQueryResult Retrieve(ClaseByCursoQuery query)
        {
            var queryResult = new ListadoInscriptosQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalListadoDto>("PR_OBTENER_LISTADO_CURSO (?)")

            .SetParameter(0, query.CursoId);

            queryResult.ListPersonal = (List<PersonalListadoDto>)querySession.List<PersonalListadoDto>();

            return queryResult;
        }
    }
}
