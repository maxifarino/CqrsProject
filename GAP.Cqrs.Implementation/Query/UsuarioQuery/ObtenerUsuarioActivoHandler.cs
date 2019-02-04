using GAP.Base.Dto.Usuario;
using GAP.Cqrs.Implementation.QueryResult;
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
    public class ObtenerUsuarioActivoHandler : IQueryHandler<ObtenerUsuarioActivoQuery, ObtenerUsuarioActivoResult>
    {
        private RepositoryCidi _repositryCidi;
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        ObtenerUsuarioActivoResult _obtenerUsuarioActivoResult;


        public ObtenerUsuarioActivoHandler(RepositoryCidi repositoryCidi, RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryCidi = repositoryCidi;
            _repositryLocalScheme = repositryLocalScheme;
        }

        public ObtenerUsuarioActivoResult Retrieve(ObtenerUsuarioActivoQuery query)
        {
            _obtenerUsuarioActivoResult = new ObtenerUsuarioActivoResult();            
            UsuarioCidiDto usuarioCidiDto = _repositryCidi.ObtenerUsuarioActivo(query.Hash);
            _obtenerUsuarioActivoResult.UsuarioDto = usuarioCidiDto;
            return _obtenerUsuarioActivoResult;
        }
    }
}
