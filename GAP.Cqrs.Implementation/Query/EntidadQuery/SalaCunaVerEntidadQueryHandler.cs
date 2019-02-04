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

namespace GAP.Cqrs.Implementation.Query.EntidadQuery
{
    public class SalaCunaVerEntidadQueryHandler : IQueryHandler<SalaCunaVerEntidadQuery, SalaCunaVerEntidadQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public SalaCunaVerEntidadQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public SalaCunaVerEntidadQueryResult Retrieve(SalaCunaVerEntidadQuery query)
        {
            var queryResult = new SalaCunaVerEntidadQueryResult();

            var querysession = _repositryLocalScheme.Session.CallFunction<SalaCunaVerEntidadDto>("PR_OBTENER_SALAS_DE_ENTIDAD(?,?,?)")

            .SetParameter(0, query.Cuil)
            .SetParameter(1, query.IdSede)
            .SetParameter(2, GlobalVars.IdApplication);

            var resultado = (List<SalaCunaVerEntidadDto>)querysession.List<SalaCunaVerEntidadDto>();
            queryResult.SalaCunaVerEntidadDto = resultado;

            return queryResult;
        }
    }
}
