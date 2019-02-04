using GAP.Base.Dto.Beneficiario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Mock
{
    public class BeneficiarioDtoMocked
    {
        private List<BeneficiarioDto> _getListMocked;

        private static BeneficiarioDtoMocked _BeneficiarioDtoMocked;
        public static BeneficiarioDtoMocked GetInstance()
        {
            _BeneficiarioDtoMocked = _BeneficiarioDtoMocked == null ? new BeneficiarioDtoMocked() : _BeneficiarioDtoMocked;

            return _BeneficiarioDtoMocked;
        }

        private BeneficiarioDtoMocked()
        {
            _getListMocked = new List<BeneficiarioDto>();
        }

        public List<BeneficiarioDto> GetMocked()
        {
            _getListMocked.Clear();

            BeneficiarioDto p1 = new BeneficiarioDto()
            {
                BeneficiarioId = 1,
                Nombre = "Beneficiario mocked 1",
                Apellido = "Apellido mocked 1",
                NumeroDocumento = "9999999999"
            };
            _getListMocked.Add(p1);

            p1 = new BeneficiarioDto()
            {
                BeneficiarioId = 2,
                Nombre = "Beneficiario mocked 2",
                Apellido = "Apellido mocked 2",
                NumeroDocumento = "8888888888"
            };
            _getListMocked.Add(p1);

            p1 = new BeneficiarioDto()
            {
                BeneficiarioId = 3,
                Nombre = "Beneficiario mocked 3",
                Apellido = "Apellido mocked 3",
                NumeroDocumento = "7777777777"
            };            
            _getListMocked.Add(p1);

            return _getListMocked;
        }


        public List<BeneficiarioReporteDto> GetReporteMocked()
        {
            List<BeneficiarioReporteDto> list = new List<BeneficiarioReporteDto>();

            BeneficiarioReporteDto p1;

            for (int i = 0; i < 100; i++ )
            {                 
                p1 = new BeneficiarioReporteDto()
                {
                    BeneficiarioId = 1,
                    Nombre = "Beneficiario " + i,
                    Apellido = "apellido " + i,
                    NroDocumento = "22333444",
                    NombreSexo = "Masculino",
                    PaisNacionalidad = "Argentino",
                    PaisOrigen = "Argentino",
                    FechaNacimiento = DateTime.Now,
                    FechaInscripcion = DateTime.Now,
                    NombreSalaCuna = "Sala cuna " + i,
                    NombrePersonaJuridica = "Entidad " + i,
                    AsistioGuarderia = "SI",
                    NombreGuarderia = "Guarderia " + i,
                    EsAlergico = "NO",
                    DetalleAlergico = "Detalle alergico",
                    TomaMedicamentos = "NO",
                    DetalleMedicamento = "Detalle medicamento",
                    TieneObraSocial = "SI",
                    DetalleObraSocial = "Detalle obra social",
                    CondicionParticular = "Condicion particular",
                    DetalleCondicionParticular = "Detalle condicion particular",
                    NombreGrupoSanguineo = "A+",
                    InstitucionMedica = "Allende",
                    FechaUltimoControl = DateTime.Now,
                    Peso = 22,
                    Talla = 1.7,
                    PadeceEnfermedad = "NO"
                };

                list.Add(p1);
            }

            return list;
        }
    }
}
