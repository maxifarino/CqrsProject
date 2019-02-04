using GAP.Base.Dto.AdministrarTipoDocumento;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.TipoDocumentoQuery
{
    public class TipoDocumentoRegQueryResult: IQueryResult

    {
        public List<TipoDocumentoDto> TipoDocumento { get; set; }
    }
}
