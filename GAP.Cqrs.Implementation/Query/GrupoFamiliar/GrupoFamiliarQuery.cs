using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class GrupoFamiliarQuery : QueryFilter
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public Int64? NroDocumento { get; set; }
        public bool DadosBaja { get; set; }
        public Int64 DepartamentoId { get; set; }
        public Int64 LocalidadId { get; set; }
        public Int64 BarrioId { get; set; }
        public Int64 SituacionCritica { get; set; }
        public int Reporte { get; set; }
        public string Entidad { get; set; }
        public string  SalaCuna { get; set; }
        public string Codigo { get; set; }
        public bool RecibeOtroPS { get; set; }
        public Boolean EnviarMail { get; set; } 

    }
}
