using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Clase
{
    public class ClaseByCursoQuery : IQuery
    {
        public int? CursoId { get; set; } 
    }
}