using GAP.Base.Dto;
using GAP.Base.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class TablaSateliteMocked
    {
        private List<IdNombreDto> _getListMocked;

        private static TablaSateliteMocked _TablaSateliteMocked;
        public static TablaSateliteMocked GetInstance()
        {
            _TablaSateliteMocked = _TablaSateliteMocked == null ? new TablaSateliteMocked() : _TablaSateliteMocked;

            return _TablaSateliteMocked;
        }

        private TablaSateliteMocked()
        {
            _getListMocked = new List<IdNombreDto>();
        }

        

        public List<IdNombreDto> GetMocked(TablaSateliteEnum tablaSateliteEnum)
        {
            _getListMocked.Clear();

            switch (tablaSateliteEnum)
            {
                case TablaSateliteEnum.SEXO:
                    AddSexoMocked();
                    break;
                case TablaSateliteEnum.ESTADO_SALACUNA:
                    AddSexoMocked();
                    break;
                default:
                    AddDefaultMocked();
                    break;
            }
            return _getListMocked; 
        }

        private void AddDefaultMocked()
        {
            _getListMocked.Add(new IdNombreDto()
            {
                Id = 1,
                Nombre = "valor_1"
            });
            _getListMocked.Add(new IdNombreDto()
            {
                Id = 2,
                Nombre = "valor_2"
            });
        }

        private void AddSexoMocked()
        {            
            _getListMocked.Add(new IdNombreDto()
            {
                Id = 1,
                Nombre = "FEMENINO"
            });
            _getListMocked.Add(new IdNombreDto()
            {
                Id = 2,
                Nombre = "MASCULINO"
            });
        }
    }
}
