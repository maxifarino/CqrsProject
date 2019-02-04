using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalDomicilioQuery : IQuery
    {
        //public BeneficiarioPersona personaSeleccionada { get; set; }

        public string SexoId { get; set; }
        public string Apellido { get; set; }
        public  string CodigoPais { get; set; }
        public  int NumeroId { get; set; }
        public  string NumeroDocumento { get; set; }
        public  string Nombre { get; set; }
    }
}
