﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class ClaseDto
    {
        public Decimal Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaAsistencia { get; set; }
    }
}