using GAP.Base;
using GAP.Base.Helper;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceBeneficiario;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonaFisica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.BeneficiarioPackage
{
    public class BeneficiarioUpdateCommandHandler: ICommandHandler<BeneficiarioUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonaServiceBusiness _personaServiceBusiness;
        private readonly BeneficiarioServiceBusiness _beneficiarioServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;
        public BeneficiarioUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, BeneficiarioServiceBusiness beneficiarioServiceBusiness, PersonaServiceBusiness entidadServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _personaServiceBusiness = entidadServiceBusiness;
            _beneficiarioServiceBusiness = beneficiarioServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
        }
        public Result Execute(BeneficiarioUpdateCommand command)
        {
            Result result = _beneficiarioServiceBusiness.ValidateUpdate(command.Beneficiario);

            if (command.Beneficiario.Domicilio == null)
                result.AddError("Faltan datos obligatorios en el domicilio del beneficiario");
            else
                result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Beneficiario.Domicilio).GetErrors());

            if (result.success)
                BeneficiarioUpdate(command, ref result);

            return result;
        }

        private void BeneficiarioUpdate(BeneficiarioUpdateCommand command, ref Result result)
        {
            //En este metodo editamos todo el beneficiario y cada una de las caracteristica que tiene el beneficiario
            #region PersonaNiño

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_BENEF(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
            //Beneficiario
            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);

            query.SetParameter(2, command.Beneficiario.PersonaSeleccionada.SexoId);
            query.SetParameter(3, command.Beneficiario.PersonaSeleccionada.NumeroDocumento);
            query.SetParameter(4, command.Beneficiario.PersonaSeleccionada.CodigoPais);
            query.SetParameter(5, command.Beneficiario.PersonaSeleccionada.NumeroId);            
            #endregion
            //Caracteristica Beneficiario
            #region Beneficiario
            query.SetParameter(6, command.Beneficiario.AsistioGuarderia == true ? "S" : "N");
            query.SetParameter(7, command.Beneficiario.DetalleGuarderia);
            query.SetParameter(8, command.Beneficiario.EsAlergico == true ? "S" : "N");
            query.SetParameter(9, command.Beneficiario.DetalleAlergia);
            query.SetParameter(10, command.Beneficiario.TomaMedicamentos == true ? "S" : "N");
            query.SetParameter(11, command.Beneficiario.DetalleMedicamento);
            query.SetParameter(12, command.Beneficiario.CondicionParticular == true ? "S" : "N");
            query.SetParameter(13, command.Beneficiario.DetalleCondicionParticular);
            query.SetParameter(14, command.Beneficiario.InstitucionMedica);
            query.SetParameter(15, command.Beneficiario.FechaUltimoControl);
            query.SetParameter(16, command.Beneficiario.Peso);
            query.SetParameter(17, command.Beneficiario.Talla);

            query.SetParameter(18, command.Beneficiario.Caracteristica.Enfermedad.IdCaracteristica);
            query.SetParameter(19, command.Beneficiario.Caracteristica.Discapacidad.IdCaracteristica);

            query.SetParameter(20, command.Beneficiario.AsignacionUniversalHijo == true ? "S" : "N");
            query.SetParameter(21, command.Beneficiario.SituacionCritica == true ? "S" : "N");            
            query.SetParameter(22, command.Beneficiario.Observaciones);

            query.SetParameter(23, command.Beneficiario.Caracteristica.TieneObraSocial.IdCaracteristica);
            query.SetParameter(24, command.Beneficiario.Caracteristica.ObraSocial.IdCaracteristica);
            query.SetParameter(25, command.Beneficiario.Caracteristica.GrupoSanguineo.IdCaracteristica);

            query.SetParameter(26, command.Beneficiario.Domicilio.DepartamentoId);
            query.SetParameter(27, command.Beneficiario.Domicilio.LocalidadId);
            query.SetParameter(28, command.Beneficiario.Domicilio.BarrioId);
            query.SetParameter(29, command.Beneficiario.Domicilio.TipoCalleId);
            query.SetParameter(30, command.Beneficiario.Domicilio.Direccion);
            query.SetParameter(31, command.Beneficiario.Domicilio.Altura);
            query.SetParameter(32, command.Beneficiario.Domicilio.CalleId);
            query.SetParameter(33, command.Beneficiario.Domicilio.Departamento);
            query.SetParameter(34, command.Beneficiario.Domicilio.Piso);
            query.SetParameter(35, command.Beneficiario.Domicilio.Torre);
            query.SetParameter(36, command.Beneficiario.Domicilio.Latitud);
            query.SetParameter(37, command.Beneficiario.Domicilio.Longitud);
            query.SetParameter(38, command.Beneficiario.Domicilio.Manzana);
            query.SetParameter(39, command.Beneficiario.Domicilio.Parcela);
            query.SetParameter(40, command.Beneficiario.Domicilio.Id);
            query.SetParameter(41, command.Beneficiario.EsEspecial ? 'S' : 'N');
            query.SetParameter(42, command.Beneficiario.LecheEspecial == null ? -1 : command.Beneficiario.LecheEspecial);
            query.SetParameter(43, command.Beneficiario.PanialEspecial == null ? -1 : command.Beneficiario.PanialEspecial);
            query.SetParameter(44, command.Beneficiario.MotivoEspecial == null ? -1 : command.Beneficiario.MotivoEspecial);
            query.SetParameter(45, command.Beneficiario.AsisteSala);
            
            //Va a ser documentacion
            query.SetParameter(46, "");
            query.SetParameter(47, command.Beneficiario.Programa == true ? "S" : "N");
            query.SetParameter(48, command.Beneficiario.NombrePrograma);
            #endregion           

            result.Resolve(query.UniqueResult());
                     
        }
    }
}
