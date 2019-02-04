using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.Entities
{
    public class BeneficiarioPersona : Persona
    {
        public virtual int NumeroId { get; set; }
        public virtual bool Indocumentado { get; set; }
    }
}
