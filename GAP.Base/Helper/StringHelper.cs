using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class StringHelper
    {

        public static string devolverString(string campo)
        {
            return campo == null ? null : campo.ToString();
        }

        public static string devolverStringUpperCase(string campo)
        {
            return campo == null ? null : campo.ToString().ToUpper();
        }
    }
}
