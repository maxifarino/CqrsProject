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
    public class PersonalEditCommandHandler : ICommandHandler<PersonalEditCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly PersonaServiceBusiness _personaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;
        private readonly PersonalServiceBusiness _personalServiceBusiness;

        public PersonalEditCommandHandler(RepositoryLocalScheme repositryLocalScheme, PersonaServiceBusiness personaServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness, PersonalServiceBusiness personalServiceBusiness)
        {
            _repositryLocalScheme = repositryLocalScheme;
            _personaServiceBusiness = personaServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
            _personalServiceBusiness = personalServiceBusiness;
        }


        public Result Execute(PersonalEditCommand command)
        {
            Result result = new Result();
            string reqSala = "";
            string fecha = "01/01/0001";

            foreach (RequisitoPersonal requisito in command.Personal.requisitos)
            {


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

           // result.AddRange(_personalServiceBusiness.ValidateSave(command.Personal).GetErrors());
            result.AddErrorsRange(_personalServiceBusiness.ValidateUpdate(command.Personal).GetErrors());
            if (!command.Personal.IdCargo.HasValue)
                result.AddError("Debe seleccionar un Cargo");

            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Personal.Domicilio).GetErrors());


            

            if (result.success)
                PersonalEdit(command, reqSala, ref result);

            return result;
        }

        private void PersonalEdit(PersonalEditCommand command, string requisitos, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_PERSONAL(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
            query.SetParameter(0, command.ProgramaAplicacionId);
            query.SetParameter(1, command.UsuarioLogueadoId);
            query.SetParameter(2, command.Personal.IdAsignacionPersonal);
            query.SetParameter(3, command.Personal.IdCargo); 

            //DOMICILIO
            query.SetParameter(4, command.Personal.Domicilio.DepartamentoId);
            query.SetParameter(5, command.Personal.Domicilio.LocalidadId);
            query.SetParameter(6, command.Personal.Domicilio.BarrioId);
            query.SetParameter(7, command.Personal.Domicilio.TipoCalleId);
            query.SetParameter(8, command.Personal.Domicilio.Direccion);
            query.SetParameter(9, command.Personal.Domicilio.Altura);
            query.SetParameter(10, command.Personal.Domicilio.CalleId);
            query.SetParameter(11, command.Personal.Domicilio.Departamento);
            query.SetParameter(12, command.Personal.Domicilio.Piso);
            query.SetParameter(13, command.Personal.Domicilio.Torre);

            query.SetParameter(14, command.Personal.Domicilio.Latitud);
            query.SetParameter(15, command.Personal.Domicilio.Longitud);
            query.SetParameter(16, command.Personal.Domicilio.Manzana);
            query.SetParameter(17, command.Personal.Domicilio.Parcela);
            query.SetParameter(18, requisitos);

            result.Resolve(query.UniqueResult());

        }
      
    }
}
