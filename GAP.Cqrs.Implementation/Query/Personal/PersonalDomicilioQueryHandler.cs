using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalDomicilioQueryHandler : IQueryHandler<PersonalDomicilioQuery, PersonalDomicilioQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalDomicilioQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public PersonalDomicilioQueryResult Retrieve(PersonalDomicilioQuery query)
        {
            var queryResult = new PersonalDomicilioQueryResult();

            
                var querySession = _repositryLocalScheme.Session.CallFunction<DomicilioIdDto>("PR_OBTENER_DOMICILIO_PERSONAL(?,?,?,?)")

                    .SetParameter(0, query.NumeroId)
                    .SetParameter(1, query.SexoId)
                    .SetParameter(2, query.CodigoPais)
                    .SetParameter(3, query.NumeroDocumento);

                //queryResult.PersonalDto = (List<PersonalDto>)querySession.List<PersonalDto>();

              queryResult.DomicilioId = (DomicilioIdDto)querySession.UniqueResult();


              var querySession3 = _repositryLocalScheme.Session.CallFunction<PersonalRequisitosDto>("PR_OBTENER_REQS_PER_BY_PERS (?,?,?,?)")

             .SetParameter(0, query.NumeroDocumento)
             .SetParameter(1, query.NumeroId)
             .SetParameter(2, query.SexoId)
             .SetParameter(3, query.CodigoPais);

              queryResult.requisitos = (List<PersonalRequisitosDto>)querySession3.List<PersonalRequisitosDto>();



              var query2 = _repositryLocalScheme.Session.CallFunction("PR_VALIDAR_CONFLICTIVA(?,?,?,?)")
             .SetParameter(0, query.NumeroDocumento)
             .SetParameter(1, query.NumeroId)
             .SetParameter(2, query.SexoId)
             .SetParameter(3, query.CodigoPais);
         
           queryResult.esConflictiva =  query2.UniqueResult().ToString();
       




            return queryResult;
        }
    }
}
