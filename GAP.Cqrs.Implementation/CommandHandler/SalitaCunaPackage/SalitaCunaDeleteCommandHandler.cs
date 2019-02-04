using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.SalitaCunaPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalitaCuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalitaCunaPackage
{
    public class SalitaCunaDeleteCommandHandler : ICommandHandler<SalitaCunaDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalitaCunaServiceBusiness _salitaCunaServiceBusiness;

        public SalitaCunaDeleteCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalitaCunaServiceBusiness salitaServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salitaCunaServiceBusiness = salitaServiceBusiness;
        }
        public Result Execute(SalitaCunaDeleteCommand command)
        {

            Result result = _salitaCunaServiceBusiness.ValidateDelete(command.SalitaCuna);
            if (result.success)
                DeleteSalita(command, ref result);

            return result;
        }
        public void DeleteSalita(SalitaCunaDeleteCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_DELETE_SALITA_CUNA (?,?,?,?)")

                .SetParameter(0, command.SalitaCuna.Id)
                .SetParameter(1, command.SalitaCuna.FechaBaja)
                .SetParameter(2, command.UsuarioLogueadoId)
                .SetParameter(3, command.SalitaCuna.ComentarioBaja);


            result.Resolve(query.UniqueResult());
        }
    }
}
