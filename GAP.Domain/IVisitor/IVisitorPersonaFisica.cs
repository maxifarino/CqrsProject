﻿using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.IVisitor
{
    public abstract class IVisitorPersonaFisica : VisitorBase
    {
        public abstract void Visit(Persona persona);
    
    }
}
