using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.ProductoPorFamiliaQuery
{
    public class ProductoPorFamiliaQuery : QueryFilter
    {
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public int? PersonaJuridicaId { get; set; }
        public int SalaCunaId { get; set; }
        public float Param0a2Anios { get; set; }
        public float Param3Anios { get; set; }
        public int? DiaDeCorte { get; set; }
        public int? EdadMaxima { get; set; }
        public int? DepartamentoId { get; set; }
        public int? LocalidadId { get; set; }
        public int? BarrioId { get; set; }
        public string Codigo { get; set; }
        public int Ubicacion { get; set; }
        public Boolean EnviarMail { get; set; }
    }
}
