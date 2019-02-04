using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorAdministrarConvenios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceAdministrarConvenios
{
    public class ConveniosServiceBusiness : ServiceBusinessEstructureBase<Convenio>
    {
        private readonly VisitorConveniosSave _visitorConveniosSave;

         public ConveniosServiceBusiness(VisitorConveniosSave visitor)
        {
            _visitorConveniosSave = visitor;
        }
                
        public override Result ValidateSave(Convenio element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorConveniosSave);

            return result;
        }
    }
}
