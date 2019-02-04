using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class EnviarMailQuery : IQuery
    {
        public String Cuil { get; set; }

        public String ReportTitle { get; set; }

        public String FileName { get; set; }

        public String Link { get; set; }

        public String Mensaje { get; set; }

        public bool Ok { get; set; }
    }
}
