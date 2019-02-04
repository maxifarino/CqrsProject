using GAP.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class PersonaFisicaMocked
    {
        private List<PersonaFisicaDto> _getListMocked;

        public static PersonaFisicaMocked _PersonaFisicaMocked;
        public static PersonaFisicaMocked GetInstance()
        {
            _PersonaFisicaMocked = _PersonaFisicaMocked == null ? new PersonaFisicaMocked() : _PersonaFisicaMocked;

            return _PersonaFisicaMocked;
        }

        private PersonaFisicaMocked()
        {
            _getListMocked = new List<PersonaFisicaDto>();
        }

        public List<PersonaFisicaDto> GetMocked()
        {
            _getListMocked.Clear();

            PersonaFisicaDto p1 = new PersonaFisicaDto()
            {
                NumeroId = 1,
                NumeroDocumento = "33555444",
                CodigoPais = "1",
                SexoId = "1",
                Nombre = "María",
                Apellido = "Diaz",
            };

            PersonaFisicaDto p2 = new PersonaFisicaDto()
            {
                NumeroId = 2,
                NumeroDocumento = "33555666",
                CodigoPais = "1",
                SexoId = "2",
                Nombre = "Pepe",
                Apellido = "Mamani",
            };

            _getListMocked.Add(p1);
            _getListMocked.Add(p2);

            return _getListMocked;
        }

    }
}
