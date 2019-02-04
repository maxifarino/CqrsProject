using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.Personal
{
    public class PersonalRequisitosDto
    {
        public Int64 IdRequisito { get; set; }
        public Int64 IdRequisitoEmpelado { get; set; }

        public DateTime? FechaPresentacion { get; set; }
        public string fechaP
        {
            get
            {
                return FechaPresentacion.Value.ToShortDateString();
            }
            set {
                FechaPresentacion = DateTime.Parse(value);
            }
        }
        }   
}
