using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class AsistenciaPersonalByFilterQuery : QueryFilter
    {
        public Int64 CursoId { get; set; }
        public Int64 SalaCunaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
    }
}
