using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsInmueble
{
    public class VisitorInmuebleAdministrar : IVisitorInmueble
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;

        public VisitorInmuebleAdministrar(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }

        private string FechaCreacion(Inmueble inmueble)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_OBTENER_FECHA_CREACION_SC(?)")
            .SetParameter(0, inmueble.SalaCunaId);

            var resultado = query.UniqueResult().ToString();
            return resultado;
        }

        public override void Visit(Inmueble inmueble)
        {
            if (string.IsNullOrEmpty(inmueble.Descripcion))
                this.AddError(MessageError.INMUEBLE_DESCRIPCION_REQUERIDA);
            if (inmueble.Monto == null)
                this.AddError(MessageError.INMUEBLE_MONTO_REQUERID0);
            if (inmueble.FechaRealizacion == null || inmueble.FechaRealizacion.Value.Year == 1900)
                this.AddError(MessageError.INMUEBLE_FECHAREALIZACION_REQUERIDA);

            if (inmueble.FechaRealizacion < Convert.ToDateTime(FechaCreacion(inmueble)))
            {
                this.AddError(MessageError.INMUEBLE_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION);
            }
        }
    }
}
