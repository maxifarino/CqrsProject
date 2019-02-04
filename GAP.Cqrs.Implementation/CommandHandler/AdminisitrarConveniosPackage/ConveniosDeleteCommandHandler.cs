using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.AdministrarConvenios;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceAdministrarConvenios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.AdminisitrarConvenios
{
    public class ConveniosDeleteCommandHandler : ICommandHandler<ConveniosDeleteCommand>{
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly ConveniosServiceBusiness _conveniosServiceBusiness;

           public ConveniosDeleteCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        
           public Result Execute(ConveniosDeleteCommand command)
           {
               
               Result result = new Result();
               StringBuilder builder = new StringBuilder();
               var query = _repositryLocalScheme.Session
                    .CallFunction("PCK_SALAS_CUNA.PR_ELIMINAR_CVN_SC(?,?)")
                   .SetParameter(0, command.convenio.Id)
                   .SetParameter(1, 1); //cambiar despues

               result.Resolve(query.UniqueResult());

               return result;
           }

         

    }
}
