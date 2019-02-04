using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.InmueblePackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceInmueble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.InmueblePackage
{
    public class InmuebleSaveCommandHandler : ICommandHandler<InmuebleSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly InmuebleServiceBusiness _inmuebleServiceBusiness;

        public InmuebleSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, InmuebleServiceBusiness inmuebleServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _inmuebleServiceBusiness = inmuebleServiceBusiness;
        }

        public Result Execute(InmuebleSaveCommand command)
        {
            Result result = new Result();
            result = _inmuebleServiceBusiness.ValidateSave(command.Inmueble);

            if (result.success){
                SaveInmueble(command, ref result);}

            return result;
                       
        }

        private void SaveInmueble(InmuebleSaveCommand command, ref Result result)
        {
            //TODO Agustin: Llamar a SP para guardar Inmueble, asignar parametros y ejecutar la query.
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_INMUEBLE(?,?,?,?,?)")
                .SetParameter(0, command.Inmueble.Descripcion)//id aplicacion                
                .SetParameter(1, command.Inmueble.Monto)
                .SetParameter(2, command.Inmueble.FechaRealizacion)
                .SetParameter(3, command.SalaCunaId)
                .SetParameter(4, command.UsuarioLogueadoId);

            result.Resolve(query.UniqueResult());
        }
    }
}
