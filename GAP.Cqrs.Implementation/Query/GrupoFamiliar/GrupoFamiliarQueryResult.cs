using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Dto;
using GAP.Base.Dto.GrupoFamiliar;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
  public  class GrupoFamiliarQueryResult:IQueryResult
    {
      public List<GrupoFamiliarDto> ListBeneficiario { get; set; }

    }
}
