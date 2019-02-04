using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery
{
    public class LugarDeOrigenQueryResult : IQueryResult
    {

        public List<ProvinciasDto> Provincias { get; set; }
        public List<IdNombreDto> Departamentos { get; set; }
        public List<IdNombreDto> Localidades { get; set; }
    }
}
