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
    public class VisitorSalitaCunaUpdate : IVisitorSalitaCuna
    {
        private static string ALREADY_EXISTS_FECHA = "S";
        private int numero;
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        public VisitorSalitaCunaUpdate(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }


        private string ExisteTurno(SalitaCuna salita)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VALIDAR_SALITA_UPDATE(?,?)")
            .SetParameter(0, salita.Id)
             .SetParameter(1, salita.TurnoSalitaId);
            var resultado = query.UniqueResult().ToString();
            return resultado;
        }

        public override void Visit(SalitaCuna salitaCuna)
        {

            if (ExisteTurno(salitaCuna) == "S")
            {
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_TURNO_DUPLICADO);
            }

            if (!String.IsNullOrEmpty(salitaCuna.CupoSalita))
            {
                if (!int.TryParse(salitaCuna.CupoSalita, out numero))
                    this.AddError(MessageError.SALITA_CUPO_VALOR_NO_NUMERICO);
            }

            if (salitaCuna.TurnoSalitaId <= 0)
                this.AddError(MessageError.SALITA_TURNO_NO_ASIGNADO);

            if (salitaCuna.FechaBaja == DateTime.MinValue)
                salitaCuna.FechaBaja = null;

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
