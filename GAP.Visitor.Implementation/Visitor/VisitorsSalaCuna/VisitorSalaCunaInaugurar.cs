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

namespace GAP.Visitor.Implementation.Visitor.VisitorsSalaCuna
{
    public class VisitorSalaCunaInaugurar : IVisitorSalaCuna
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        private static string INAUGURACION_MAYOR_TRAMITE = "N";

        public VisitorSalaCunaInaugurar(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }               

        /// <summary>
        /// En este metodo verificamos que no exista una sala cuna, El resultado "N" significa que no existe una sala cuna con los mismos datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool SalaCunaVerificarInauguracionConTramite(int Id, DateTime? FechaInauguracion)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VERIFICAR_FEC_INAUG_Y_TRAM(?,?)")
                .SetParameter(0, Id)
                .SetParameter(1, FechaInauguracion);
            

            var resultado = query.UniqueResult().ToString();
            return resultado.Equals(INAUGURACION_MAYOR_TRAMITE);
        }

        public override void Visit(SalaCuna salaCuna)
        {
            DateTime? fechainaug = salaCuna.FechaInauguracion;

            if (salaCuna.FechaInauguracion != null && SalaCunaVerificarInauguracionConTramite(salaCuna.Id, fechainaug))
                this.AddError(MessageError.SALA_CUNA_UPDATE_ERROR_FECHA_TRAMITE_MAYOR_INAUGURACION);
        }
    }
}
