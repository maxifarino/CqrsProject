﻿using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
    public class VerTipoSocioAmbientalQueryResults : IQueryResult
    {
        public List<TipoSocioAmbientalDto> TipoSocioAmbiental { get; set; }
    }
}
