using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsPersonal
{
    public class VisitorPersonalUpdate : IVisitorPersonal
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static string PUEDE = "S";
        private static DateTime? fechaHoy = DateTime.Today;


        public VisitorPersonalUpdate(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }


        private string puedeRegistrar(Personal personal)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VALIDAR_TURNOS_PERSONAL(?,?,?,?,?)")
            .SetParameter(0, personal.PersonaSeleccionada.SexoId)
            .SetParameter(1, personal.PersonaSeleccionada.NumeroDocumento)
            .SetParameter(2, personal.PersonaSeleccionada.CodigoPais)
            .SetParameter(3, personal.PersonaSeleccionada.NumeroId)
            .SetParameter(4, personal.SalitaID);

            return query.UniqueResult().ToString();
        }



         public override void Visit(Personal personal)
       {
           

           if (!personal.IdCargo.HasValue)
               this.AddError(MessageError.PERSONAL_CARGO);

           foreach (var requisito in personal.requisitos)
           {
               if (requisito.Estado ==true && !requisito.fechaPresentacion.HasValue)
               {
                   this.AddError(MessageError.PERSONAL_FECHA_PRESENTACION);
                   break;
               }

               if (requisito.fechaPresentacion.HasValue && requisito.fechaPresentacion > fechaHoy)
               {
                   this.AddError(MessageError.PERSONAL_FECHA_MAYOR_ACTUAL);
                   break;
               }
           }

    }
}
}
