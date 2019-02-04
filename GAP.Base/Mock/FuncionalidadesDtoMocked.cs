using GAP.Base.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class FuncionalidadesDtoMocked
    {
        private List<FuncionalidadDto> _getListMocked;

        private static FuncionalidadesDtoMocked _FuncionalidadesDtoMocked;
        public static FuncionalidadesDtoMocked GetInstance()
        {
            _FuncionalidadesDtoMocked = _FuncionalidadesDtoMocked == null ? new FuncionalidadesDtoMocked() : _FuncionalidadesDtoMocked;

            return _FuncionalidadesDtoMocked;
        }

        private FuncionalidadesDtoMocked()
        {
            _getListMocked = new List<FuncionalidadDto>();
        }

        public List<FuncionalidadDto> GetListMocked(Int64 cuil)
        {
            _getListMocked.Clear();

            if (cuil == 11999999991)
            {
                _getListMocked = new List<FuncionalidadDto>
                {
                    new FuncionalidadDto{ Descripcion = "Entidades", Path = "/Entidad", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Obtener funcionalidades", Path = "/Entidad/GetEntidadByFilter", EsPagina = "F", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Crear entidades", Path = "/Entidad/Create", EsPagina = "F", Role = "Administrador"},                    
                    new FuncionalidadDto{ Descripcion = "Salas Cuna", Path = "/SalaCuna", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Beneficiarios", Path = "/SalaCuna", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "TablasSatelites", Path = "/TablasSatelites/GetTablaSatelites", EsPagina = "F", Role = "Administrador"},
                };
            }
            else if (cuil == 11111111111)
            {
                _getListMocked = new List<FuncionalidadDto>
                {
                    new FuncionalidadDto{ Descripcion = "Entidades", Path = "/Entidad", EsPagina = "true", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Obtener funcionalidades", Path = "/Entidad/GetEntidadByFilter", EsPagina = "false", Role = "Administrador"}
                };
            }
            else
            {
                _getListMocked = new List<FuncionalidadDto>
                {
                    new FuncionalidadDto{ Descripcion = "Entidade", Path = "/Entidad", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Obtener funcionalidades", Path = "/Entidad/GetEntidadByFilter", EsPagina = "F", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Combo entidades", Path = "/Entidad/GetAll", EsPagina = "F", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Crear entidades", Path = "/Entidad/Create", EsPagina = "F", Role = "Administrador"},                    
                    new FuncionalidadDto{ Descripcion = "Salas Cuna", Path = "/SalaCuna", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Beneficiarios", Path = "/SalaCuna", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "Reporte provisión productos", Path = "/ReporteProvisionProductos", EsPagina = "S", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "GenerarReporteProvisionProductos", Path = "/Reporte/GenerarReporteProvisionProductos", EsPagina = "F", Role = "Administrador"},
                    new FuncionalidadDto{ Descripcion = "TablasSatelites", Path = "/TablasSatelites/GetTablaSatelites", EsPagina = "F", Role = "Administrador"},
                };
            }

            return _getListMocked;
        }

        public List<FuncionalidadDto> GetListMocked()
        {

            _getListMocked = new List<FuncionalidadDto>
            {
                new FuncionalidadDto{ Descripcion = "Entidades", Path = "/Entidad", EsPagina = "true", Role = "Administrador"},
                new FuncionalidadDto{ Descripcion = "Obtener funcionalidades", Path = "/Entidad/GetEntidadByFilter", EsPagina = "false", Role = "Administrador"},
                new FuncionalidadDto{ Descripcion = "Crear entidades", Path = "/Entidad/Create", EsPagina = "false", Role = "Administrador"},                    
                new FuncionalidadDto{ Descripcion = "Salas Cuna", Path = "/SalaCuna", EsPagina = "true", Role = "Administrador"},
                new FuncionalidadDto{ Descripcion = "Beneficiarios", Path = "/SalaCuna", EsPagina = "true", Role = "Administrador"},
            };

            return _getListMocked;
        }
    }
}
