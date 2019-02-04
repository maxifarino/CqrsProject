using GAP.Base.Dto;
using GAP.Base.Dto.AdministrarConvenios;
using GAP.Base.Dto.AdministrarRequisitos;
using GAP.Base.Dto.SalasCuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class SalasCunaDtoMocked
    {
        private List<SalasCunaDto> _getListMocked;

        private static SalasCunaDtoMocked _SalasCunaDtoMocked;
        public static SalasCunaDtoMocked GetInstance()
        {
            _SalasCunaDtoMocked = _SalasCunaDtoMocked == null ? new SalasCunaDtoMocked() : _SalasCunaDtoMocked;

            return _SalasCunaDtoMocked;
        }

        private SalasCunaDtoMocked()
        {
            _getListMocked = new List<SalasCunaDto>();
        }

        public List<SalasCunaDto> GetMocked()
        {
            _getListMocked.Clear();

            SalasCunaDto p1 = new SalasCunaDto()
            {
                Id = 1,
                EstadoSalaCuna = "estado mocked 1",
                NombreSalaCuna = "nombre mocked 1",
                RazonSocial = "razon socal mocked 1"
            };
            _getListMocked.Add(p1);

            p1 = new SalasCunaDto()
            {
                Id = 1,
                EstadoSalaCuna = "estado mocked 2",
                NombreSalaCuna = "nombre mocked 2",
                RazonSocial = "razon socal mocked 2"
            };
            _getListMocked.Add(p1);

            p1 = new SalasCunaDto()
            {
                Id = 1,
                EstadoSalaCuna = "estado mocked 3",
                NombreSalaCuna = "nombre mocked 3",
                RazonSocial = "razon socal mocked 3"
            };            
            _getListMocked.Add(p1);

            return _getListMocked;
        }

        public SalasCunaDto GetMockedById(int id)
        {
            _getListMocked.Clear();

            SalasCunaDto p1 = new SalasCunaDto()
            {
                Id = id,
                EstadoSalaCuna = "estado mocked 1",
                NombreSalaCuna = "nombre mocked 1",
                RazonSocial = "razon socal mocked 1",
                Cuit = "99999999999"
            };
            _getListMocked.Add(p1);

            return _getListMocked[0];
        }

        public  List<SalasCunaReporteDto> GetReporteMocked()
        {
            List<SalasCunaReporteDto> list = new List<SalasCunaReporteDto>();

            for (int i = 0; i < 100; i++ )
            {

                List<RequisitosDeSalaCunaDto> listRequerimientos = new List<RequisitosDeSalaCunaDto>();

                for (int re = 0; re < 4; re++ )
                {
                    listRequerimientos.Add(new RequisitosDeSalaCunaDto()
                    {
                        NombreRequisito = "Requisito " + re
                    });
                }

                List<ConveniosDeSalasCunaDto> listConvenios = new List<ConveniosDeSalasCunaDto>();

                for (int co = 0; co < 4; co++)
                {
                    listConvenios.Add(new ConveniosDeSalasCunaDto()
                    {
                        FechaDesde = DateTime.Now,
                        FechaHasta = DateTime.Now
                    });
                }

                List<InmuebleDto> listInmuebles = new List<InmuebleDto>();

                for (int refa = 0; refa < 4; refa++)
                {
                    listInmuebles.Add(new InmuebleDto()
                    {
                        Monto = 50000
                    });
                }
                

                SalasCunaReporteDto p1 = new SalasCunaReporteDto()
                {
                    SalaCunaId = i,
                    NombreEntidad = "Nombre entidad " + i,
                    EstadoSalasCuna = "Correcto",
                    NombreSalasCuna = "Sala cuna " + i,
                    Inmuebles = listInmuebles,
                    Requisitos = listRequerimientos.ToString(),
                    Convenios = listConvenios
                };
                list.Add(p1);
            }

            return list;
        }
    }
}
