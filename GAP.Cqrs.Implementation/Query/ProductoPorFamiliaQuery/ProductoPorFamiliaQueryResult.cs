using GAP.Base.Dto;
using GAP.Base.Dto.ProvisionProductos;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProductoPorFamiliaQuery
{
    public class ProductoPorFamiliaQueryResult : IQueryResult
    {
        public List<ProductoXFamiliaXSalaDto> Provisiones { get; set; }

    }
}
