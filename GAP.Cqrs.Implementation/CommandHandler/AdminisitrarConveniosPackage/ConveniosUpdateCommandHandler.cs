using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceAdministrarConvenios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.AdminisitrarConveniosPackage
{
    public class ConveniosUpdateCommandHandler : ICommandHandler<ConveniosUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly ConveniosServiceBusiness _conveniosServiceBusiness;

        public ConveniosUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, ConveniosServiceBusiness convenioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _conveniosServiceBusiness = convenioServiceBusiness;
        }

        public Result Execute(ConveniosUpdateCommand command)
        {
            Result result = new Result();

            result = _conveniosServiceBusiness.ValidateSave(command.convenio);
            if (result.success)
            {
                UpdateConvenio(command, ref result);

            }

            else
            {
                result.AddError("Los convenios no han sido actualizados");
            }
            return result;

        }

        private void UpdateConvenio(ConveniosUpdateCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_CVN_SC(?,?,?,?,?,?)")
                .SetParameter(0, command.convenio.Id)
                .SetParameter(1,command.convenio.FechaDesde)
                .SetParameter(2, command.convenio.FechaHasta)
                .SetParameter(3, command.convenio.Monto)
                .SetParameter(4, command.convenio.Observacion)
                .SetParameter(5, command.idUsuarioLogueado);

            result.Resolve(query.UniqueResult());
        }


    }
}
