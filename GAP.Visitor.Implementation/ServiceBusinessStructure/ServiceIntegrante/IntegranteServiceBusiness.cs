using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorIntegrante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceIntegrante
{
    public class IntegranteServiceBusiness : ServiceBusinessEstructureBase<Beneficiario>
    {
        private readonly VisitorIntegranteSave _visitorIntegranteSave;

        public IntegranteServiceBusiness(VisitorIntegranteSave visitorIntegranteSave)
            : base() 
        {
            _visitorIntegranteSave = visitorIntegranteSave;
        }

        public override Result ValidateSave(Beneficiario element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorIntegranteSave);
            return result;
        }


    }
}
