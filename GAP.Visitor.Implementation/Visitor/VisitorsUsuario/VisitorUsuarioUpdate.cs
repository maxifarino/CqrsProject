using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsUsuario
{
    public class VisitorUsuarioUpdate : IVisitorUsuario
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        public VisitorUsuarioUpdate(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }
        public override void Visit(Usuario usuario)
        {
            //TODO Agustin: Agregar validaciones
            if (usuario.IdUsuario == null || usuario.IdUsuario == 0)
            {
                this.AddError(MessageError.USUARIO_UPDATE_ID_EMPTY);
            }

            if (usuario.idRol == null || usuario.idRol==0) {
                this.AddError(MessageError.USUARIO_SAVE_ERROR_ROL);
            }
                

        }
    }
}
