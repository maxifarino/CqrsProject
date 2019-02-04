
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.PersonaFisicaQuery
{
    public class PersonaFisicaByFilterQuery : IQuery
    {
        public string SexoId { get;set; }
        public string Documento { get; set; }
        public string TipoDocumentoId { get; set; }

    }
}
