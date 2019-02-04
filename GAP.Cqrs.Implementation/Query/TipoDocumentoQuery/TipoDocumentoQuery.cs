using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.TipoDocumentoQuery
{
    public class TipoDocumentoQuery : IQuery
    {
        public string TipoDocumentoId { get; set; }
        public string OrganismoEmisorId { get; set; }
        public string PaisTipoDocumentoId { get; set; }
        public string NombreTipoDocumento{ get; set; }

    }
}
