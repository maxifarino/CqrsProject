using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceBeneficiario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.BeneficiarioPackage
{
    public class AsignarBeneficiarioCommandHandler : ICommandHandler<AsignarBeneficiarioCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly BeneficiarioServiceBusiness _beneficiarioServiceBusiness;

        public AsignarBeneficiarioCommandHandler(RepositoryLocalScheme repositoryLocalScheme, BeneficiarioServiceBusiness beneficiarioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _beneficiarioServiceBusiness = beneficiarioServiceBusiness;
        }

        public Result Execute(AsignarBeneficiarioCommand command)
        {
            Result result = new Result();//_beneficiarioServiceBusiness.validate();

            if (result.success)
                AsignarBeneficiario(command, ref result);

            return result;
        }

        private void AsignarBeneficiario(AsignarBeneficiarioCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ASIGNAR_BENEFICIARIO(?,?,?,?,?)")

                .SetParameter(0, command.BeneficiarioId)
                .SetParameter(1, command.SalitaCunaId)
                .SetParameter(2, command.UsuarioId)
                //enviar fecha de hoy como fecha fec_fin_inscripcion
                .SetParameter(3, DateTime.Now)
                .SetParameter(4, command.salitaBajaId);

            result.Resolve(query.UniqueResult());
        }
    }
}
