using GAP.Base.Dto;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class TutorListProgSocialesQueryResult : IQueryResult
    {
        public List<IdNombreDto> ListProgramaSocial { get; set; }
    }
}
