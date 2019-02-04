using GAP.Base;
using GAP.Base.Enumerations;
using GAP.Base.Helper;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsSalaCuna
{
    public class VisitorSalaCunaDelete : IVisitorSalaCuna
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;

        public VisitorSalaCunaDelete(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }

        private bool EsEstadoProvisoria(int salaCunaId)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_ESTADO_SC_PROV(?)")
            .SetParameter(0, salaCunaId);

            var resultado = query.UniqueResult().ToString();
            return resultado.Equals("S");
        }

        public override void Visit(SalaCuna salaCuna)
        {
            if (salaCuna.FechaBaja == null || DateTimeHelper.SameOrBefore(salaCuna.FechaBaja, DateTime.MinValue))
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_FECHA_BAJA);

            if (DateTimeHelper.After(salaCuna.FechaBaja, DateTime.Today))
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_FECHA_BAJA_ACTUAL);

            if (EsEstadoProvisoria(salaCuna.Id)) 
            {
                if (DateTimeHelper.Before(salaCuna.FechaBaja, salaCuna.FechaInicioTramite))
                    this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_FECHA_BAJA_FECHA_TRAMITE);
            }
            else if (DateTimeHelper.Before(salaCuna.FechaBaja, salaCuna.FechaAltaDefinitiva))
            {
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_FECHA_BAJA_FECHA_DEFINITIVA);
            }

            if(string.IsNullOrEmpty(salaCuna.MotivoBaja))
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_MOTIVO_BAJA);
        }
    }
}
