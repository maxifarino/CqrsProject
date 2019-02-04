using GAP.Base.ResultValidation;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalAsignadoACursoQueryHandler : IQueryHandler<PersonalVerQuery, PersonalAsignadoACursoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalAsignadoACursoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonalAsignadoACursoQueryResult Retrieve(PersonalVerQuery query)
         {
             var queryResult = new PersonalAsignadoACursoQueryResult();

             var querySession = _repositryLocalScheme.Session.CallFunction("PR_PERSONAL_ASIGNADO_CURSO(?)")

             .SetParameter(0, query.IdPersonal);

             Result result = new Result();

             result.Resolve(querySession.UniqueResult());

             queryResult.PersonalAsignadoACurso = Convert.ToString(result.GetDataValue(0));

             return queryResult;
         }
    }
}
