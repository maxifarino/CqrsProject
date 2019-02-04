
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServicePerson.ServiceBusinessStructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler
{
    public class PersonSaveCommandHandler : ICommandHandler<PersonSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private readonly PersonServiceBusiness _personServiceBusiness;

        public PersonSaveCommandHandler(PersonServiceBusiness personServiceBusiness, RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
            _personServiceBusiness = personServiceBusiness;
        }

        public Result Execute(PersonSaveCommand command)
        {
            Result result = _personServiceBusiness.ValidateSave(command.Person);

            if (!result.HasError())
            {
                this._repositryLocalScheme.Create(command.Person);
                result.Resolve((Object)command.Person);
            }
            
            return result;
        }
    }
}
