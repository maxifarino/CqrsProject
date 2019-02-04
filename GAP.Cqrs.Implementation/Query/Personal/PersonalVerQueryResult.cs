using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Dto.GrupoFamiliar;
using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalVerQueryResult: IQueryResult
    {
        public PersonalVerDto PersonalVerDto { get; set; }
        public List<PersonalHistorialDto> HistorialPersonal { get; set; }
        public List<PersonalRequisitosDto> RequisitosPersonal { get; set; }
        public List<CursoDto> CursosPersonal { get; set; }
    }
}
