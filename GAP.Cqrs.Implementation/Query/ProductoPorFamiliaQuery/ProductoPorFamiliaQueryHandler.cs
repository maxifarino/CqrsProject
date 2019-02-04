using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.ProvisionProductos;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProductoPorFamiliaQuery
{
    public class ProductoPorFamiliaQueryHandler : IQueryHandler<ProductoPorFamiliaQuery, ProductoPorFamiliaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public ProductoPorFamiliaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public ProductoPorFamiliaQueryResult Retrieve(ProductoPorFamiliaQuery query)
        {
            var queryResult = new ProductoPorFamiliaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<ProductoXFamiliaXSalaDto>("PR_REPORTE_PROD_X_FAMILIA (?,?,?,?,?,?,?,?,?,?,?,?)")

            .SetParameter(0, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
            .SetParameter(1, query.SalaCunaId != 0 ? query.SalaCunaId:-1 )            
            .SetParameter(2, query.Codigo)
            .SetParameter(3, query.Anio != null ? query.Anio : -1)
            .SetParameter(4, query.Mes != null ? query.Mes : -1)
            .SetParameter(5, query.DiaDeCorte != null ? query.DiaDeCorte : -1)
            .SetParameter(6, query.EdadMaxima != null ? query.EdadMaxima : -1)
            .SetParameter(7, query.DepartamentoId != null ? query.DepartamentoId : -1)
            .SetParameter(8, query.LocalidadId != null ? query.LocalidadId : -1)
            .SetParameter(9, query.BarrioId != null ? query.BarrioId : -1)
            .SetParameter(10, query.Ubicacion != 0 ? 1 : query.Ubicacion)
            .SetParameter(11, 32);


            queryResult.Provisiones = (List<ProductoXFamiliaXSalaDto>)querySession.List<ProductoXFamiliaXSalaDto>();

            return queryResult;
        }
    }
}
