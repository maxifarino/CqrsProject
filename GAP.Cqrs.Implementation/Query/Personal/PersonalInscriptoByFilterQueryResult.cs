﻿using GAP.Base.Dto;
using GAP.Base.Dto.Personal;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class PersonalInscriptoByFilterQueryResult : IQueryResult
    {
        public List<PersonalAsistenciaDto> ListInscripto { get; set; }
    }
}
