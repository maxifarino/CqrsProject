using GAP.Base.Enumerations;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.DomicilioQuery
{
    public class DomicilioByFilterQuery : IQuery
    {
        public DomicilioStateEnum StateDomicilio { get; set; }

        public int? DepartamentoId { get; set; }
        public int? LocalidadId { get; set; }
        public int? TipoCalleId { get; set; }
        public string ProvinciaId { get; set; }
        public string PaisId { get; set; }
        public string IdDomicilio { get; set; }
        public string Nombre { get; set; }
    }
}


