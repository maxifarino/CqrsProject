using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.ServiceBusinessStructure;
using GAP.Visitor.Implementation.Visitor.VisitorsEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceEntidad.ServiceBusinessStructure
{
    public class EntidadServiceBusiness : ServiceBusinessEstructureBase<Entidad>
    {
        private readonly VisitorEntidadSave _visitorEntidadSave;

        public EntidadServiceBusiness(VisitorEntidadSave visitorEntidadSave) 
        {
            _visitorEntidadSave = visitorEntidadSave;
        }

        public override Result ValidateSave(Entidad element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorEntidadSave);

            return result;
        }


    }
}
