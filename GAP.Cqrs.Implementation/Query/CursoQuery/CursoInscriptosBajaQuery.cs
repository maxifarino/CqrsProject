using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.CursoQuery
{
    public class CursoInscriptosBajaQuery : IQuery
    {
        public int IdCurso { get; set; }
        public string Cargos { get; set; }
        public string Salas { get; set; }
    }
}
