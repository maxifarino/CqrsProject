using GAP.Base;
using GAP.Base.Helper;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.BeneficiarioPackage;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
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
    public class BeneficiarioSaveCommandHandler : ICommandHandler<BeneficiarioSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonaServiceBusiness _personaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;
        private readonly BeneficiarioServiceBusiness _beneficiarioServiceBusiness;
        public BeneficiarioSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, BeneficiarioServiceBusiness beneficiarioServiceBusiness, PersonaServiceBusiness entidadServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _personaServiceBusiness = entidadServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
            _beneficiarioServiceBusiness = beneficiarioServiceBusiness;
        }
        public Result Execute(BeneficiarioSaveCommand command)
        {
            Result result = _beneficiarioServiceBusiness.ValidateSave(command.Beneficiario);
            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Beneficiario.Domicilio).GetErrors());

            if (command.Beneficiario.Integrante != null && !command.Beneficiario.Integrante.EsDomicilioBeneficiario)
            {
                result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Beneficiario.Integrante.Domicilio).GetErrors());
            }

            if (!String.IsNullOrEmpty(existenciaBeneficiario(command)))
            {
                result.AddError("El beneficiario ya se encuentra inscripto en una sala cuna");
            }

            if (result.success)
                BeneficiarioSave(command, ref result);



            return result;
        }

        private string existenciaBeneficiario(BeneficiarioSaveCommand query)
        {
            var queryResult = new BeneficiarioExistenciaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioExistenciaQueryResult>("PR_VERIFICAR_BENEFICIARIO (?,?,?,?,?)")

            .SetParameter(0, query.Beneficiario.SexoId)
            .SetParameter(1, query.Beneficiario.NumeroDocumento)
            .SetParameter(2, query.Beneficiario.CodigoPais)
            .SetParameter(3, 0)
            .SetParameter(4, query.Beneficiario.SalitaId);

            queryResult = (BeneficiarioExistenciaQueryResult)querySession.UniqueResult();

            return queryResult.EXISTE;
        }



        private void BeneficiarioSave(BeneficiarioSaveCommand command, ref Result result)
        {
            //En este metodo se registra todo el beneficiario con su integrante y cada una de las caracteristica que tiene tanto el beneficiario como el integrante    
            //Se llama primero a la función de registrar beneficiario y luego a la funciòn de registrar Integrante
            //Ambas funciones se encuentran relacionadas
            #region Beneficiario
            StringBuilder builder = new StringBuilder();

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_BENEFICIARIO(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");

            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.Beneficiario.SexoId);
            query.SetParameter(3, command.Beneficiario.NumeroDocumento == "" ? "-1" : command.Beneficiario.NumeroDocumento);
            query.SetParameter(4, command.Beneficiario.CodigoPais);
            query.SetParameter(5, command.Beneficiario.NumeroId);

            query.SetParameter(6, command.Beneficiario.Nombre);
            query.SetParameter(7, command.Beneficiario.Apellido);
            query.SetParameter(8, DateTimeHelper.GetMinDateTimeNullable(command.Beneficiario.FechaNacimiento));
            query.SetParameter(9, command.Beneficiario.TipoDocumento != null ? command.Beneficiario.TipoDocumento.TipoDocumentoId : null);
            query.SetParameter(10, command.Beneficiario.TipoDocumento != null ? command.Beneficiario.TipoDocumento.OrganismoEmisorId : null);
            query.SetParameter(11, command.Beneficiario.TipoDocumento != null ? command.Beneficiario.TipoDocumento.PaisTipoDocumentoId : null);
            query.SetParameter(12, (command.Beneficiario.LocalidadOrigenId == "" || command.Beneficiario.LocalidadOrigenId == null) ? "-1" : command.Beneficiario.LocalidadOrigenId);
            query.SetParameter(13, command.Beneficiario.NacionalidadId);

            query.SetParameter(14, command.Beneficiario.AsistioGuarderia ? "S" : "N");
            query.SetParameter(15, command.Beneficiario.NombreGuarderia);
            query.SetParameter(16, command.Beneficiario.EsAlergico ? "S" : "N");
            query.SetParameter(17, command.Beneficiario.DetalleAlergico);
            query.SetParameter(18, command.Beneficiario.TomaMedicamentos ? "S" : "N");
            query.SetParameter(19, command.Beneficiario.DetalleMedicamento);
            query.SetParameter(20, command.Beneficiario.CondicionParticular ? "S" : "N");
            query.SetParameter(21, "");// DetalleCondicionParticular
            query.SetParameter(22, command.Beneficiario.InstitucionMedica);
            query.SetParameter(23, command.Beneficiario.FechaUltimoControl);
            query.SetParameter(24, command.Beneficiario.Peso);
            query.SetParameter(25, command.Beneficiario.Talla);

            query.SetParameter(26, command.Beneficiario.IdEnfermedad);
            query.SetParameter(27, command.Beneficiario.IdDiscapacidad);

            query.SetParameter(28, command.Beneficiario.AsignacionUniversalHijo ? "S" : "N");
            query.SetParameter(29, command.Beneficiario.SituacionCritica ? "S" : "N");
            query.SetParameter(30, command.Beneficiario.Observacion);

            query.SetParameter(31, command.Beneficiario.IdTieneObraSocial ? "S" : "N");
            query.SetParameter(32, command.Beneficiario.IdObraSocial);
            query.SetParameter(33, command.Beneficiario.IdGrupoSanguineo);

            query.SetParameter(34, command.Beneficiario.SalitaId);
            query.SetParameter(35, DateTimeHelper.GetMinDateTimeNullable(command.Beneficiario.FechaAlta));

            query.SetParameter(36, command.Beneficiario.Domicilio.DepartamentoId);
            query.SetParameter(37, command.Beneficiario.Domicilio.LocalidadId);
            query.SetParameter(38, command.Beneficiario.Domicilio.BarrioId);
            query.SetParameter(39, command.Beneficiario.Domicilio.TipoCalleId);
            query.SetParameter(40, command.Beneficiario.Domicilio.Direccion);
            query.SetParameter(41, command.Beneficiario.Domicilio.Altura);
            query.SetParameter(42, command.Beneficiario.Domicilio.CalleId);
            query.SetParameter(43, command.Beneficiario.Domicilio.Departamento);
            query.SetParameter(44, command.Beneficiario.Domicilio.Piso);
            query.SetParameter(45, command.Beneficiario.Domicilio.Torre);
            query.SetParameter(46, command.Beneficiario.Domicilio.Manzana);
            query.SetParameter(47, command.Beneficiario.Domicilio.Parcela);
            query.SetParameter(48, command.Beneficiario.Domicilio.Latitud);
            query.SetParameter(49, command.Beneficiario.Domicilio.Longitud);

            //CASO ESPECIAL
            query.SetParameter(50, command.Beneficiario.Especial ? 'S' : 'N');
            query.SetParameter(51, command.Beneficiario.IdLeche.HasValue ? command.Beneficiario.IdLeche : -1);
            query.SetParameter(52, command.Beneficiario.IdPanial.HasValue ? command.Beneficiario.IdPanial : -1);
            query.SetParameter(53, command.Beneficiario.IdMotivoEspecial.HasValue ? command.Beneficiario.IdMotivoEspecial : -1);
            query.SetParameter(54, ""); //Documentacion Adjunta
            query.SetParameter(55, command.Beneficiario.Programa ? 'S' : 'N');
            query.SetParameter(56, command.Beneficiario.NombrePrograma);

            result.Resolve(query.UniqueResult());

            _repositryLocalScheme.Session.Transaction.Commit();
            #endregion
            #region tutor
            if (result.success && true)//   VALIDACION PARA CASO ESPECIAL SIN TUTOR     (result.success && (!command.Beneficiario.MayorEdad() && command.Beneficiario.CasoEspecial) || !command.Beneficiario.CasoEspecial))
            {
                var query2 = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_INTEG_GPO_FLIAR(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");

                //se obtiene el numeroId, numeroDocumento y codigo pais del beneficiario que acabamos de insertar para pasarlo a PR_INSERTAR_INTEG_GPO_FLIAR como parametro de entrada 
                int numeroId = Convert.ToInt32(result.GetDataValue(0));
                string numeroDocumento = Convert.ToString(result.GetDataValue(1));
                string codigoPais = Convert.ToString(result.GetDataValue(2));
                int domicilioIdBeneficiario = Convert.ToInt32(result.GetDataValue(3));

                query2.SetParameter(0, command.ProgramaAplicacionId);
                query2.SetParameter(1, command.UsuarioLogueadoId);
                query2.SetParameter(2, command.Beneficiario.SexoId);
                query2.SetParameter(3, numeroDocumento);//es el numeroDocumento del beneficiario que acaba de registrar
                query2.SetParameter(4, codigoPais);//es el codigoPais del beneficiario que acaba de registrar
                query2.SetParameter(5, command.Beneficiario.NumeroId == -1 ? numeroId : command.Beneficiario.NumeroId);//es el NumeroId del beneficiario que acaba de registrar

                query2.SetParameter(6, command.Beneficiario.Integrante.SexoId);
                query2.SetParameter(7, command.Beneficiario.Integrante.NumeroDocumento == "" ? "-1" : command.Beneficiario.Integrante.NumeroDocumento);
                query2.SetParameter(8, command.Beneficiario.Integrante.CodigoPais);
                query2.SetParameter(9, command.Beneficiario.Integrante.NumeroId);
                query2.SetParameter(10, command.Beneficiario.Integrante.Nombre);
                query2.SetParameter(11, command.Beneficiario.Integrante.Apellido);
                query2.SetParameter(12, DateTimeHelper.GetMinDateTimeNullable(command.Beneficiario.Integrante.FechaNacimiento));
                query2.SetParameter(13, command.Beneficiario.Integrante.TipoDocumento != null ? command.Beneficiario.Integrante.TipoDocumento.TipoDocumentoId : null);
                query2.SetParameter(14, command.Beneficiario.Integrante.TipoDocumento != null ? command.Beneficiario.Integrante.TipoDocumento.OrganismoEmisorId : null);
                query2.SetParameter(15, command.Beneficiario.Integrante.TipoDocumento != null ? command.Beneficiario.Integrante.TipoDocumento.PaisTipoDocumentoId : null);
                query2.SetParameter(16, (command.Beneficiario.Integrante.LocalidadOrigenId == "" || command.Beneficiario.Integrante.LocalidadOrigenId == null) ? "-1" : command.Beneficiario.Integrante.LocalidadOrigenId);
                query2.SetParameter(17, command.Beneficiario.Integrante.NacionalidadId);


                query2.SetParameter(18, command.Beneficiario.Integrante.CodArea);
                query2.SetParameter(19, command.Beneficiario.Integrante.TelefonoCelular);
                query2.SetParameter(20, command.Beneficiario.Integrante.CodAreaAlternativo);
                query2.SetParameter(21, command.Beneficiario.Integrante.TelefonoAlternativo);

                query2.SetParameter(22, command.Beneficiario.Integrante.IdsProgramaSocial);
                query2.SetParameter(23, command.Beneficiario.Integrante.IdOcupacion);
                query2.SetParameter(24, command.Beneficiario.Integrante.IdTieneObraSocial ? "S" : "N");
                query2.SetParameter(25, command.Beneficiario.Integrante.IdObraSocial);
                query2.SetParameter(26, command.Beneficiario.Integrante.IdCoberturaMedica);
                query2.SetParameter(27, command.Beneficiario.Integrante.IdNivelEscolaridad);

                query2.SetParameter(28, command.Beneficiario.Integrante.HorarioOcupacion);
                query2.SetParameter(29, "");//TrabajoFormal

                query2.SetParameter(30, "");//Enfermedad

                query2.SetParameter(31, "");//Discapacidad

                query2.SetParameter(32, command.Beneficiario.Integrante.IdsBeneficioSocial);
                query2.SetParameter(33, "");//IdAporteHogar
                query2.SetParameter(34, "");//Recibe atencion
                query2.SetParameter(35, "");//NecesitaAtencion
                query2.SetParameter(36, "");//Certificado de discapacidad
                query2.SetParameter(37, "");//otrosAportes
                query2.SetParameter(38, command.Beneficiario.Integrante.EstadoCivilId);

                //Domicilio copiado del beneficiario
                query2.SetParameter(39, (command.Beneficiario.Integrante.EsDomicilioBeneficiario ? domicilioIdBeneficiario : -1));
                //Domicilio Tutor
                query2.SetParameter(40, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.DepartamentoId);
                query2.SetParameter(41, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.LocalidadId);
                query2.SetParameter(42, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.BarrioId);
                query2.SetParameter(43, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.TipoCalleId);
                query2.SetParameter(44, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Direccion);
                query2.SetParameter(45, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.Altura);
                query2.SetParameter(46, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? -1 : command.Beneficiario.Integrante.Domicilio.CalleId);
                query2.SetParameter(47, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Departamento);
                query2.SetParameter(48, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Piso);
                query2.SetParameter(49, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Torre);
                query2.SetParameter(50, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Manzana);
                query2.SetParameter(51, command.Beneficiario.Integrante.EsDomicilioBeneficiario ? null : command.Beneficiario.Integrante.Domicilio.Parcela);

                query2.SetParameter(52, command.Beneficiario.Integrante.IdVinculo);
                query2.SetParameter(53, "S"); // Es Tutor
                query2.SetParameter(54, command.Beneficiario.Integrante.Programa ? "S" : "N");
                query2.SetParameter(55, command.Beneficiario.Integrante.NombrePrograma);

                result.Resolve(query2.UniqueResult());
            }

            
            #endregion
        }
    }
}
