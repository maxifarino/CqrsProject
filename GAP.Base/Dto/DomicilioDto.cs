using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class DomicilioDto
    {
        public Int64 LocalidadId { get; set; }
        public Int64 DepartamentoId { get; set; }
        public Int64 BarrioId { get; set; }
        public Int64 TipoCalleId { get; set; }
        public Int64? CalleId { get; set; }
        public string Direccion { get; set; }
        public Int64 Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Torre { get; set; }
        public string Manzana { get; set; }
        public string Parcela { get; set; }
        public string LatitudString { get; set; }
        public string LongitudString { get; set; }
        public Double Latitud { get { return (String.IsNullOrEmpty(LatitudString) ? 0.0 : Double.Parse(LatitudString)); } }
        public Double Longitud { get { return (String.IsNullOrEmpty(LongitudString) ? 0.0 : Double.Parse(LongitudString)); } }
        
    }
}
