﻿using GAP.Base.Dto.Usuario;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.UsuarioQuery
{
    public class ObtenerUsuarioActivoResult : IQueryResult
    {
        public UsuarioCidiDto UsuarioDto { get; set; }
        public String Hash { get; set; }
    }
}
