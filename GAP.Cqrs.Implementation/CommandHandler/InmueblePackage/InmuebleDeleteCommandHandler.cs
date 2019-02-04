using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.InmueblePackage;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.InmueblePackage
{
    public class InmuebleDeleteCommandHandler : ICommandHandler<InmuebleDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public InmuebleDeleteCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public Result Execute(InmuebleDeleteCommand command)
        {

            Result result = new Result();
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ELIMINAR_INM_SC(?,?)")
                .SetParameter(0, command.Inmueble.Id)
                .SetParameter(1, 1); //cambiar despues

            result.Resolve(query.UniqueResult());

            return result;
        }
    }
}
