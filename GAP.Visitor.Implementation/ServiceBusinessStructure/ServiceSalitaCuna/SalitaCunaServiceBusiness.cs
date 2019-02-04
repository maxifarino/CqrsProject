using GAP.Base.Enumerations;
using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsSalitaCuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalitaCuna
{
    public class SalitaCunaServiceBusiness : ServiceBusinessEstructureBase<SalitaCuna>
    {
        private readonly VisitorSalitaCunaSave _visitorSalitaCunaSave;
        private readonly VisitorSalitaCunaDelete _visitorSalitaCunaDelete;
        private readonly VisitorSalitaCunaUpdate _visitorSalitaCunaUpdate;
        
        public SalitaCunaServiceBusiness(VisitorSalitaCunaSave visitor,VisitorSalitaCunaDelete visitorDelete, VisitorSalitaCunaUpdate visitorUpdate)
        {
            _visitorSalitaCunaSave = visitor;
            _visitorSalitaCunaDelete = visitorDelete;
            _visitorSalitaCunaUpdate = visitorUpdate;
        }
        public override Result ValidateSave(SalitaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalitaCunaSave);

            return result;
        }
        public override Result ValidateDelete(SalitaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalitaCunaDelete);

            return result;
        }
        public override Result ValidateUpdate(SalitaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalitaCunaUpdate);

            return result;
        }
    }
}
