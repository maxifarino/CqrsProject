using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorBeneficiario
{
    public class VisitorBeneficiarioUpdate : IVisitorBeneficiario
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VisitorBeneficiarioUpdate(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public override void Visit(Beneficiario beneficiario)
        {
            //VALIDACIONES BENEFICIARIO
            if (beneficiario.PersonaSeleccionada.SexoId == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_SEXOID_NULL); }
            if (beneficiario.PersonaSeleccionada.NumeroDocumento == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DOCUMENTO_NULL); }
            if (beneficiario.PersonaSeleccionada.CodigoPais == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_PAIS_ORIGEN_ID_NULL); }


            if (beneficiario.AsistioGuarderia == true)
            {
                if (beneficiario.DetalleGuarderia == null || (beneficiario.DetalleGuarderia != null && String.IsNullOrEmpty(beneficiario.DetalleGuarderia)))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_GUARDERIA_ID_NULL);
                }
            }

            if (beneficiario.EsAlergico == true)
            {
                if (beneficiario.DetalleAlergia == null || (beneficiario.DetalleAlergia != null && String.IsNullOrEmpty(beneficiario.DetalleAlergia)))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_ALERGIA_ID_NULL);
                }
            }
            if (beneficiario.TomaMedicamentos == true)
            {
                if (beneficiario.DetalleMedicamento == null || (beneficiario.DetalleMedicamento != null && String.IsNullOrEmpty(beneficiario.DetalleMedicamento)))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_MEDICAMENTO_ID_NULL);
                }
            }

            if (beneficiario.Caracteristica.Enfermedad.IdCaracteristica == null)
            {
                this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_ENFERMEDAD_NULL);
            }


            if (beneficiario.Caracteristica.Discapacidad.IdCaracteristica == null)
            {
                this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DISCAPACIDAD_NULL);
            }

            if (beneficiario.Caracteristica.TieneObraSocial.IdCaracteristica == "S")
            {
                if (beneficiario.Caracteristica.ObraSocial.IdCaracteristica == null || (beneficiario.Caracteristica.ObraSocial.IdCaracteristica != null && String.IsNullOrEmpty(beneficiario.Caracteristica.ObraSocial.IdCaracteristica)))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_OBRA_SOCIAL_NULL);
                }
            }
            if (beneficiario.Caracteristica.GrupoSanguineo.IdCaracteristica == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_GRUPO_SANGUINEO_NULL); }
        }



    }
}