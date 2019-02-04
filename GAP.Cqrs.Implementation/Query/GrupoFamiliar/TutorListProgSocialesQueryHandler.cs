using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorListProgSocialesQueryHandler : IQueryHandler<TutorListProgSocialesQuery, TutorListProgSocialesQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public TutorListProgSocialesQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public TutorListProgSocialesQueryResult Retrieve(TutorListProgSocialesQuery query)
        {

            var queryResult = new TutorListProgSocialesQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<IdNombreDto>("PR_OBTENER_PROG_SOC_INTEG(?,?,?,?)")

            .SetParameter(0, query.NumeroId)
            .SetParameter(1, query.SexoId)
            .SetParameter(2, query.CodigoPais)
            .SetParameter(3, query.NumeroDocumento);
            

            queryResult.ListProgramaSocial = (List<IdNombreDto>)querySession.List<IdNombreDto>();


            return queryResult;
        }
    }
}
