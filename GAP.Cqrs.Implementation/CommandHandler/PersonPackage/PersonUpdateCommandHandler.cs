
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServicePerson.ServiceBusinessStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler
{
    public class PersonUpdateCommandHandler : ICommandHandler<PersonUpdateCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonServiceBusiness _personServiceBusiness;

        public PersonUpdateCommandHandler(PersonServiceBusiness personServiceBusiness, RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
            _personServiceBusiness = personServiceBusiness;
        }

        public Result Execute(PersonUpdateCommand command)
        {

            Result result = _personServiceBusiness.ValidateUpdate(command.Person);

            if (!result.HasError())
                this._repositryLocalScheme.Update(command.Person);

            return result;
        }
    }
}
