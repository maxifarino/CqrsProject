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
    public class VisitorBeneficiarioCreate : IVisitorBeneficiarioSave
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VisitorBeneficiarioCreate(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public override void Visit(BeneficiarioSave beneficiario)
        {

            //Se valida que la fecha de inscripcion sea mayor/igual q la creacion de la sala
            if (beneficiario.FechaAlta != null && VerificarFechaDeInscripcion(beneficiario.FechaAlta, beneficiario.SalitaId) != "N")
                this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_FECHA_INSCRIPCION + VerificarFechaDeInscripcion(beneficiario.FechaAlta, beneficiario.SalitaId));
            //Validamos que el beneficiario tenga una persona seleccionada
            if (beneficiario != null)
            {
                //VALIDACIONES BENEFICIARIO
                if (beneficiario.SexoId == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_SEXOID_NULL); }

                if (beneficiario.TipoDocumento != null && beneficiario.TipoDocumento.TipoDocumentoId != "GI")
                    if (beneficiario.NumeroDocumento == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DOCUMENTO_NULL); }

                if (beneficiario.CodigoPais == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_PAIS_ORIGEN_ID_NULL); }


                if (beneficiario.NumeroId == -1)
                {
                    if (beneficiario.Nombre == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_NOMBRE_NULL); }
                    if (beneficiario.Apellido == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_APELLIDO_NULL); }
                    if (beneficiario.FechaNacimiento == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_FECHA_NACIMIENTO_NULL); }
                    if (beneficiario.FechaNacimiento.HasValue && beneficiario.FechaNacimiento > DateTime.Today) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_FECHA_NACIMIENTO_MAX); }
                    if (beneficiario.TipoDocumento == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL); }
                    if (beneficiario.NacionalidadId == null) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_NACIONALIDAD_ID_NULL); }
                }

            }
            else
            {
                this.AddError(MessageError.BENEFICIARIO_PERSONA_SELECCIONADA_NULL);
            }

            if (beneficiario.AsistioGuarderia == true)
            {
                if (beneficiario.NombreGuarderia == null || (beneficiario.NombreGuarderia != null && String.IsNullOrEmpty(beneficiario.NombreGuarderia)))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_GUARDERIA_ID_NULL);
                }
            }

            if (beneficiario.EsAlergico == true)
            {
                if (beneficiario.DetalleAlergico == null || (beneficiario.DetalleAlergico != null && String.IsNullOrEmpty(beneficiario.DetalleAlergico)))
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
            if (String.IsNullOrEmpty(beneficiario.IdEnfermedad))
            {
                this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_ENFERMEDAD_NULL);
            }

            if (String.IsNullOrEmpty(beneficiario.IdDiscapacidad))
            {
                this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DISCAPACIDAD_NULL);
            }

            if (beneficiario.IdTieneObraSocial)
            {
                if (String.IsNullOrEmpty(beneficiario.IdObraSocial))
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_DETALLE_OBRA_SOCIAL_NULL);
                }
            }

            if (beneficiario.Especial)
            {
                if (!beneficiario.IdLeche.HasValue)
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_LECHE_NULL);
                }
                if (!beneficiario.IdPanial.HasValue)
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_PANIAL_NULL);
                }
                if (!beneficiario.IdMotivoEspecial.HasValue)
                {
                    this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_MOTIVO_NULL);
                }
            }

            if (String.IsNullOrEmpty(beneficiario.IdGrupoSanguineo)) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_GRUPO_SANGUINEO_NULL); }
            if (beneficiario.SalitaId == 0) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_SALITA_NULL); }
            if (beneficiario.FechaAlta == null || beneficiario.FechaAlta.Value.Date == DateTime.MinValue) { this.AddError(MessageError.BENEFICIARIO_SAVE_ERROR_FECHA_ALTA_NULL); }


            if (true)//   VALIDACION PARA CASO ESPECIAL SIN TUTOR    (!beneficiario.MayorEdad() && beneficiario.CasoEspecial) || !beneficiario.CasoEspecial)
            {
                //Validaciones TUTOR

                //Validamos que el Integrante tenga un tutor seleccionado
                if (beneficiario.Integrante != null)
                {
                    if (beneficiario.Integrante.SexoId == null || String.IsNullOrEmpty(beneficiario.Integrante.SexoId)) { this.AddError(MessageError.TUTOR_SAVE_ERROR_SEXOID_NULL); }

                    if (beneficiario.Integrante.Indocumentado == false && beneficiario.Integrante.TipoDocumento != null && beneficiario.Integrante.TipoDocumento.TipoDocumentoId != "GI")
                        if (String.IsNullOrEmpty(beneficiario.Integrante.NumeroDocumento)) { this.AddError(MessageError.TUTOR_SAVE_ERROR_DOCUMENTO_NULL); }

                    if (String.IsNullOrEmpty(beneficiario.Integrante.CodigoPais)) { this.AddError(MessageError.TUTOR_SAVE_ERROR_PAIS_ORIGEN_ID_NULL); }


                    if (beneficiario.Integrante.NumeroId == -1)
                    {
                        if (beneficiario.Integrante.Nombre == null) { this.AddError(MessageError.TUTOR_SAVE_ERROR_NOMBRE_NULL); }
                        if (beneficiario.Integrante.Apellido == null) { this.AddError(MessageError.TUTOR_SAVE_ERROR_APELLIDO_NULL); }
                        if (beneficiario.Integrante.FechaNacimiento == null) { this.AddError(MessageError.TUTOR_SAVE_ERROR_FECHA_NACIMIENTO_NULL); }
                        if (beneficiario.Integrante.FechaNacimiento.HasValue && beneficiario.Integrante.FechaNacimiento > DateTime.Today) { this.AddError(MessageError.TUTOR_SAVE_ERROR_FECHA_NACIMIENTO_MAX); }
                        if (beneficiario.Integrante.TipoDocumento == null) { this.AddError(MessageError.TUTOR_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL); }
                        if (beneficiario.Integrante.NacionalidadId == null) { this.AddError(MessageError.TUTOR_SAVE_ERROR_NACIONALIDAD_ID_NULL); }
                        if (String.IsNullOrEmpty(beneficiario.Integrante.EstadoCivilId)) { this.AddError(MessageError.INTEGRANTE_SAVE_ERROR_ESTADO_CIVIL_ID_NULL); }
                    }

                    if (beneficiario.Integrante.IdTieneObraSocial && String.IsNullOrEmpty(beneficiario.Integrante.IdObraSocial))
                    {
                        this.AddError(MessageError.TUTOR_SAVE_ERROR_OBRA_SOCIAL_ID_NULL);
                    }

                    if (String.IsNullOrEmpty(beneficiario.Integrante.IdNivelEscolaridad)) { this.AddError(MessageError.TUTOR_SAVE_ERROR_NIVEL_ESCOLARIDAD_ID_NULL); }

                }
                else
                {
                    this.AddError(MessageError.BENEFICIARIO_INTEGRANTE_NULL);
                }
            }
        }


        //Este metodo verifica que la fecha de inscripcion del beneficiario no sea anterior a la creacion de la sala
        //Si devuelve una fecha significa que la fecha de inscripcion es 'posterior o igual' la fecha de creacion de la sala
        //de lo contrario devolvera una N
        private string VerificarFechaDeInscripcion(DateTime? fechaInscripcion, int idSalita)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VERIFICAR_FECHA_INSCRIPCION(?,?)")
            .SetParameter(0, fechaInscripcion)
            .SetParameter(1, idSalita);

            return query.UniqueResult().ToString();
        }

    }
}