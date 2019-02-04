using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProvisionProductosQuery
{
    public class ProvisionProductosQuery : QueryFilter
    {
        public int? DiaDeCorte { get; set; }
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public int Ubicacion { get; set; }
        public float Param0a2Anios { get; set; }
        public float Param3Anios { get; set; }
        public Int64? DepartamentoId { get; set; }
        public Int64? LocalidadId { get; set; }
        public Int64? BarrioId { get; set; }
        public string Codigo { get; set; }
        public int? EdadMaxima { get; set; }
        public bool EsCE { get; set; }
        public Boolean EnviarMail { get; set; } 
    }
}
