using GAP.Base.Dto;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProductoPorSalaQuery
{
    public class ProductoPorSalaQueryHandler : IQueryHandler<ProductoPorSalaQuery, ProductoPorSalaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ProductoPorSalaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ProductoPorSalaQueryResult Retrieve(ProductoPorSalaQuery query)
        {
            var queryResult = new ProductoPorSalaQueryResult();
        
                var querySession = _repositryLocalScheme.Session.CallFunction<ProductosPorSalaDto>("PR_REPORTE_PROD_X_SALA (?,?,?,?,?,?,?,?,?,?,?)")

                .SetParameter(0, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                .SetParameter(1, query.SalaCunaId != null ? query.SalaCunaId : null)
                .SetParameter(2, query.Codigo)
                .SetParameter(3, query.Anio != null ? query.Anio : -1)
                .SetParameter(4, query.Mes != null ? query.Mes : -1)
                .SetParameter(5, query.DiaDeCorte != null ? query.DiaDeCorte : -1)
                .SetParameter(6, query.DepartamentoId != null ? query.DepartamentoId : -1)
                .SetParameter(7, query.LocalidadId != null ? query.LocalidadId : -1)
                .SetParameter(8, query.BarrioId != null ? query.BarrioId : -1)
                .SetParameter(9, query.UbicacionId != null ? query.UbicacionId : 0)
                .SetParameter(10, query.EdadMaxima != null ? query.EdadMaxima : 11);


                queryResult.ProductoPorSalaResults = (List<ProductosPorSalaDto>)querySession.List<ProductosPorSalaDto>();

            return queryResult;

        }


    }
}
