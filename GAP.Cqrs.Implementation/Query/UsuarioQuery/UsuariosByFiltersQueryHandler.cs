using GAP.Base.Dto.Usuario;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class UsuariosByFiltersQueryHandler : IQueryHandler<UsuariosByFiltersQuery, UsuariosByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public UsuariosByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public UsuariosByFiltersQueryResult Retrieve(UsuariosByFiltersQuery query)
        {
            var queryResult = new UsuariosByFiltersQueryResult();
            var querySession = _repositryLocalScheme.Session.CallFunction<UsuarioDto>("PR_OBTENER_USUARIOS_FILTER (?,?,?,?,?,?)")
                .SetParameter(0, query.Cuil)
                .SetParameter(1, query.Rol == null ? -1 : query.Rol)
                .SetParameter(2, query.Nombre)
                .SetParameter(3, query.Apellido)
                .SetParameter(4, query.PaginationFrom)
                .SetParameter(5, query.PaginationTo);

            queryResult.UsuariosDto = (List<UsuarioDto>)querySession.List<UsuarioDto>();
           
            return queryResult;
        }
    }
}
