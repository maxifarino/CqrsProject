using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Base.Helper;
using GAP.Base.ResultValidation;
//using GAP.Cqrs.Implementation.Command.GrupoFamiliarPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
//using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceBeneficiario;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonaFisica;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceIntegrante;


namespace GAP.Cqrs.Implementation.CommandHandler.GrupoFamiliarPackage
{
    public class IntegranteSaveCommandHandler : ICommandHandler<IntegranteSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonaServiceBusiness _personaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;
        private readonly IntegranteServiceBusiness _integranteServiceBusiness;

        public IntegranteSaveCommandHandler(RepositoryLocalScheme repositryLocalScheme, PersonaServiceBusiness personaServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness, IntegranteServiceBusiness integranteServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _personaServiceBusiness = personaServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
            _integranteServiceBusiness = integranteServiceBusiness;
        }


        public Result Execute(IntegranteSaveCommand command)
        {
            Result result = new Result();

            result.AddErrorsRange(_integranteServiceBusiness.ValidateSave(command.Beneficiario).GetErrors());

            foreach (var integrante in command.Beneficiario.ListIntegrantes)
            {
                if (!integrante.EsDomicilioBeneficiario)
                {
                    result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(integrante.Domicilio).GetErrors());
                }
            }

            if (result.success)
                IntegranteSave(command, ref result);

            return result;
        }

        private void IntegranteSave(IntegranteSaveCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_INTEG_GPO_FLIAR(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
                        

            foreach (var integrante in command.Beneficiario.ListIntegrantes)
            {
                query.SetParameter(0, command.ProgramaAplicacionId);
                query.SetParameter(1, command.UsuarioLogueadoId);

                query.SetParameter(2, command.Beneficiario.PersonaSeleccionada.SexoId);
                query.SetParameter(3, command.Beneficiario.PersonaSeleccionada.NumeroDocumento);
                query.SetParameter(4, command.Beneficiario.PersonaSeleccionada.CodigoPais);
                query.SetParameter(5, command.Beneficiario.PersonaSeleccionada.NumeroId);

                query.SetParameter(6, integrante.PersonaSeleccionada.SexoId);
                query.SetParameter(7, integrante.PersonaSeleccionada.NumeroDocumento == "" ? "-1" : integrante.PersonaSeleccionada.NumeroDocumento);
                query.SetParameter(8, integrante.PersonaSeleccionada.CodigoPais);
                query.SetParameter(9, integrante.PersonaSeleccionada.NumeroId);
                query.SetParameter(10, integrante.PersonaSeleccionada.Nombre);
                query.SetParameter(11, integrante.PersonaSeleccionada.Apellido);
                query.SetParameter(12, DateTimeHelper.GetMinDateTimeNullable(integrante.PersonaSeleccionada.FechaNacimiento));
                query.SetParameter(13, integrante.PersonaSeleccionada.TipoDocumentoId);
                query.SetParameter(14, integrante.PersonaSeleccionada.OrganismoEmisor);
                query.SetParameter(15, integrante.PersonaSeleccionada.CodigoPaisTd);
                query.SetParameter(16, (integrante.LocalidadOrigenId == "" || integrante.LocalidadOrigenId == null) ? "-1" : integrante.LocalidadOrigenId);
                query.SetParameter(17, integrante.NacionalidadId);

                query.SetParameter(18, integrante.PersonaSeleccionada.CodArea);
                query.SetParameter(19, integrante.PersonaSeleccionada.TelefonoCelular);
                query.SetParameter(20, integrante.PersonaSeleccionada.CodAreaAlternativo);
                query.SetParameter(21, integrante.PersonaSeleccionada.TelefonoAlternativo);

                query.SetParameter(22, integrante.IdsProgramaSocial);

                query.SetParameter(23, integrante.Caracteristica.Ocupacion.IdCaracteristica);

                query.SetParameter(24, integrante.Caracteristica.TieneObraSocial.IdCaracteristica);
                query.SetParameter(25, integrante.Caracteristica.ObraSocial.IdCaracteristica);

                query.SetParameter(26, integrante.Caracteristica.CoberturaMedica.IdCaracteristica);

                query.SetParameter(27, integrante.Caracteristica.NivelEscolaridad.IdCaracteristica);

                query.SetParameter(28, integrante.HorarioOcupacion);
                query.SetParameter(29, integrante.TrabajoFormal == true ? 'S' : 'N');

                query.SetParameter(30, integrante.Caracteristica.Enfermedad.IdCaracteristica);

                query.SetParameter(31, integrante.Caracteristica.Discapacidad.IdCaracteristica);

                query.SetParameter(32, integrante.IdsBeneficioSocial);

                query.SetParameter(33, integrante.IdsAporteHogar);
                query.SetParameter(34, integrante.RecibeAtencion == true ? 'S' : 'N');
                query.SetParameter(35, integrante.NecesitaAtencion == true ? 'S' : 'N');
                query.SetParameter(36, integrante.CertificadoDiscapacidad == true ? 'S' : 'N');
                query.SetParameter(37, integrante.OtroAporte);
                query.SetParameter(38, integrante.EstadoCivilId);
                query.SetParameter(39, integrante.EsDomicilioBeneficiario ? integrante.IdDomicilioBeneficiario : -1);
                query.SetParameter(40, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.DepartamentoId);
                query.SetParameter(41, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.LocalidadId);
                query.SetParameter(42, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.BarrioId);
                query.SetParameter(43, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.TipoCalleId);
                query.SetParameter(44, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Direccion);
                query.SetParameter(45, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.Altura);
                query.SetParameter(46, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? -1 : command.Beneficiario.ListIntegrantes[0].Domicilio.CalleId);
                query.SetParameter(47, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Departamento);
                query.SetParameter(48, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Piso);
                query.SetParameter(49, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Torre);
                query.SetParameter(50, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Manzana);
                query.SetParameter(51, command.Beneficiario.ListIntegrantes[0].EsDomicilioBeneficiario ? null : command.Beneficiario.ListIntegrantes[0].Domicilio.Parcela);
                
                query.SetParameter(52, integrante.Vinculo.Id);
                query.SetParameter(53, integrante.EsTutor);
                query.SetParameter(54, integrante.PoseeProgramaSocial ? 'S':'N');
                query.SetParameter(55, integrante.CualProgramaSocial);
                
                result.Resolve(query.UniqueResult());
            }
        }


    }
}
