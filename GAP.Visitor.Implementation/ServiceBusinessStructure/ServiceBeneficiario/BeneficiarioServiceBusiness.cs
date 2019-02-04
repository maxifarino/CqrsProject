using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorBeneficiario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceBeneficiario
{
  public  class BeneficiarioServiceBusiness: ServiceBusinessEstructureBase<Beneficiario>
    {
      private readonly VisitorBeneficiarioUpdate _visitorBeneficiarioUpdate;
      private readonly VisitorBeneficiarioCreate _visitorBeneficiarioCreate;
         public BeneficiarioServiceBusiness(VisitorBeneficiarioUpdate visitorBeneficiarioUpdate, VisitorBeneficiarioCreate visitorBeneficiarioCreate)
            : base() 
        {
            _visitorBeneficiarioUpdate = visitorBeneficiarioUpdate;
            _visitorBeneficiarioCreate = visitorBeneficiarioCreate;
        }

        public override Result ValidateUpdate(Beneficiario element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorBeneficiarioUpdate);

            return result;
        }


        public Result ValidateSave(BeneficiarioSave element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorBeneficiarioCreate);

            return result;
        }
    }
}
