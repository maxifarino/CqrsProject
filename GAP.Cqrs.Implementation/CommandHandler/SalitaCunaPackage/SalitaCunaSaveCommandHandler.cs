using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.SalaCunaPackage;
using GAP.Cqrs.Implementation.Command.SalitaCunaPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalitaCuna;
using System;
using System.Text;

namespace GAP.Cqrs.Implementation.CommandHandler.SalitaCunaPackage
{
    public class SalitaCunaSaveCommandHandler : ICommandHandler<SalitaCunaSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalitaCunaServiceBusiness _salitaCunaServiceBusiness;

        public SalitaCunaSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalitaCunaServiceBusiness salitaServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salitaCunaServiceBusiness = salitaServiceBusiness;

        }

        public Result Execute(SalitaCunaSaveCommand command)
        {

            Result result = _salitaCunaServiceBusiness.ValidateSave(command.SalitaCuna);
            if (result.success)
                SaveSalita(command, ref result);

            return result;
        }
        public void SaveSalita(SalitaCunaSaveCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_SALITA_CUNA (?,?,?,?,?)")
                .SetParameter(0,command.SalitaCuna.NombreSalita)
                .SetParameter(1, command.SalitaCuna.CupoSalita)
                .SetParameter(2, command.SalitaCuna.SalaCunaId)
                .SetParameter(3, command.UsuarioLogueadoId)
                .SetParameter(4, command.SalitaCuna.TurnoSalitaId);

            result.Resolve(query.UniqueResult());
        }
    }
}
