using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonal
{
    public class PersonalServiceBusiness : ServiceBusinessEstructureBase<Personal>
    {
        private readonly VisitorPersonalSave _visitorPersonalSave;
        private readonly VisitorPersonalUpdate _visitorPersonalUpdate;

        public PersonalServiceBusiness(VisitorPersonalSave visitorPersonalSave, VisitorPersonalUpdate visitorPersonalUpdate)
            : base() 
        {
            _visitorPersonalSave = visitorPersonalSave;
            _visitorPersonalUpdate = visitorPersonalUpdate;
        }


        public override Result ValidateSave(Personal element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorPersonalSave);
            return result;
        }

        public override Result ValidateUpdate(Personal element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorPersonalUpdate);
            return result;
        }

    }
}
