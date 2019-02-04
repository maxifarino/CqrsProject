using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.ServiceBusinessStructure;
using GAP.Visitor.Implementation.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServicePerson.ServiceBusinessStructure
{
    /// <summary>
    /// This module is responsible of to add the objects to be validated
    /// </summary>
    public class PersonServiceBusiness : ServiceBusinessEstructureBase<Person>
    {
        private readonly VisitorPersonSave _visitorPersonSave;
        private readonly VisitorPersonUpdate _visitorPersonUpdate;

        public PersonServiceBusiness(VisitorPersonSave visitorPersonSave, VisitorPersonUpdate visitorPersonUpdate)
            : base() 
        {
            _visitorPersonSave = visitorPersonSave;
            _visitorPersonUpdate = visitorPersonUpdate;
        }


        public override Result ValidateSave(Person element)
        {
            this.addElementoToValidate(element);
            //this.addElementoToValidate(element.Address);
            this.Accept(_visitorPersonSave);

            return result;
        }

        public override Result ValidateUpdate(Person element)
        {
            this.addElementoToValidate(element);
            //this.addElementoToValidate(element.Address);
            this.Accept(_visitorPersonUpdate);

            return result;
        }


    }
}
