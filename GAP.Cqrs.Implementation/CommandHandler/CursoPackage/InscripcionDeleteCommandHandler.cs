using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class InscripcionDeleteCommandHandler: ICommandHandler<InscripcionDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;


        public InscripcionDeleteCommandHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }

        public Result Execute(InscripcionDeleteCommand command)
        {
            Result result = new Result();

            if (result.success)
                DeleteInscripcion(command, ref result);

            return result;
        }


        private void DeleteInscripcion(InscripcionDeleteCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSCRIPCION_DELETE(?,?,?) ");

            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.PersonalId);
            query.SetParameter(3, command.CursoId);

            result.Resolve(query.UniqueResult());
        }

    }
}