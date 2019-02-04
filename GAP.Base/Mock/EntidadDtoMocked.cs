using GAP.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class EntidadDtoMocked
    {
        private List<EntidadDto> _getListMocked;

        private static EntidadDtoMocked _EntidadDtoMocked;
        public static EntidadDtoMocked GetInstance()
        {
            _EntidadDtoMocked = _EntidadDtoMocked == null ? new EntidadDtoMocked() : _EntidadDtoMocked;

            return _EntidadDtoMocked;
        }

        private EntidadDtoMocked()
        {
            _getListMocked = new List<EntidadDto>();
        }

        public List<EntidadDto> GetMocked()
        {
            _getListMocked.Clear();

            List<EntidadDto> lista = new List<EntidadDto>();

            EntidadDto p1 = new EntidadDto()
            {
                Cuit = "321",
                FormaJuridica = "sadsds",
                NombreFantasia = "saddsd",
                RazonSocial = "dadwadwa"
            };

            EntidadDto p2 = new EntidadDto()
            {
                Cuit = "123",
                FormaJuridica = "sadsds",
                NombreFantasia = "saddsd",
                RazonSocial = "dadwadwa"
            };

            lista.Add(p1);
            lista.Add(p2);

            _getListMocked = lista;

            return _getListMocked;
        }

        public List<EntidadComboDto> GetAllMocked()
        {
            List<EntidadComboDto> lista = new List<EntidadComboDto>();

            EntidadComboDto p1 = new EntidadComboDto()
            {
                PersonaJuridicaId = 1,
                NombrePersonaJuridica = "Entidad 1"
            };

            EntidadComboDto p2 = new EntidadComboDto()
            {
                PersonaJuridicaId = 2,
                NombrePersonaJuridica = "Entidad 2"
            };

            EntidadComboDto p3 = new EntidadComboDto()
            {
                PersonaJuridicaId = 3,
                NombrePersonaJuridica = "Entidad 3"
            };

            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);
            return lista;
        }
    }
}
