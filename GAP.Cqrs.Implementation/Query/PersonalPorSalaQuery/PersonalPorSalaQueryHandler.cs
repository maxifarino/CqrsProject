using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonalPorSalaQuery
{
    public class PersonalPorSalaQueryHandler : IQueryHandler<PersonalPorSalaQuery, PersonalPorSalaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public PersonalPorSalaQueryHandler(RepositoryLocalScheme repositry)
        {
            _repositryLocalScheme = repositry;
        }


        public PersonalPorSalaQueryResult Retrieve(PersonalPorSalaQuery query)
        {
            var queryResult = new PersonalPorSalaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalPorSalaDto>("PR_CONS_REP_PERS_X_SALA (?,?,?,?,?,?,?,?)")
                        
                        .SetParameter(0, query.PersonaJuridicaId)
                        .SetParameter(1, query.SalaCunaId)
                        .SetParameter(2, query.Codigo)
                        .SetParameter(3, query.Turno != null ? query.Turno : -1)
                        .SetParameter(4, query.Conflicto == null ? "T" : query.Conflicto)
                        .SetParameter(5, query.Baja ? 'S' : 'N')
                        .SetParameter(6, query.PageNumber!=null ? query.PaginationFrom:0) 
                        .SetParameter(7, query.PageNumber!=null ? query.PaginationTo:100000);


            queryResult.PersonalPorSala = (List<PersonalPorSalaDto>)querySession.List<PersonalPorSalaDto>();

            return queryResult;
        }
    }
}
