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
    public class VisitorSalitaCunaSave : IVisitorSalitaCuna
    {
        private int numero;
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        public VisitorSalitaCunaSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }

        private string ExisteTurno(SalitaCuna salita)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VALIDAR_TURNOS_SALITA(?,?)")
            .SetParameter(0, salita.SalaCunaId)
             .SetParameter(1, salita.TurnoSalitaId);
            var resultado = query.UniqueResult().ToString();
            return resultado;
        }

        public override void Visit(SalitaCuna salitaCuna)
        {

            if (ExisteTurno(salitaCuna) =="S")
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

            if (salitaCuna.SalaCunaId <= 0)
                this.AddError(MessageError.SALITA_SIN_ID_SALA_CUNA);

        }
    }
}
