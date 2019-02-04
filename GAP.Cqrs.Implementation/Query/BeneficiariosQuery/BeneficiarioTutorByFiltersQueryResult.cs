using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
   public class BeneficiarioTutorByFiltersQueryResult:IQueryResult
    {
       public BeneficiarioTutorDto BeneficiarioTutor { get; set; }
    }
}
