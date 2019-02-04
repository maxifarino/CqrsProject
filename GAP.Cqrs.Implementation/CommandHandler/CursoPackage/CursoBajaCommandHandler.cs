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

namespace GAP.Cqrs.Implementation.CommandHandler.CursoPackage
{
    public class CursoBajaCommandHandler : ICommandHandler<CursoBajaCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public CursoBajaCommandHandler(RepositoryLocalScheme repositoryLocalScheme)
        {
            _repositryLocalScheme = repositoryLocalScheme;
        }

        public Result Execute(CursoBajaCommand command)
        {
            Result result1 = new Result();
             
            DarBajaCurso(command, ref result1);
            
            return result1;
        }

        private void DarBajaCurso(CursoBajaCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_DAR_BAJA_CURSO(?,?,?,?)")
                .SetParameter(0, command.Curso.IdCurso)
                .SetParameter(1, command.Curso.FechaBaja)
                .SetParameter(2, command.idUsuarioLogueado)
                .SetParameter(3, command.Curso.ComentarioBaja);
                
            result.Resolve(query.UniqueResult());
        }
    }
}
