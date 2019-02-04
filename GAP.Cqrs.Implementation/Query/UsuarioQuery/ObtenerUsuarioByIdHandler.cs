using GAP.Base.Dto.Usuario;
using GAP.CqrsCore.Querys;
using GAP.Repository.Cidi;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class ObtenerUsuarioByIdHandler : IQueryHandler<ObtenerUsuarioByIdQuery, ObtenerUsuarioByIdResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        ObtenerUsuarioByIdResult _obtenerUsuarioResult;


        public ObtenerUsuarioByIdHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }

        public ObtenerUsuarioByIdResult Retrieve(ObtenerUsuarioByIdQuery query)
        {
            _obtenerUsuarioResult = new ObtenerUsuarioByIdResult();
            var query1 = _repositryLocalScheme.Session.CallFunction<UsuarioDto>("PR_OBTENER_USUARIO_BY_ID(?)")
             .SetParameter(0, query.id);

            _obtenerUsuarioResult.UsuarioDto = query1.UniqueResult<UsuarioDto>();

            return _obtenerUsuarioResult;
        }
    }
}
