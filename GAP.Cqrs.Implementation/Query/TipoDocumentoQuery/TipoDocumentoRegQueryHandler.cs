using GAP.Base.Dto.AdministrarTipoDocumento;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.TipoDocumentoQuery
{
    public class TipoDocumentoRegQueryHandler: IQueryHandler<TipoDocumentoQuery, TipoDocumentoRegQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public TipoDocumentoRegQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public TipoDocumentoRegQueryResult Retrieve(TipoDocumentoQuery query)
        {
            var queryResult = new TipoDocumentoRegQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<TipoDocumentoDto>("PR_OBTENER_TIPO_DOCUMENTO_REG()");

            queryResult.TipoDocumento = (List<TipoDocumentoDto>)querySession.List<TipoDocumentoDto>();



            return queryResult;
        }
    }
}
