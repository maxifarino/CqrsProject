using GAP.Base;
using GAP.Base.Helper;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsAdministrarRequisitos
{
    public class VisitorRequisitosSave : IvisitorRequisito
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
     
        

        public VisitorRequisitosSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }


        private DateTime FechaCreacion(short? idSalaCuna)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_OBTENER_FECHA_CREACION_SC(?)")
            .SetParameter(0, idSalaCuna);

            var resultado = query.UniqueResult().ToString();
            DateTime fechaCreacionSalaCuna = Convert.ToDateTime(resultado);
            return fechaCreacionSalaCuna;
        }

        public override void Visit(Requisito requisito)
        {
            if (requisito.fechaPresentacion > DateTime.Today && requisito.fechaPresentacion != null)
                this.AddError(MessageError.REQUISITO_SAVE_ERROR_FECHA_MAYOR_HOY);

            if (requisito.fechaPresentacion == null && requisito.Estado ==true)
                this.AddError(MessageError.REQUISITO_SAVE_ERROR_FECHA_NULL);

            if (requisito.fechaPresentacion > requisito.fechaVigenciaHasta)
                this.AddError(MessageError.REQUISITO_SAVE_ERROR_FECHA_PRESENTACION_MAYOR_VIGENCIA);

            if (DateTimeHelper.Before(requisito.fechaPresentacion, FechaCreacion(requisito.IdSalaCuna)))
                this.AddError(MessageError.REQUISITO_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION);
        
        }
    }
}
