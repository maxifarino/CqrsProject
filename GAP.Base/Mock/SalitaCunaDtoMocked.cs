using GAP.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class SalitaCunaDtoMocked
    {
        private List<SalitasCunaDto> _getListMocked;

        private static SalitaCunaDtoMocked _SalitaCunaDtoMocked;
        public static SalitaCunaDtoMocked GetInstance()
        {
            _SalitaCunaDtoMocked = _SalitaCunaDtoMocked == null ? new SalitaCunaDtoMocked() : _SalitaCunaDtoMocked;

            return _SalitaCunaDtoMocked;
        }

        private SalitaCunaDtoMocked()
        {
            _getListMocked = new List<SalitasCunaDto>();
        }

        public List<SalitasCunaDto> GetMocked()
        {
            _getListMocked.Clear();

            SalitasCunaDto p1 = new SalitasCunaDto()
            {
                SalitaID = 1,
                TipoSalitaId = 1,
                TurnoSalitaId = 1,
                UsuarioId = 1,
                NombreTipoSalita = "Nombre mocked 1",
                NombreDeTurno = "Nombre de turno mocked 1",
                FechaDeBaja = DateTime.Now,
                CupoSalita = "25",
                CantidadBeneficiarios = 20
            };
            _getListMocked.Add(p1);

            p1 = new SalitasCunaDto()
            {
                SalitaID = 2,
                TipoSalitaId = 1,
                TurnoSalitaId = 1,
                UsuarioId = 1,
                NombreTipoSalita = "Nombre mocked 2",
                NombreDeTurno = "Nombre de turno mocked 2",
                FechaDeBaja = DateTime.Now,
                CupoSalita = "25",
                CantidadBeneficiarios = 20
            };
            _getListMocked.Add(p1);

            p1 = new SalitasCunaDto()
            {
                SalitaID = 3,
                TipoSalitaId = 1,
                TurnoSalitaId = 1,
                UsuarioId = 1,
                NombreTipoSalita = "Nombre mocked 3",
                NombreDeTurno = "Nombre de turno mocked 3",
                FechaDeBaja = DateTime.Now,
                CupoSalita = "25",
                CantidadBeneficiarios = 20
            };            
            _getListMocked.Add(p1);

            return _getListMocked;
        }
    }
}
