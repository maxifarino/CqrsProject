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
    public class RequisitosReporteSalaCunaQueryHandler : IQueryHandler<RequisitosDeSalaByFiltersQuery, RequisitosReporteSalaCunaQueryResult>
    {
         private readonly RepositoryLocalScheme _repositryLocalScheme;

         public RequisitosReporteSalaCunaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

         public RequisitosReporteSalaCunaQueryResult Retrieve(RequisitosDeSalaByFiltersQuery query)
         {
             var queryResult = new RequisitosReporteSalaCunaQueryResult();

             var querySession = _repositryLocalScheme.Session.CallFunction<RequisitosReporteSalaCunaDto>("PR_OBTENER_REQS_PRESENTADOS (?) ")

             .SetParameter(0, query.IdSalaCuna);


             queryResult.RequisitosPresentadosDto = (List<RequisitosReporteSalaCunaDto>)querySession.List<RequisitosReporteSalaCunaDto>();

             return queryResult;
         }


    }
}
