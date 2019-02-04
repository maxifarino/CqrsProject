using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class JsonHelper
    {
        public static string GetJsonStringFromObject(Object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }
    }
}
