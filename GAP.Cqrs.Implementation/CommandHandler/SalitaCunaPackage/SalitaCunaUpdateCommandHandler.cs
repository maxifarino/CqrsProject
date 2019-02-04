using GAP.Base;
using GAP.Base.ResultValidation;
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
    public class SalitaCunaUpdateCommandHandler : ICommandHandler<SalitaCunaUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalitaCunaServiceBusiness _salitaCunaServiceBusiness;

        public SalitaCunaUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalitaCunaServiceBusiness salitaServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salitaCunaServiceBusiness = salitaServiceBusiness;

        }

        public Result Execute(SalitaCunaUpdateCommand command)
        {

            Result result = _salitaCunaServiceBusiness.ValidateUpdate(command.SalitaCuna);
            if (result.success)
                updateSalita(command, ref result);

            return result;
        }
        public void updateSalita(SalitaCunaUpdateCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_SALITA_CUNA (?,?,?,?,?,?)")
                //Ver si se corresponden con los parametros en el procedimiento de la base.
                .SetParameter(0, command.SalitaCuna.Id)
                .SetParameter(1, command.SalitaCuna.CupoSalita)
                .SetParameter(2, command.SalitaCuna.TurnoSalitaId)
                .SetParameter(3, command.SalitaCuna.FechaBaja)
                .SetParameter(4, command.UsuarioLogueadoId)
                .SetParameter(5, command.SalitaCuna.NombreSalita)
                ;

            result.Resolve(query.UniqueResult());
        }
    }
}
