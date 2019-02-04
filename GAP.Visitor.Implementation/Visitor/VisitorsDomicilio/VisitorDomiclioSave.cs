using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsDomicilio
{
    public class VisitorDomiclioSave : IVisitorDomicilio
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VisitorDomiclioSave(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public override void Visit(Domicilio entidad)
        {
            if (!entidad.DepartamentoId.HasValue || !entidad.LocalidadId.HasValue | !entidad.TipoCalleId.HasValue){
                this.AddError(MessageError.DOMICILIO_SAVE_ERROR);
            }

            if (string.IsNullOrEmpty(entidad.Direccion) && !entidad.CalleId.HasValue)
                this.AddError(MessageError.DOMICILIO_SAVE_ERROR);

            if (!entidad.CalleId.HasValue && string.IsNullOrEmpty(entidad.Direccion))
                this.AddError(MessageError.DOMICILIO_SAVE_ERROR);
        }
    }
}
