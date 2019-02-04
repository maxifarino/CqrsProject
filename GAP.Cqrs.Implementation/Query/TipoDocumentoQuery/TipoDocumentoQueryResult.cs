using GAP.Base.Dto;
using GAP.Base.Dto.AdministrarTipoDocumento;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.TipoDocumentoResult
{
    public class TipoDocumentoQueryResult: IQueryResult

    {
        public List<TipoDocumentoDto> TipoDocumento { get; set; }
    }
}
