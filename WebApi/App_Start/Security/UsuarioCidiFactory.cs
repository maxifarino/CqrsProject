using GAP.Base.Dto.Usuario;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using GAP.CqrsCore.Querys;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.App_Start.Security
{
    public class UsuarioCidiFactory
    {

        public static UsuarioCidiDto ValidarUsuarioCidi()
        {
            //Verifico usuario logueado a través de CIDI.
            var cookie = HttpContext.Current.Request.Cookies["CiDi"];
            if (cookie != null)
            {
                ObtenerUsuarioActivoQuery query = new ObtenerUsuarioActivoQuery();
                query.Hash = cookie.Value.ToString();
                QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
                ObtenerUsuarioActivoResult queryResult = _queryDispatcher.Dispatch<ObtenerUsuarioActivoQuery, ObtenerUsuarioActivoResult>(query);
                return queryResult.UsuarioDto;
            }
            return null;
        }

    }
}