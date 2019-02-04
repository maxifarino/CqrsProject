using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsDomicilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio
{
    public class DomicilioServiceBusiness : ServiceBusinessEstructureBase<Domicilio>
    {
        private readonly VisitorDomiclioSave _visitorDomicilioSave;

        public DomicilioServiceBusiness(VisitorDomiclioSave visitorDomicilioSave)
            : base() 
        {
            _visitorDomicilioSave = visitorDomicilioSave;
        }

        public override Result ValidateSave(Domicilio element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorDomicilioSave);

            return result;
        }
    }
}
