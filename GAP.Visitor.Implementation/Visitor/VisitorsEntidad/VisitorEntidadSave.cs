using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorsEntidad
{
    public class VisitorEntidadSave : IVisitorEntidad
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static string ALREADY_EXIST_ENTIDAD_CREATED = "S";

        public VisitorEntidadSave(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public override void Visit(Entidad entidad)
        {
            if (string.IsNullOrEmpty(entidad.RazonSocial))
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_RAZON_SOCIAL);
                      
            if (!string.IsNullOrEmpty(entidad.RazonSocial) && entidad.RazonSocial.Length > 150)
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_RAZON_SOCIAL_LENGTH);

            if (!string.IsNullOrEmpty(entidad.NombreFantasia) && entidad.NombreFantasia.Length > 150)
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_NOMBRE_FANTASIA_LENGTH);

            if (string.IsNullOrEmpty(entidad.Cuit))
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_CUIL);

            if (!string.IsNullOrEmpty(entidad.Cuit) && entidad.Cuit.Length != 11)
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_FORMATO_CUIL);

            if (entidad.FormaJuridicaId == null)
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_FORMAJURIDICA_ID);

            if (!string.IsNullOrEmpty(entidad.RazonSocial) && AlreadyExistEntidad(entidad.RazonSocial, entidad.Cuit))
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_ALREADY_EXIST_ENTIDAD);
            #region EntidadBancaria

            if (entidad.EntidadBancariaId != null && entidad.SucursalId == null && string.IsNullOrEmpty(entidad.CbuBancaria) && string.IsNullOrEmpty(entidad.NumeroDeCuentaBancaria))
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_ENTIDAD_BANCARIA);

            if (entidad.Responsable == null)
                this.AddError(MessageError.ENTIDAD_SAVE_ERROR_RESPONSABLE);

            #endregion
        }

        /// <summary>
        /// En este metodo verificamos que no exista una entidad, El resultado "N" significa que no existe una entidad con el mismo nombre.
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <param name="cuit"></param>
        /// <returns></returns>
        public virtual bool AlreadyExistEntidad(string razonSocial, string cuit)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_DUPLICADO_ENTIDAD(?,?)")
            .SetParameter(0, cuit)
            .SetParameter(1, razonSocial);

            return query.UniqueResult().ToString().Equals(ALREADY_EXIST_ENTIDAD_CREATED);
        }
    }
}
