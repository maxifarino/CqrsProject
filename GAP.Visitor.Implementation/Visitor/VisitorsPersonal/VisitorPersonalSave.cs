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
    public class VisitorPersonalSave : IVisitorPersonal
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private static string PUEDE = "S";
        private static DateTime? fechaHoy = DateTime.Today;

        public VisitorPersonalSave(RepositoryLocalScheme repository)
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

        private DateTime FechaCreacion(Personal personal)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_OBTENER_FECHA_CREACION_SC(?)")
            .SetParameter(0, personal.SalaCunaId);

            string resultado = query.UniqueResult().ToString();
            //var array = resultado.Split('-');
            //var fecha = new DateTime(Convert.ToDateTime(resultado));

            DateTime fechaCreacionSalaCuna = Convert.ToDateTime(resultado);
            return fechaCreacionSalaCuna;
        }

        private string Conflictiva(Personal personal)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PR_VALIDAR_CONFLICTIVA(?,?,?,?)")
            .SetParameter(0, personal.PersonaSeleccionada.NumeroDocumento)
            .SetParameter(1, personal.PersonaSeleccionada.NumeroId)
            .SetParameter(2, personal.PersonaSeleccionada.SexoId)
            .SetParameter(3, personal.PersonaSeleccionada.CodigoPais);

            string resultado = query.UniqueResult().ToString();
            //var array = resultado.Split('-');
            //var fecha = new DateTime(Convert.ToDateTime(resultado));
            return resultado;
        }

        public override void Visit(Personal personal)
        {
            if (!personal.SalitaID.HasValue)
                this.AddError(MessageError.PERSONAL_TURNO);

            if (!personal.FechaAsignacion.HasValue)
                this.AddError(MessageError.PERSONAL_FECHA);

            if (!personal.IdCargo.HasValue)
                this.AddError(MessageError.PERSONAL_CARGO);

            foreach (var requisito in personal.requisitos)
            {
                if (requisito.Estado == true && !requisito.fechaPresentacion.HasValue)
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

            if (personal.PersonaSeleccionada != null)
            {
                //if (!puedeRegistrar(personal))
                //{
                //    this.AddError(MessageError.PERSONAL_SAVE_ERROR_DOS_TURNOS); 
                //}
                if (personal.SalitaID.HasValue)
                {
                    string resultadoTurno = puedeRegistrar(personal);

                    if (resultadoTurno != "S")
                    {
                        this.AddError(resultadoTurno);
                    }

                    if (personal.FechaAsignacion < FechaCreacion(personal))
                    {
                        this.AddError(MessageError.PERSONAL_SAVE_ERROR_FECHA_ASIG);
                    }
                }

                if (personal.PersonaSeleccionada.SexoId == null || personal.PersonaSeleccionada.SexoId == "") { this.AddError(MessageError.PERSONAL_SAVE_ERROR_SEXOID_NULL); }

                if (personal.PersonaSeleccionada.NumeroId == -1)
                {
                    if (string.IsNullOrEmpty(personal.PersonaSeleccionada.Nombre)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_NOMBRE_NULL); }
                    if (string.IsNullOrEmpty(personal.PersonaSeleccionada.Apellido)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_APELLIDO_NULL); }
                    if (personal.PersonaSeleccionada.FechaNacimiento == null) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_FECHA_NACIMIENTO_NULL); }
                    if (personal.PersonaSeleccionada.FechaNacimiento.HasValue && personal.PersonaSeleccionada.FechaNacimiento > DateTime.Today) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_FECHA_NACIMIENTO_MAX); }
                    if (!personal.PersonaSeleccionada.Indocumentado)
                    {
                        if (string.IsNullOrEmpty(personal.PersonaSeleccionada.TipoDocumentoId)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL); }
                    }
                    if (string.IsNullOrEmpty(personal.NacionalidadId)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_NACIONALIDAD_ID_NULL); }
                    if (string.IsNullOrEmpty(personal.PersonaSeleccionada.CodigoPais)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_PAIS_ID_NULL); }
                    if (string.IsNullOrEmpty(personal.PersonaSeleccionada.EstadoCivilId)) { this.AddError(MessageError.PERSONAL_SAVE_ERROR_ESTADO_CIVIL_ID_NULL); }
                }
                else
                {
                    if (personal.PersonaSeleccionada.NumeroId == null ||
                        string.IsNullOrEmpty(personal.PersonaSeleccionada.CodigoPais) ||
                        string.IsNullOrEmpty(personal.PersonaSeleccionada.NumeroDocumento))
                    {
                        this.AddError(MessageError.PERSONAL_PERSONA_SELECCIONADA_NULL);
                    }
                }
            }
            else
            {
                this.AddError(MessageError.PERSONAL_PERSONA_SELECCIONADA_NULL);
            }
        }
    }
}
