using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorPersonaFisica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonaFisica
{
   public class PersonaServiceBusiness:ServiceBusinessEstructureBase<Persona>
    {
       private readonly VisitorPersonaSave _visitorPersonaSave;
       public PersonaServiceBusiness(VisitorPersonaSave visitorPersonaSave)
            : base() 
        {
            _visitorPersonaSave = visitorPersonaSave;
        }

        public override Result ValidateSave(Persona element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorPersonaSave);

            return result;
        }
    }
}
