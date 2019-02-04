using GAP.Base;
using GAP.Base.Dto.AdministrarTipoDocumento;
using GAP.Cqrs.Implementation.Query.TipoDocumentoQuery;
using GAP.Cqrs.Implementation.QueryResult.TipoDocumentoResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.TipoDocumentoQueryHandler
{
    public class TipoDocumentoQueryHandler : IQueryHandler<TipoDocumentoQuery, TipoDocumentoQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public TipoDocumentoQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        public TipoDocumentoQueryResult Retrieve(TipoDocumentoQuery query)
        {
            var queryResult = new TipoDocumentoQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<TipoDocumentoDto>("PR_OBTENER_TIPO_DOCUMENTO()");

            queryResult.TipoDocumento = (List<TipoDocumentoDto>)querySession.List<TipoDocumentoDto>();



            return queryResult;
        }
    }
}
