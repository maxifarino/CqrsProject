using GAP.Base;
using GAP.Base.ResultValidation;
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
    public class InmuebleUpdateCommandHandler : ICommandHandler<InmuebleUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly InmuebleServiceBusiness _inmuebleServiceBusiness;

          public InmuebleUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, InmuebleServiceBusiness inmuebleServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _inmuebleServiceBusiness = inmuebleServiceBusiness;
        }


          public Result Execute(InmuebleUpdateCommand command)
          {
              Result result = _inmuebleServiceBusiness.ValidateSave(command.inmueble);

              if (result.success)
                  UpdateInmueble(command, ref result);

              return result;
          }

          private void UpdateInmueble(InmuebleUpdateCommand command, ref Result result)
          {
              //TODO Agustin: Llamar a SP para guardar Inmueble, asignar parametros y ejecutar la query.
              StringBuilder builder = new StringBuilder();
              var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_INM_SC(?,?,?,?,?)")
                  .SetParameter(0, command.inmueble.Id)//id aplicacion                
                  .SetParameter(1, command.inmueble.Descripcion)
                  .SetParameter(2, command.inmueble.FechaRealizacion)
                  .SetParameter(3, command.inmueble.Monto)
                  .SetParameter(4, command.idUsuarioLogueado)
                  ;

              result.Resolve(query.UniqueResult());
          }
    }
}
