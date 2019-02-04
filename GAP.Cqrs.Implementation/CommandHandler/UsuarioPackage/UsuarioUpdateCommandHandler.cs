using GAP.Base.Helper;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.UsuarioPackage;
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
    public class UsuarioUpdateCommandHandler : ICommandHandler<UsuarioUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly UsuarioServiceBusiness _usuarioServiceBusiness;
        private readonly RolServiceBusiness _rolServiceBusiness;
        public UsuarioUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, UsuarioServiceBusiness usuarioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _usuarioServiceBusiness = usuarioServiceBusiness;

        }
        public Result Execute(UsuarioUpdateCommand command)
        {
            Result result;
            result = _usuarioServiceBusiness.ValidateUpdate(command.usuario);
            if (result.success)
                UpdateUsuarioRoles(command, ref result);
            return result;
        }
        private void UpdateUsuarioRoles(UsuarioUpdateCommand command, ref Result result)
        {

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_USUARIO_ROLES(?,?,?)")

                .SetParameter(0, command.usuario.IdUsuario)//
                .SetParameter(1, command.usuario.idRol)//
                .SetParameter(2, command.usuario.Id);//id usuario

            result.Resolve(query.UniqueResult());
        }
    }
}
