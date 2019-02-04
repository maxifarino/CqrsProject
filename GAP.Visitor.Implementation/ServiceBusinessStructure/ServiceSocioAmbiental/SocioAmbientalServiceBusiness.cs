using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.Visitor.VisitorAdministrarSocioAmbiental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSocioAmbiental
{
   public class SocioAmbientalServiceBusiness : ServiceBusinessEstructureBase<SocioAmbiental>
    {
        private readonly VisitorSocioAmbientalSave _visitorSocioAmbientalSave;

        public SocioAmbientalServiceBusiness(VisitorSocioAmbientalSave visitorSocioAmbientalSave)
            : base() 
        {
            _visitorSocioAmbientalSave = visitorSocioAmbientalSave;
        }

        public override Result ValidateSave(SocioAmbiental element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSocioAmbientalSave);

            return result;
        }

    }
}
