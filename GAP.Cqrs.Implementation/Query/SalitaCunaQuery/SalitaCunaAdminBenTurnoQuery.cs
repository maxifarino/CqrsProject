﻿using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalitaCunaQuery
{
    public class SalitaCunaAdminBenTurnoQuery : IQuery
    {
        public int? SalaCunaId { get; set; }
        public int? SeleccionBaja { get; set; }
        public string IncluirSegundoAnillo { get; set; }
    }
}
