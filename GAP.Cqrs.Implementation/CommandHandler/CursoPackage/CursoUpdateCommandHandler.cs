using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class CursoUpdateCommandHandler: ICommandHandler<CursoUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly CursoServiceBusiness _cursoServiceBusiness;


        public CursoUpdateCommandHandler(RepositoryLocalScheme repositryLocalScheme, CursoServiceBusiness cursoServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _cursoServiceBusiness = cursoServiceBusiness;
        }


        public Result Execute(CursoUpdateCommand command)
        {
            Result result = new Result();

            result.AddErrorsRange(_cursoServiceBusiness.ValidateUpdate(command.Curso).GetErrors());

            if (string.IsNullOrEmpty(command.Curso.Salas))
            {
                result.AddError("Debe seleccionar al menos una sala cuna");
            }

            if (string.IsNullOrEmpty(command.Curso.Cargos))
            {
                result.AddError("Debe seleccionar al menos un cargo");
            }

            if (result.success)
                CursoUpdate(command, ref result);

            return result;
        }

        private void CursoUpdate(CursoUpdateCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_MODIFICAR_CURSO(?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.Curso.Id);
            query.SetParameter(3, command.Curso.Nombre);
            query.SetParameter(4, command.Curso.Descripcion);
            query.SetParameter(5, command.Curso.CantDias);
            query.SetParameter(6, command.Curso.HorasPorDia);
            query.SetParameter(7, command.Curso.Porcentaje);
            query.SetParameter(8, command.Curso.Ente);
            query.SetParameter(9, command.Curso.FechaInicio);
            query.SetParameter(10, command.Curso.FechaFin);
            query.SetParameter(11, command.Curso.Cargos);
            query.SetParameter(12, command.Curso.Salas);
            query.SetParameter(13, command.Curso.IdZona);

            result.Resolve(query.UniqueResult());

        }

    }
}
