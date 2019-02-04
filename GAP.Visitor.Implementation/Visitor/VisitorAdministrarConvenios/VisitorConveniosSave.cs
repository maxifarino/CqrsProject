using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorAdministrarConvenios
{
    public class VisitorConveniosSave : IvisitorConvenio
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;

        public VisitorConveniosSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }
        private string FechaCreacion(Convenio convenio)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_OBTENER_FECHA_CREACION_SC(?)")
            .SetParameter(0, convenio.SalaCunaId);

            var resultado = query.UniqueResult().ToString();
            //var array = resultado.Split('-');
            //var fecha = new DateTime(Convert.ToDateTime(resultado));
            return resultado;
        }

        public override void Visit(Convenio convenio)
        {
            //TODO Agustin: Agregar validaciones
            if (convenio.FechaDesde > convenio.FechaHasta) {
                this.AddError(MessageError.REQUISITO_SAVE_ERROR_FECHA_DESDE_MAYOR_HASTA);
            }

            if (convenio.FechaDesde < Convert.ToDateTime(FechaCreacion(convenio)))
            {
                this.AddError(MessageError.CONVENIO_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION);
            }
     
            if (convenio.FechaDesde == null)
            {
                this.AddError(MessageError.CONVENIO_SAVE_ERROR_FECHA_DESDE_NULL);
            }

            if (convenio.FechaHasta == null)
            {
                this.AddError(MessageError.CONVENIO_SAVE_ERROR_FECHA_HASTA_NULL);
            }
            // if(validarExistencia(requisito))
            //   this.AddError(MessageError.REQUISITO_SAVE_ERROR_EXIST);

        }

    }
}
