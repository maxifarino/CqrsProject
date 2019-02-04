using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Base.Dto.AdministrarRequisitos;
using GAP.Base;

namespace GAP.Cqrs.Implementation.QueryHandler.AdministrarRequisitos
{
    public class RequisitosDeSalaCunaQueryHandler : IQueryHandler<RequisitosDeSalaByFiltersQuery, RequisitosDeSalaCunaQueryResult>
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public RequisitosDeSalaCunaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public RequisitosDeSalaCunaQueryResult Retrieve(RequisitosDeSalaByFiltersQuery query)
         {
             var queryResult = new RequisitosDeSalaCunaQueryResult();

             var querySession = _repositryLocalScheme.Session.CallFunction<RequisitosDeSalaCunaDto>("PR_OBTENER_REQS_SC (?)")

             .SetParameter(0, query.IdSalaCuna);
            

             queryResult.RequisitosDeSalaCunaDto = (List<RequisitosDeSalaCunaDto>)querySession.List<RequisitosDeSalaCunaDto>();

             return queryResult;
         }


    }
}
