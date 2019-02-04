using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using GAP.Domain.Entities;
using GAP.Base;

namespace GAP.Visitor.Implementation.Visitor.VisitorIntegrante
{
    public class VisitorIntegranteSave : IVisitorIntegrante
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public VisitorIntegranteSave(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public override void Visit(Beneficiario beneficiario)
        {

            //Validamos que el beneficiario exista
            if (beneficiario.PersonaSeleccionada != null)
            {
                if (beneficiario.PersonaSeleccionada.SexoId == null ||
                    beneficiario.PersonaSeleccionada.NumeroId == null ||
                    string.IsNullOrEmpty(beneficiario.PersonaSeleccionada.CodigoPais) ||
                    string.IsNullOrEmpty(beneficiario.PersonaSeleccionada.NumeroDocumento))
                {
                    this.AddError(MessageError.BENEFICIARIO_PERSONA_SELECCIONADA_NULL);
                }

            }
            else
            {
                this.AddError(MessageError.BENEFICIARIO_PERSONA_SELECCIONADA_NULL);
            }

            //INICIO VALIDACION DEL INTEGRANTE A REGISTRAR O EDITAR
            foreach (Integrante integrante in beneficiario.ListIntegrantes)
            {
                if (string.IsNullOrEmpty(integrante.Vinculo.Id)) {
                    this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_VINCULO_ID_NULL); 
                }
                //Validamos que el beneficiario exista
                if (integrante.PersonaSeleccionada != null)
                {
                    if (integrante.PersonaSeleccionada.SexoId == null) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_SEXOID_NULL); }

                    if (integrante.PersonaSeleccionada.NumeroId == -1)
                    {
                        if (string.IsNullOrEmpty(integrante.PersonaSeleccionada.Nombre)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_NOMBRE_NULL); }
                        if (string.IsNullOrEmpty(integrante.PersonaSeleccionada.Apellido)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_APELLIDO_NULL); }
                        if (integrante.PersonaSeleccionada.FechaNacimiento == null) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_FECHA_NACIMIENTO_NULL); }
                        if (integrante.PersonaSeleccionada.FechaNacimiento.HasValue && integrante.PersonaSeleccionada.FechaNacimiento > DateTime.Today) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_FECHA_NACIMIENTO_MAX); }
                        if (string.IsNullOrEmpty(integrante.PersonaSeleccionada.TipoDocumentoId)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL); }
                        if (string.IsNullOrEmpty(integrante.PersonaSeleccionada.CodigoPais)){this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_PAIS_ORIGEN_NULL);}
                        if (string.IsNullOrEmpty(integrante.NacionalidadId)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_NACIONALIDAD_ID_NULL); }
                        if (string.IsNullOrEmpty(integrante.EstadoCivilId)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_ESTADO_CIVIL_ID_NULL); }
                    }
                    else
                    {
                        if (integrante.PersonaSeleccionada.NumeroId == null ||
                            string.IsNullOrEmpty(integrante.PersonaSeleccionada.CodigoPais) ||
                            string.IsNullOrEmpty(integrante.PersonaSeleccionada.NumeroDocumento))
                        {
                            this.AddError(MessageError.INTEGRANTE_PERSONA_SELECCIONADA_NULL);
                        }
                    }

                }
                else
                {
                    this.AddError(MessageError.INTEGRANTE_PERSONA_SELECCIONADA_NULL);
                }

                //VALIDACION DE LAS CARACTERISTICAS
                if (integrante.Caracteristica.TieneObraSocial.IdCaracteristica != null &&
                    integrante.Caracteristica.TieneObraSocial.IdCaracteristica == "S" && integrante.Caracteristica.ObraSocial.IdCaracteristica == null)
                {
                    this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_OBRA_SOCIAL_ID_NULL);
                }

                if (string.IsNullOrEmpty(integrante.Caracteristica.Discapacidad.IdCaracteristica))
                {
                    this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_DISCAPACIDAD_ID_NULL);
                }
                if (string.IsNullOrEmpty(integrante.Caracteristica.Enfermedad.IdCaracteristica))
                {
                    this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_ENFERMEDAD_ID_NULL);
                }

                if (integrante.OtroAporteSeleccionado && string.IsNullOrEmpty(integrante.OtroAporte)) {
                    this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_OTRO_APORTE_NULL);
                }
            }

        }
    }
}
