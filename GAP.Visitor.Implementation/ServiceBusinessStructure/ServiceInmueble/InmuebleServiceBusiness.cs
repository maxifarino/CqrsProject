using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsInmueble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceInmueble
{
    public class InmuebleServiceBusiness : ServiceBusinessEstructureBase<Inmueble>
    {
        private readonly VisitorInmuebleAdministrar _visitorInmuebleAdministrar;

        public InmuebleServiceBusiness(VisitorInmuebleAdministrar vistor)
        {
            _visitorInmuebleAdministrar = vistor;
        }
                        
        public override Result ValidateSave(Inmueble element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorInmuebleAdministrar);

            return result;
        }
    }
}
