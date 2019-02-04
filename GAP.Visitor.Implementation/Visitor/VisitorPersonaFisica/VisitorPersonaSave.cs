using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorPersonaFisica
{
    public class VisitorPersonaSave : IVisitorPersonaFisica
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;

        public VisitorPersonaSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }
        public override void Visit(Persona persona)
        {

            
        }
    }
}
