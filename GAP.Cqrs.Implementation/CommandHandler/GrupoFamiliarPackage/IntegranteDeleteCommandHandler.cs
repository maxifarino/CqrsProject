using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.GrupoFamiliarPackage
{
    public class IntegranteDeleteCommandHandler: ICommandHandler<IntegranteDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public IntegranteDeleteCommandHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }


        public Result Execute(IntegranteDeleteCommand command)
        {
            Result result = new Result();

            if (result.success)
                IntegranteDelete(command, ref result);

            return result;
        }

        private void IntegranteDelete(IntegranteDeleteCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ELIMINAR_INTEG_GPO_FLIAR(?,?,?,?,?) ");

            
                query.SetParameter(0, command.ProgramaAplicacionId);
                query.SetParameter(1, command.UsuarioLogueadoId);
                query.SetParameter(2, command.Integrante.IntegranteGrupoFamiliarId);
                query.SetParameter(3, command.Integrante.MotivoBaja);
                query.SetParameter(4, command.Integrante.FechaBaja);

                result.Resolve(query.UniqueResult());
           
        }


    }
}