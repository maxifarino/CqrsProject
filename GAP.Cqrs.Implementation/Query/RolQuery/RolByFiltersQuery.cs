﻿using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.RolQuery
{
    public class RolByFiltersQuery : IQuery
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
