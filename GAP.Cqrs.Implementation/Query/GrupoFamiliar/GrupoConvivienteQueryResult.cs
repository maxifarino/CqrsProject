﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.CqrsCore.Querys;
using GAP.Base.Dto.GrupoFamiliar;

namespace GAP.Cqrs.Implementation.Query.GrupoFamiliar
{
    public class GrupoConvivienteQueryResult : IQueryResult
    {
        public List<IntegranteResumenDto> Integrante { get; set; }
    }
}
