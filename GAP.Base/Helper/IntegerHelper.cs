using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class IntegerHelper
    {
        public static string getString(int value)
        {
            return value == 0 ? null : value.ToString();
        }
    }
}
