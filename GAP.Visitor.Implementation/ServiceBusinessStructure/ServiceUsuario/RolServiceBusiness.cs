using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceUsuario
{
    public class RolServiceBusiness : ServiceBusinessEstructureBase<Rol>
    {
        private readonly VisitorRolUsuarioSave _visitorRolUsuarioSave;

        public RolServiceBusiness(VisitorRolUsuarioSave visitor)
        {
            _visitorRolUsuarioSave = visitor;
        }


        public override Result ValidateSave(List<Rol> roles)
        {   
            this.addElementoToValidate(roles);
            this.Accept(_visitorRolUsuarioSave);

            return result;
        }


       
    }
}
