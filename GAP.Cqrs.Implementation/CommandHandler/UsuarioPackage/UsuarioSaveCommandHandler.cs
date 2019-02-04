using GAP.Base;
using GAP.Base.Exceptions;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.UsuarioPackage;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage
{
    public class UsuarioSaveCommandHandler : ICommandHandler<UsuarioSaveCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly UsuarioServiceBusiness _usuarioServiceBusiness;
        private readonly RolServiceBusiness _rolServiceBusiness;

        public UsuarioSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, UsuarioServiceBusiness usuarioServiceBusiness, RolServiceBusiness rolServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _usuarioServiceBusiness = usuarioServiceBusiness;
            _rolServiceBusiness = rolServiceBusiness;
        }

        public Result Execute(UsuarioSaveCommand command)
        {
            Result result;
            result = _usuarioServiceBusiness.ValidateSave(command.usuario);
           // result.AddErrorsRange(_rolServiceBusiness.ValidateSave(command.usuario.rol).GetErrors());

            if (result.success)
                SaveUsuarioRoles(command, ref result);

            return result;
        }


        private void SaveUsuarioRoles(UsuarioSaveCommand command, ref Result result)
        {
            //TODO Agustin: Llamar a SP para guardar Usuario, asignar parametros y ejecutar la query.
            StringBuilder builder = new StringBuilder();
            
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_USUARIO_ROLES(?,?,?)")
                
                .SetParameter(0, command.usuario.Cuil)//cuil
                .SetParameter(1, command.usuario.rol)
                .SetParameter(2, command.usuario.Id);//id roles de la forma "1,2,3,4"
           
            result.Resolve(query.UniqueResult());
   
        }

    }
}
