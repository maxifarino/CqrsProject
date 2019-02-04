using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class InscripcionCursoCommandHandler: ICommandHandler<InscripcionCursoCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly InscripcionCursoServiceBusiness _inscripcionCursoServiceBusiness;


        public InscripcionCursoCommandHandler(RepositoryLocalScheme repositryLocalScheme, InscripcionCursoServiceBusiness inscripcionCursoServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _inscripcionCursoServiceBusiness = inscripcionCursoServiceBusiness;
        }


        public Result Execute(InscripcionCursoCommand command)
        {
            Result result = new Result();

            result.AddErrorsRange(_inscripcionCursoServiceBusiness.ValidateInscripcion(command.Personal).GetErrors());


            if (result.success)
                InscripcionCurso(command, ref result);

            return result;
        }


        private void InscripcionCurso(InscripcionCursoCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSCRIPCION_CURSO(?,?,?,?,?,?,?,?) ");

            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.Personal.PersonaSeleccionada.NumeroDocumento);
            query.SetParameter(3, command.Personal.PersonaSeleccionada.SexoId);
            query.SetParameter(4, command.Personal.PersonaSeleccionada.CodigoPais);
            query.SetParameter(5, command.Personal.PersonaSeleccionada.NumeroId);
            query.SetParameter(6, command.Personal.CursoId);
            query.SetParameter(7, command.Personal.FechaInscripcion);

            result.Resolve(query.UniqueResult());
        }

    }
}