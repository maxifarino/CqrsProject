using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.DomicilioQuery
{
    public class DomicilioEditQueryResult : IQueryResult
    {
        public DomicilioDto Domicilio { get; set; }
        public List<IdNombreDto> Localidades { get; set; }
        public List<IdNombreDto> Barrios { get; set; }
        public List<IdNombreDto> Calles { get; set; }
        public List<IdNombreDto> TipoCalles { get; set; }
    }
}
