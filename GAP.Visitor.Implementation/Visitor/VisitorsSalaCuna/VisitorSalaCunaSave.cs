using GAP.Base;
using GAP.Base.Helper;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsSalaCuna
{
    public class VisitorSalaCunaSave : IVisitorSalaCuna
    {
        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        private static string ALREADY_EXIST_SALA_CUNA_CREATED = "S";

        public VisitorSalaCunaSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }

        /// <summary>
        /// En este metodo verificamos que no exista una sala cuna, El resultado "N" significa que no existe una sala cuna con los mismos datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool SalaCunaAlreadyExists(SalaCuna salaCuna)
        {
            var query = _repositoryLocalScheme.Session.CallFunction("PR_VERIFICAR_DUPLICADO_SC(?,?)")

            .SetParameter(0, -1)
            .SetParameter(1, salaCuna.Codigo);

            var resultado = query.UniqueResult().ToString();
            return resultado.Equals(ALREADY_EXIST_SALA_CUNA_CREATED);
        }

        public override void Visit(SalaCuna salaCuna)
        {
            if (string.IsNullOrEmpty(salaCuna.Nombre))
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_NOMBRE);

            if (salaCuna.FechaInicioTramite == null)
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_FECHA_INICIO_TRAMITE);

            if (salaCuna.Entidad == null || string.IsNullOrEmpty(salaCuna.Entidad.Cuit))
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_ENTIDAD_SELECCIONADA);

            if (salaCuna.Responsable == null || string.IsNullOrEmpty(salaCuna.Responsable.NumeroDocumento))
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_RESPONSABLE_SELECCIONADO);

            if (salaCuna.Entidad != null && salaCuna.Entidad.Sede != null && SalaCunaAlreadyExists(salaCuna))
                this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_ALREADY_EXIST_SALA_CUNA);

            bool result = DateTimeHelper.After(salaCuna.FechaInicioTramite, DateTime.Today);
            if (result) { this.AddError(MessageError.SALA_CUNA_SAVE_ERROR_FECHA_MAYOR_ACTUAL); }

            if (salaCuna.Capital == null)
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_CAPITAL);

            if (salaCuna.EntidadBancariaId != null && (salaCuna.SucursalId == null || string.IsNullOrEmpty(salaCuna.CbuBancaria) || string.IsNullOrEmpty(salaCuna.NumeroDeCuentaBancaria)))
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_ENTIDAD_BANCARIA);

            if (String.IsNullOrEmpty(salaCuna.Codigo) || salaCuna.Codigo == null)
                this.AddError(MessageError.SALA_CUNA_DELETE_ERROR_CODIGO);
        }
    }
}
