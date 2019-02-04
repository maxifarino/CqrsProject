using GAP.Base.Enumerations;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Reportes
{
    public class ReporteConfigDto
    {
        public string DataSource { get; set; }
        public string Rdlc { get; set; }
        public string OutputFileName { get; set; }
        public string Format { get; set; }
        public string StoreProcedureName { get; set; }
        public string AsuntoEmail { get; set; }
        public TiposArchivo TiposArchivo { get; set; }
    }
}
