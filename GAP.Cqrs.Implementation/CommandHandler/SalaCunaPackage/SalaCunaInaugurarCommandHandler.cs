using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage
{
    public class SalaCunaInaugurarCommandHandler : ICommandHandler<SalaCunaInaugurarCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalaCunaServiceBusiness _salaCunaServiceBusiness;

        public SalaCunaInaugurarCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalaCunaServiceBusiness entidadServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salaCunaServiceBusiness = entidadServiceBusiness;
        }

        public Result Execute(SalaCunaInaugurarCommand command)
        {
            //Result result1 = null;
            Result result1 = _salaCunaServiceBusiness.ValidateInaugurar(command.SalaCuna);

            if (result1.success) { 
                InaugurarSalaCuna(command, ref result1);
            }

            return result1;
        }

        private void InaugurarSalaCuna(SalaCunaInaugurarCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INAUGURAR_SALA_CUNA(?,?,?)")
                .SetParameter(0, command.SalaCuna.Id)
                .SetParameter(1, command.idUsuarioLogueado)
                .SetParameter(2, command.SalaCuna.FechaInauguracion);
                

            result.Resolve(query.UniqueResult());
        }
    }
}