using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.SalaCunaPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage
{
    public class SalaCunaDeleteCommandHandler : ICommandHandler<SalaCunaDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalaCunaServiceBusiness _salaCunaServiceBusiness;

        public SalaCunaDeleteCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalaCunaServiceBusiness entidadServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salaCunaServiceBusiness = entidadServiceBusiness;
        }

        public Result Execute(SalaCunaDeleteCommand command)
        {
            Result result = _salaCunaServiceBusiness.ValidateDelete(command.SalaCuna);

            if (result.success)
                DeleteSalaCuna(command, ref result);

            return result;
        }

        private void DeleteSalaCuna(SalaCunaDeleteCommand command, ref Result result) 
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ELIMINAR_SALA_CUNA(?,?,?,?)")
                .SetParameter(0, command.SalaCuna.Id)
                .SetParameter(1, command.idUsuarioLogueado)
                .SetParameter(2, command.SalaCuna.FechaBaja)
                .SetParameter(3, command.SalaCuna.MotivoBaja);                

            result.Resolve(query.UniqueResult());
        }
    }
}
