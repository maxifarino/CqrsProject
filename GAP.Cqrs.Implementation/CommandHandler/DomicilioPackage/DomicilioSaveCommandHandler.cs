using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.DomicilioEntity;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.Domicilio
{
    public class DomicilioSaveCommandHandler : ICommandHandler<DomicilioSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;

        public DomicilioSaveCommandHandler(RepositoryLocalScheme repositryLocalScheme, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _domicilioServiceBusiness = domicilioServiceBusiness;
        }

        public Result Execute(DomicilioSaveCommand command)
        {
            return _domicilioServiceBusiness.ValidateSave(command.Domicilio);
        }
    }
}
