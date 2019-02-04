using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;




namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaReporteQuery : QueryFilter
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public bool EstadoCorrecto { get; set; }
        public bool DadosBaja { get; set; }
        public Int64? DepartamentoId{ get; set; }
        public Int64? LocalidadId { get; set; }
        public Int64? BarrioId { get; set; }
        public string Codigo {get; set; }
        public int Zona { get; set; }

    }
}
