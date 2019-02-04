using GAP.Base.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class UsuarioDtoMocked
    {
        private List<UsuarioCidiDto> _getListMocked;

        private static UsuarioDtoMocked _UsuarioDtoMocked;
        public static UsuarioDtoMocked GetInstance()
        {
            _UsuarioDtoMocked = _UsuarioDtoMocked == null ? new UsuarioDtoMocked() : _UsuarioDtoMocked;

            return _UsuarioDtoMocked;
        }

        private UsuarioDtoMocked()
        {
            _getListMocked = new List<UsuarioCidiDto>();
        }

        public List<UsuarioCidiDto> GetMocked()
        {
            _getListMocked.Clear();
            return _getListMocked;
        }

        public UsuarioCidiDto GetUsuarioById(string cuil)
        {
            if(cuil.Equals("20335417853")){

                //Usuario registrado a Salas Cuna

                return new UsuarioCidiDto
                {
                    Id = 3,
                    Nombre = "Alvaro",
                    Apellido = "Diaz Romero",
                    Cuil = "20335417853"
                };
            }
            else
            {
                //Usuario no registrado a Salas Cuna

                return null;
            }
            
        }
    }
}
