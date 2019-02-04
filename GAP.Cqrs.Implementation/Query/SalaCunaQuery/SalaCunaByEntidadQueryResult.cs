﻿using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult
{
    public class SalaCunaByEntidadQueryResult : IQueryResult
    {
        public List<SalasCunaComboDto> ListSalasCuna {get; set; }
    }
}
