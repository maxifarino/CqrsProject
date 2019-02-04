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
    public class VisitorUsuarioSave : IVisitorUsuario
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        private static string ALREADY_HAS_ROL = "S";

        public VisitorUsuarioSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }


        public override void Visit(Usuario usuario)
        {
            //TODO Agustin: Agregar validaciones
            if (string.IsNullOrEmpty(usuario.Cuil))
                this.AddError(MessageError.USUARIO_SAVE_ERROR_CUIL);
            if(usuario.rol == null)
                this.AddError(MessageError.USUARIO_SAVE_ERROR_ROL);
            //else
            //{
            //    if (RolUsuarioIsNullOrEmpty(usuario.rol)) 
            //     this.AddError(MessageError.USUARIO_SAVE_LIST_ROL_EMPTY);
            //    else
            //    {
            //        if (!UsuarioExistsInCIDI(usuario.Cuil))
            //            this.AddError(MessageError.USUARIO_SAVE_NOT_EXISTS_IN_CIDI);
            //        else
            //        {
            //            foreach (Rol item in usuario.rol)
            //            {
            //                if (AlreadyHasRol(item, usuario.Cuil) && usuario.IdUsuario == 0)
            //                {
            //                    //do something
            //                    this.AddError(string.Format(MessageError.ALREADY_HAS_ROL, item.Nombre));
            //                }

            //            }
            //        }
            //    }
            //}
        }


        private bool UsuarioExistsInCIDI(string p)
        {
            return true;
        }

        public virtual bool RolUsuarioIsNullOrEmpty(List<Rol> listaRoles)
        {
            return !listaRoles.Any();
        }

        public virtual bool AlreadyHasRol(Rol rol, string cuil)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VERIFICAR_DUPLICADO_ROL(?,?)")
            .SetParameter(0, rol.Id)
            .SetParameter(1, cuil);
            return query.UniqueResult().ToString().Equals(ALREADY_HAS_ROL);
        }

    }
}
