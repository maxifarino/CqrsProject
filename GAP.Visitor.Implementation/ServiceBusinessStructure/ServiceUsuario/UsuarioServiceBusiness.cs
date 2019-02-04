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
    public class UsuarioServiceBusiness : ServiceBusinessEstructureBase<Usuario>
    {

        private readonly VisitorUsuarioSave _visitorUsuarioSave;
        private readonly VisitorUsuarioUpdate _visitorUsuarioUpdate;
        public UsuarioServiceBusiness(VisitorUsuarioSave vistor,VisitorUsuarioUpdate visitorUpdate)
        {
            _visitorUsuarioSave = vistor;
            _visitorUsuarioUpdate = visitorUpdate;
        }

                
        public override Result ValidateSave(Usuario element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorUsuarioSave);

            return result;
        }
        public override Result ValidateUpdate(Usuario element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorUsuarioUpdate);

            return result;
        }

    }
}
