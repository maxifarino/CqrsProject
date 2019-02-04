using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorInscripcionCurso
{
    public class VisitorInscripcionCurso : IVisitorInscripcionCurso
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VisitorInscripcionCurso(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public override void Visit(Personal personal)
        {
            if (VerificarPersonal(personal) != "N")
                this.AddError(MessageError.INSCRIPCION_ERROR_PERSONAL);

            if (personal.PersonaSeleccionada != null)
            {
                if (personal.PersonaSeleccionada.NumeroDocumento == null && personal.PersonaSeleccionada.SexoId == null
                    && personal.PersonaSeleccionada.NumeroId == null && personal.PersonaSeleccionada.CodigoPais == null)
                    this.AddError(MessageError.INSCRIPCION_ERROR_PERSONA_SELECCIONADA);

            }
            else {
                this.AddError(MessageError.INSCRIPCION_ERROR_PERSONA_SELECCIONADA);
            }

        }

        private string VerificarPersonal(Personal personal)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VALIDAR_PERSONAL(?,?,?,?)");

            query.SetParameter(1, personal.PersonaSeleccionada.NumeroDocumento);
            query.SetParameter(2, personal.PersonaSeleccionada.SexoId);
            query.SetParameter(3, personal.PersonaSeleccionada.CodigoPais);
            query.SetParameter(4, personal.PersonaSeleccionada.NumeroId);

            return query.UniqueResult().ToString();
        }

    }
}