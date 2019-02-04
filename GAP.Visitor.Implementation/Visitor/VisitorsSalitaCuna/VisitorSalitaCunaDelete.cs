using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsSalitaCuna
{
    public class VisitorSalitaCunaDelete : IVisitorSalitaCuna
    {
        private static string ALREADY_EXISTS_BENEFICIARIOS = "S";
        private static string ALREADY_EXISTS_FECHA = "S";
        private readonly RepositoryLocalScheme _repositoryLocalScheme;

        public VisitorSalitaCunaDelete(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }
        public override void Visit(SalitaCuna salitaCuna)
        {
            if (salitaCuna.FechaBaja == DateTime.MinValue || DateTime.Parse(salitaCuna.FechaBaja.ToString()).Date > DateTime.Today.Date)
                this.AddError(MessageError.SALITA_FECHA_BAJA_NO_ASIGNADA);
            if (salitaCuna.Id < 1)
                this.AddError(MessageError.SALITA_SIN_ID_SALITA_CUNA);
            if (AllreadyExistFechaBajaSalita(salitaCuna.Id))
                this.AddError(MessageError.SALITA_POSEE_FECHABAJA);

        }
        public virtual bool AllreadyExistFechaBajaSalita(int idSalita)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VERIFICAR_FECHABAJA_SALITA(?)")
            .SetParameter(0, idSalita);
            return query.UniqueResult().ToString().Equals(ALREADY_EXISTS_FECHA);
        }
      
    }
}
