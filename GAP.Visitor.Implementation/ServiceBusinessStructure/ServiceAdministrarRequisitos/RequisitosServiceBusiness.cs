using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsAdministrarRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceAdministrarRequisitos
{
    public class RequisitosServiceBusiness : ServiceBusinessEstructureBase<Requisito>
    {

         private readonly VisitorRequisitosSave _visitorRequisitosSave;

         public RequisitosServiceBusiness(VisitorRequisitosSave visitor)
        {
            _visitorRequisitosSave = visitor;
        }
                
        public override Result ValidateSave(Requisito element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorRequisitosSave);

            return result;
        }
    }
}
