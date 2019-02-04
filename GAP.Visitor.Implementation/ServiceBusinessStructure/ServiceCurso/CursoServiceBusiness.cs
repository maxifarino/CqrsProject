using GAP.Base.Dto;
using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceCurso
{
    public class CursoServiceBusiness : ServiceBusinessEstructureBase<Curso>
    {
        private readonly VisitorCursoSave _visitorCursoSave;
        private readonly VisitorCursoUpdate _visitorCursoUpdate;

        public CursoServiceBusiness(VisitorCursoSave visitorCursoSave, VisitorCursoUpdate visitorCursoUpdate)
            : base() 
        {
            _visitorCursoSave = visitorCursoSave;
            _visitorCursoUpdate = visitorCursoUpdate;
        }

        public override Result ValidateSave(Curso element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorCursoSave);
            return result;
        }

        public override Result ValidateUpdate(Curso element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorCursoUpdate);
            return result;
        }
    }
}
