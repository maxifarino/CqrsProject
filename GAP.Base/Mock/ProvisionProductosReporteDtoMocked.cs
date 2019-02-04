using GAP.Base.Dto.ProvisionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class ProvisionProductosReporteDtoMocked
    {
        private List<ProvisionProductosReporteDto> _getListMocked;

        private static ProvisionProductosReporteDtoMocked _ProvisionProductosReporteDtoMocked;
        public static ProvisionProductosReporteDtoMocked GetInstance()
        {
            _ProvisionProductosReporteDtoMocked = _ProvisionProductosReporteDtoMocked == null ? new ProvisionProductosReporteDtoMocked() : _ProvisionProductosReporteDtoMocked;

            return _ProvisionProductosReporteDtoMocked;
        }

        private ProvisionProductosReporteDtoMocked()
        {
            _getListMocked = new List<ProvisionProductosReporteDto>();
        }

        public List<ProvisionProductosReporteDto> GetReporteMocked()
        {
            List<ProvisionProductosReporteDto> list = new List<ProvisionProductosReporteDto>();

            ProvisionProductosReporteDto p1 = new ProvisionProductosReporteDto()
            {
                NroOrden = 1,
                IdSalaCuna = 1,
                FechaAltaDefinitiva = DateTime.Now,
                NombreSalaCuna = "Sala cuna 1",
                NombrePersonaJuridica = "Entidad 1",
                NombreTipoPersonaJuridica = "Tipo 1",
                Barrio = "Nombre barrio 1",
                CantBeneficiarios0a6Meses = 4,
                CantBeneficiarios6a12Meses = 3,
                CantBeneficiarios1Anio = 13,
                CantBeneficiarios2Anios = 14,
                CantBeneficiarios3Anios = 23,
            };

            list.Add(p1);

            p1 = new ProvisionProductosReporteDto()
            {
                NroOrden = 2,
                IdSalaCuna = 2,
                FechaAltaDefinitiva = DateTime.Now,
                NombreSalaCuna = "Sala cuna 2",
                NombrePersonaJuridica = "Entidad 2",
                NombreTipoPersonaJuridica = "Tipo 2",
                Barrio = "Nombre barrio 2",
                CantBeneficiarios0a6Meses = 0,
                CantBeneficiarios6a12Meses = 3,
                CantBeneficiarios1Anio = 12,
                CantBeneficiarios2Anios = 30,
                CantBeneficiarios3Anios = 13,
            };

            list.Add(p1);

            p1 = new ProvisionProductosReporteDto()
            {
                NroOrden = 3,
                IdSalaCuna = 3,
                FechaAltaDefinitiva = DateTime.Now,
                NombreSalaCuna = "Sala cuna 3",
                NombrePersonaJuridica = "Entidad 3",
                NombreTipoPersonaJuridica = "Tipo 3",
                Barrio = "Nombre barrio 3",
                CantBeneficiarios0a6Meses = 0,
                CantBeneficiarios6a12Meses = 4,
                CantBeneficiarios1Anio = 6,
                CantBeneficiarios2Anios = 25,
                CantBeneficiarios3Anios = 22,
            };

            list.Add(p1);

            return list;
        }
    }
}
