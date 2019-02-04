using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class CursoDto
    {
        public Int64 IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDias { get; set; }
        public double HorasPorDia { get; set; }
        public string IdZona { get; set; }
        public int Porcentaje { get; set; }
        public string Ente { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public string Cargos { get; set; }
        public string Salas { get; set; }
        public string ComentarioBaja { get; set; }
        public bool Iniciado { get { return ((FechaInicio <= DateTime.Now) ? true : false); } }
		public Decimal CantidadInscriptos { get; set; }        public string TieneAsistencia { get; set; }
    }
}
