using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.DomicilioQuery
{
    public class DomicilioQueryResult : IQueryResult
    {
        
        public List<IdNombreDto> Departamentos { get; set; }
        public List<IdNombreDto> Localidades { get; set; }
        public List<IdNombreDto> Barrios { get; set; }
        public List<IdNombreDto> Calles { get; set; }
        public List<IdNombreDto> TipoCalles { get; set; }
        public List<IdNombreDto> Provincias { get; set; }
    }
}
