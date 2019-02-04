using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorCurso
{
    public class VisitorCursoUpdate : IVisitorCurso
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private static string ALREADY_EXIST_CURSO_CREATED = "S";
        private static DateTime fechaHoy = DateTime.Today;
        public VisitorCursoUpdate(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public override void Visit(Curso curso)
        {
            if (string.IsNullOrEmpty(curso.Nombre))
                this.AddError(MessageError.CURSO_NOMBRE);

            if (!curso.CantDias.HasValue)
                this.AddError(MessageError.CURSO_CANT_DIAS);

            if (curso.HorasPorDia > 24 || curso.HorasPorDia < 0.5)
                this.AddError(MessageError.CURSO_CANT_HORAS);
            
            if (!curso.FechaInicio.HasValue)
                this.AddError(MessageError.CURSO_FECHA_INICIO);

            if (curso.Porcentaje > 100)
                this.AddError(MessageError.CURSO_PORCENTAJE_MAYOR);

            if (CursoAlreadyExists(curso))
                this.AddError(MessageError.CURSO_EXISTE);

            if (curso.FechaInicio.HasValue && curso.FechaInicio < curso.FechaAlta)
            {
                this.AddError(MessageError.CURSO_FECHA_INICIO_MENOR_FECHA_ALTA);
            }

            if (curso.FechaFin.HasValue && curso.FechaInicio.HasValue && curso.FechaFin < curso.FechaInicio)
            {
                this.AddError(MessageError.CURSO_FECHA_FIN_MENOR_FECHA_INICIO);
            }

        }

        private bool CursoAlreadyExists(Curso curso)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_DUPLICADO_CURSO(?,?,?,?)")
            .SetParameter(0, curso.Id)
            .SetParameter(1, curso.Nombre)
            .SetParameter(2, curso.FechaInicio)
            .SetParameter(3, curso.IdZona);

            var resultado = query.UniqueResult().ToString();
            return resultado.Equals(ALREADY_EXIST_CURSO_CREATED);
        }
    }
}
