using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonaFisica;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServicePersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.PersonalPackage
{
    public class PersonalSaveCommandHandler : ICommandHandler<PersonalSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonaServiceBusiness _personaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;
        private readonly PersonalServiceBusiness _personalServiceBusiness;

        public PersonalSaveCommandHandler(RepositoryLocalScheme repositryLocalScheme, PersonaServiceBusiness personaServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness, PersonalServiceBusiness personalServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _personaServiceBusiness = personaServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
            _personalServiceBusiness = personalServiceBusiness;
        }


        public Result Execute(PersonalSaveCommand command)
        {
            Result result = new Result();
            string reqSala = "";
            string fecha = "01/01/0001";

            result.AddErrorsRange(_personalServiceBusiness.ValidateSave(command.Personal).GetErrors());
            foreach (RequisitoPersonal requisito in command.Personal.requisitos)
            {
                //if (requisito.Estado == true)
                //{
                //    estado = "S";
                //}
                //else {
                //    estado = "N";
                //}

                if (requisito.fechaPresentacion.HasValue || requisito.Baja)
                {
                    string idRQS = requisito.Baja ? "-1" : requisito.Id.ToString();
                    string idRQSPERSONAL = requisito.IdRequisitoPersonal != null ? requisito.IdRequisitoPersonal.ToString() : "-1";
                    fecha = "01/01/0001";


                    if (requisito.fechaPresentacion.HasValue)
                    {
                        fecha = ((DateTime)requisito.fechaPresentacion).ToString("dd/MM/yyyy"); 
                    }

                    reqSala += idRQSPERSONAL + "," + idRQS + "," + fecha + ";";
                }                
            }

            result.AddErrorsRange(_personalServiceBusiness.ValidateSave(command.Personal).GetErrors());

            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Personal.Domicilio).GetErrors());

            if (result.success)
                PersonalSave(command, reqSala, ref result);

            return result;
        }

        private void PersonalSave(PersonalSaveCommand command, string requisitos, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_PERSONAL(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);

            //DATOS PERSONAL
            query.SetParameter(2, command.Personal.SalitaID);
            query.SetParameter(3, command.Personal.IdCargo);
            query.SetParameter(4, command.Personal.PersonaSeleccionada.SexoId);
            query.SetParameter(5, command.Personal.PersonaSeleccionada.NumeroDocumento == "" ? "-1" : command.Personal.PersonaSeleccionada.NumeroDocumento);
            query.SetParameter(6, command.Personal.PersonaSeleccionada.CodigoPais);

            //ESTE NUMERO VIENE -1 SI LA PERSONA NO EXISTE Y HAY QUE REGISTRARLA
            query.SetParameter(7, command.Personal.PersonaSeleccionada.NumeroId);

            query.SetParameter(8, command.Personal.PersonaSeleccionada.Nombre);
            query.SetParameter(9, command.Personal.PersonaSeleccionada.Apellido);
            query.SetParameter(10, command.Personal.PersonaSeleccionada.FechaNacimiento);
            query.SetParameter(11, command.Personal.PersonaSeleccionada.TipoDocumentoId);
            query.SetParameter(12, command.Personal.PersonaSeleccionada.OrganismoEmisor);
            query.SetParameter(13, command.Personal.PersonaSeleccionada.CodigoPaisTd);
            query.SetParameter(14, (command.Personal.LocalidadOrigenId == "" || command.Personal.LocalidadOrigenId == null) ? "0" : command.Personal.LocalidadOrigenId);
            query.SetParameter(15, command.Personal.NacionalidadId);
            query.SetParameter(16, command.Personal.PersonaSeleccionada.EstadoCivilId);

            //DOMICILIO
            query.SetParameter(17, command.Personal.Domicilio.DepartamentoId);
            query.SetParameter(18, command.Personal.Domicilio.LocalidadId);
            query.SetParameter(19, command.Personal.Domicilio.BarrioId);
            query.SetParameter(20, command.Personal.Domicilio.TipoCalleId);
            query.SetParameter(21, command.Personal.Domicilio.Direccion);
            query.SetParameter(22, command.Personal.Domicilio.Altura);
            query.SetParameter(23, command.Personal.Domicilio.CalleId);
            query.SetParameter(24, command.Personal.Domicilio.Departamento);
            query.SetParameter(25, command.Personal.Domicilio.Piso);
            query.SetParameter(26, command.Personal.Domicilio.Torre);

            query.SetParameter(27, command.Personal.Domicilio.Latitud);
            query.SetParameter(28, command.Personal.Domicilio.Longitud);
            query.SetParameter(29, command.Personal.Domicilio.Manzana);
            query.SetParameter(30, command.Personal.Domicilio.Parcela);
            query.SetParameter(31, command.Personal.FechaAsignacion);
            query.SetParameter(32, requisitos);

            result.Resolve(query.UniqueResult());
        }
      
    }
}
