using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Exceptions
{
    public class GobTechnicalException : Exception
    {
         public GobTechnicalException()
        {
        }

        public GobTechnicalException(string message)
            : base(message)
        {
        }

        public GobTechnicalException(string message, GobTechnicalException inner)
            : base(message, inner)
        {
        }
    }
}
