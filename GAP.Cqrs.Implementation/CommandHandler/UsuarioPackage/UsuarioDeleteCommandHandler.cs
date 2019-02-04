using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage
{
   public class UsuarioDeleteCommandHandler: ICommandHandler<UsuarioDeleteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly UsuarioServiceBusiness _usuarioServiceBusiness;

        public UsuarioDeleteCommandHandler(RepositoryLocalScheme repositoryLocalScheme, UsuarioServiceBusiness usuarioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _usuarioServiceBusiness = usuarioServiceBusiness;
        }
        public Result Execute(UsuarioDeleteCommand command)
        {
            Result result;
            result = _usuarioServiceBusiness.ValidateDelete(command.usuario);
            if (result.success)
                DeleteUsuario(command, ref result);
            return result;
        }
        private void DeleteUsuario(UsuarioDeleteCommand command, ref Result result)
        {

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_DAR_BAJA_USUARIO(?,?)")

                .SetParameter(0, command.usuario.IdUsuario)//
                .SetParameter(1, command.usuario.Id);//


            result.Resolve(query.UniqueResult());
        }
    }
}
