using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Visitor.Implementation.Visitor.VisitorCurso;
using GAP.Visitor.Implementation.Visitor.VisitorInscripcionCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceCurso
{
    public class InscripcionCursoServiceBusiness : ServiceBusinessEstructureBase<Personal>
    {
        private readonly VisitorInscripcionCurso _visitorInscripcionCurso;

        public InscripcionCursoServiceBusiness(VisitorInscripcionCurso visitorInscripcionCurso)
            : base() 
        {
            _visitorInscripcionCurso = visitorInscripcionCurso;
        }

        public Result ValidateInscripcion(Personal element)
        {
            this.addElementoToValidate(element);
            this.Accept(_visitorInscripcionCurso);
            return result;
        }
    }
}
