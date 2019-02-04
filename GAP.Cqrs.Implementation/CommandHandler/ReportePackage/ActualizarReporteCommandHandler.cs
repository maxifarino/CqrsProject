using GAP.Base;
using GAP.Base.Dto.Reportes;
using GAP.Base.Enumerations;
using GAP.Base.Helper;
using GAP.Base.Reportes;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Query.MadresBeneficiariosQuery;
using GAP.Cqrs.Implementation.Query.ReporteQuery;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.ReportePackage
{
    public class ActualizarReporteCommandHandler : ICommandHandler<ActualizarReporteCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public const String SP_NAME = "PCK_SALAS_CUNA.PR_REG_ACT_PROCESO_COLA(?,?,?,?,?)";

        public ActualizarReporteCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public Result Execute(ActualizarReporteCommand command)
        {
            Result result = new Result();
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction(SP_NAME)
                .SetParameter(0, command.IdUsuario.HasValue ? command.IdUsuario.Value.ToString() : "-1")
                .SetParameter(1, command.IdProcesoCola.HasValue ? command.IdProcesoCola.Value.ToString() : "-1")
                .SetParameter(2, command.IdEstado.HasValue ? command.IdEstado.Value.ToString() : "-1")
                .SetParameter(3, command.NombreProceso)
                .SetParameter(4, command.StringProceso);
            result.Resolve(query.UniqueResult());
            return result;
        }
    }
}
