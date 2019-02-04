using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Enumerations
{
    public class TiposArchivo
    {
        private TiposArchivo(string value) { Value = value; }
        public string Value { get; set; }
        public static TiposArchivo PDF { get { return new TiposArchivo("PDF"); } }
        public static TiposArchivo Excel { get { return new TiposArchivo("Excel"); } }

    }
}
