using GAP.Base.Enumerations;
using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorsSalaCuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna
{
    public class SalaCunaServiceBusiness : ServiceBusinessEstructureBase<SalaCuna>
    {
        private readonly VisitorSalaCunaSave _visitorSalaCunaSave;
        private readonly VisitorSalaCunaDelete _visitorSalaCunaDelete;
        private readonly VisitorSalaCunaUpdate _visitorSalaCunaUpdate;
        private readonly VisitorSalaCunaInaugurar _visitorSalaCunaInaugurar;

        public SalaCunaServiceBusiness(VisitorSalaCunaSave vistorSave, VisitorSalaCunaDelete visitorDelete, VisitorSalaCunaUpdate visitorUpdate, VisitorSalaCunaInaugurar visitorInaugurar)
        {
            _visitorSalaCunaSave = vistorSave;
            _visitorSalaCunaDelete = visitorDelete;
            _visitorSalaCunaUpdate = visitorUpdate;
            _visitorSalaCunaInaugurar = visitorInaugurar;
        }

        public void CompletarSalaCunaSave(SalaCuna element)
        {            
            element.FechaUltimaModificacion = DateTime.Now;
            element.Estado = (int)SalaCunaStateEnum.Provisoria;
        }
                
        public override Result ValidateSave(SalaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalaCunaSave);

            return result;
        }

        public override Result ValidateUpdate(SalaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalaCunaUpdate);

            return result;
        }

        public override Result ValidateDelete(SalaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalaCunaDelete);

            return result;
        }

        public Result ValidateInaugurar(SalaCuna element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorSalaCunaInaugurar);
            
            return result;
        }

    }
}
