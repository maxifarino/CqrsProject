﻿using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Curso
{
    public class CursoValidacionBajaQuery : IQuery
    {
        public int? CursoId { get; set; }
    }
}