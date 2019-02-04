using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalInscriptoByFilterQuery : QueryFilter
    {
        public int? CursoId { get; set; }
        public int? ClaseId { get; set; }
        public int? Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
