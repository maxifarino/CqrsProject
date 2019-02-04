using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Enumerations
{
    public class TiposReporte
    {
         private TiposReporte(string value) { Value = value; }
         public string Value { get; set; }
         public static TiposReporte MadresBeneficiarios { get { return new TiposReporte("MadresBeneficiarios"); } }
         public static TiposReporte SocioAmbiental { get { return new TiposReporte("SocioAmbiental"); } }
         public static TiposReporte InfoGlobal { get { return new TiposReporte("InfoGlobal"); } }
         public static TiposReporte GrupoFamiliar { get { return new TiposReporte("GrupoFamiliar"); } }
         public static TiposReporte PersonalPorSala { get { return new TiposReporte("PersonalPorSala"); } }
         public static TiposReporte ProductoPorSala { get { return new TiposReporte("ProductoPorSala"); } }
         public static TiposReporte ProductoPorFamiliaPDF { get { return new TiposReporte("ProductoPorFamiliaPdf"); } }
         public static TiposReporte ProductoPorFamiliaExcel { get { return new TiposReporte("ProductoPorFamiliaExcel"); } }
         public static TiposReporte ProvisionDeProducto { get { return new TiposReporte("ProvisionDeProducto"); } }
         public static TiposReporte ProvisionDeProductoCE { get { return new TiposReporte("ProvisionDeProductoCE"); } }
         public static TiposReporte Beneficiario { get { return new TiposReporte("Beneficiario"); } }
         public static TiposReporte SalasCuna { get { return new TiposReporte("SalasCuna"); } }
         public static TiposReporte AsistenciaPorCurso { get { return new TiposReporte("AsistenciaPorCurso"); } }
         public static TiposReporte CertificadosPorCurso { get { return new TiposReporte("CertificadosPorCurso"); } }
         public static TiposReporte AdministrarCursos { get { return new TiposReporte("AdministrarCursos"); } }
         public static TiposReporte ListadoInscriptosCursos { get { return new TiposReporte("ListadoInscriptosCursos"); } }           
    }
}
