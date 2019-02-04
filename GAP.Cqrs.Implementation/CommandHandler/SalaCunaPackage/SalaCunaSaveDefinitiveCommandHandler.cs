using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.SalaCunaPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage
{
    public class SalaCunaSaveDefinitiveCommandHandler : ICommandHandler<SalaCunaSaveDefinitiveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaSaveDefinitiveCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public Result Execute(SalaCunaSaveDefinitiveCommand command)
        {
            Result result = new Result();
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_MODIFICAR_ESTADO_SC(?,?)")
                .SetParameter(0, command.idSalaCuna)
                .SetParameter(1, command.idUsuarioLogueado);

            result.Resolve(query.UniqueResult());

            return result;
        }

    }
}

