using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorListProgSocialesQuery : IQuery
    {
        public string NumeroId { get; set; }
        public string SexoId { get; set; }
        public string CodigoPais { get; set; }
        public string NumeroDocumento { get; set; }
        

    }

}
