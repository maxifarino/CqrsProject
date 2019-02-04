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
    public class VisitorRolUsuarioSave : IVisitorRol
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        private static string ROL_EXISTE = "S";


        public VisitorRolUsuarioSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }


        public override void Visit(List<Rol> roles)
        {

            foreach (var rol in roles)
            {

                if (!RolExists(rol))
                {
                    //do something 
                    this.AddError(string.Format(MessageError.ROL_NO_EXISTE,rol.Nombre));
                }
                                
            }

        }

        /// <summary>
        /// En este metodo verificamos que la lista de roles no este vacia.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public virtual bool RolExists(Rol rol)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VERIFICAR_EXISTENCIA_ROL(?,?)")
            .SetParameter(0, rol.Id)
            .SetParameter(1, rol.Nombre);
            return query.UniqueResult().ToString().Equals(ROL_EXISTE);
        }

       

    }
}
