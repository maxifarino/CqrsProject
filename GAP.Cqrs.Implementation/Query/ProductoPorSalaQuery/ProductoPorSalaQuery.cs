using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProductoPorSalaQuery
{
    public class ProductoPorSalaQuery:IQuery
    {
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public int? PersonaJuridicaId { get; set; }
        public string SalaCunaId { get; set; }
        public int? DiaDeCorte { get; set; }
        public int? UbicacionId { get; set; }
        public int? DepartamentoId { get; set; }
        public int? LocalidadId { get; set; }
        public int? BarrioId { get; set; }
        public List<ProductosPorSalaDto> LstProductoPorSala { get; set; }
        public int? EdadMaxima { get; set; }
        public string StringSalasCuna { get; set; }
        public string Codigo { get; set; }
        
    }
}
