using CiDi.SDK.Common;
using GAP.Base.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Repository.Cidi
{
    public interface  IRepositoryCidi
    {
        UsuarioCidiDto ObtenerUsuarioActivo(string hash);
    }
}
