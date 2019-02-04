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

namespace GAP.Cqrs.Implementation.CommandHandler.PersonalPackage
{
    public class PersonalBajaCommandHandler : ICommandHandler<PersonalBajaCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonalBajaCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public Result Execute(PersonalBajaCommand command)
        {
            //Result result1 = null;
            Result result1 = new Result();
                //_salaCunaServiceBusiness.ValidateInaugurar(command.SalaCuna);

            //if (result1.success)
            //{
            DarBajaPersonal(command, ref result1);
            
            return result1;
        }

        private void DarBajaPersonal(PersonalBajaCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_DAR_BAJA_PERSONAL(?,?,?,?,?,?)")
                .SetParameter(0, command.Personal.PersonalId)
                .SetParameter(1, command.Personal.SalitaId)
                .SetParameter(2, command.Personal.FechaBaja)
                .SetParameter(3, command.idUsuarioLogueado)
                .SetParameter(4, command.Personal.ComentarioBaja)
                .SetParameter(5, command.Personal.EsPersonaConflictiva == true ? 1 : -1);
                
            result.Resolve(query.UniqueResult());
        }
    }
}
