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
    public class BajaBeneficiarioCommandHandler : ICommandHandler<BajaBeneficiarioCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly BeneficiarioServiceBusiness _beneficiarioServiceBusiness;

        public BajaBeneficiarioCommandHandler(RepositoryLocalScheme repositoryLocalScheme, BeneficiarioServiceBusiness beneficiarioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _beneficiarioServiceBusiness = beneficiarioServiceBusiness;
        }

        public Result Execute(BajaBeneficiarioCommand command)
        {
            Result result = new Result();//_beneficiarioServiceBusiness.ValidateDeleteFisic();

            if (result.success)
                BajaBeneficiario(command, ref result);

            return result;
        }

        private void BajaBeneficiario(BajaBeneficiarioCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_BAJA_BENEFICIARIO(?,?,?,?,?)")
                .SetParameter(0, command.BeneficiarioId)              
                .SetParameter(1, command.UsuarioId)
                //enviar fecha de hoy como fecha fec_fin_inscripcion
                .SetParameter(2, DateTime.Now)
                .SetParameter(3, command.ComentarioBaja)
                .SetParameter(4, command.SalitaCunaId);

            result.Resolve(query.UniqueResult());
        }
    }
}
