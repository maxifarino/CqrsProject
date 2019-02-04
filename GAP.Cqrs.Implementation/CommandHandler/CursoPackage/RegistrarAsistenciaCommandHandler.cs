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
    public class RegistrarAsistenciaCommandHandler: ICommandHandler<RegistrarAsistenciaCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;


        public RegistrarAsistenciaCommandHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }

        public Result Execute(RegistrarAsistenciaCommand command)
        {
            Result result = new Result();

            if (result.success)
                RegistrarAsistencia(command, ref result);

            return result;
        }


        private void RegistrarAsistencia(RegistrarAsistenciaCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_REGISTRAR_ASISTENCIA(?,?,?,?) ");

            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.FechaAsistencia);
            query.SetParameter(3, command.IdsPersonal);

            result.Resolve(query.UniqueResult());
        }

    }
}