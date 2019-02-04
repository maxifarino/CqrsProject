using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.MadresBeneficiariosQuery
{
    public class MadresBeneficiariosQuery : QueryFilter
    {
        public Int32? EdadDesde { get; set; }
        public Int32? EdadHasta { get; set; }
        public Int64? PersonaJuridicaId { get; set; }
        public Int64? SalaCunaId { get; set; }
        public Int64? DepartamentoId { get; set; }
        public Int64? LocalidadId { get; set; }
        public Int64? BarrioId { get; set; }
        public String Codigo { get; set; }
        public Int64 Ubicacion { get; set; }
        public String NivelEscolaridad { get; set; }
        public String EstadoCivil { get; set; }
        public String Ocupacion { get; set; }
        public Int64 Responsable { get; set; }
        public Boolean EnviarMail { get; set; }
    }
}
