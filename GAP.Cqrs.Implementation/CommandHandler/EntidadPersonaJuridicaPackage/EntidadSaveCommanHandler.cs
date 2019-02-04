using GAP.Base;
using GAP.Base.Exceptions;
using GAP.Base.Helper;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.EntidadPersonaJuridica;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceEntidad.ServiceBusinessStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.EntidadPersonaJuridica
{
    public class EntidadSaveCommanHandler : ICommandHandler<EntidadSaveCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly EntidadServiceBusiness _entidadServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;

        public EntidadSaveCommanHandler(RepositoryLocalScheme repositoryLocalScheme, EntidadServiceBusiness entidadServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _entidadServiceBusiness = entidadServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
        }

        public Result Execute(EntidadSaveCommand command)
        {

            Result result = _entidadServiceBusiness.ValidateSave(command.Entidad);
            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.Entidad.Sede.Domicilio).GetErrors());

            if (result.success)
                SaveEntidad(command, ref result);

            return result;
        }

        private void SaveEntidad(EntidadSaveCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();

            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_PERSJURIDICA_GOB(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");

            #region Entidad

            query.SetParameter(0, command.Entidad.Cuit);
            query.SetParameter(1, command.Entidad.RazonSocial);
            query.SetParameter(2, command.Entidad.NombreFantasia);
            query.SetParameter(3, command.Entidad.FormaJuridicaId);
            query.SetParameter(4, command.ProgramaAplicacionId);
            query.SetParameter(5, DateTimeHelper.GetMinDateTimeNullable(command.Entidad.FechaAlta));            
            query.SetParameter(6, command.Entidad.Telefono);
            query.SetParameter(7, command.Entidad.CodArea);
            query.SetParameter(8, command.Entidad.Mail);

            #endregion

            #region Sede

            query.SetParameter(9, command.Entidad.Sede.Nombre == null ? null : command.Entidad.Sede.Nombre);
            
            #endregion

            #region Domicilio

            query.SetParameter(10, command.Entidad.Sede.Domicilio.DepartamentoId);
            query.SetParameter(11, command.Entidad.Sede.Domicilio.LocalidadId);
            query.SetParameter(12, command.Entidad.Sede.Domicilio.BarrioId);
            query.SetParameter(13, command.Entidad.Sede.Domicilio.TipoCalleId);
            query.SetParameter(14, command.Entidad.Sede.Domicilio.Direccion);
            query.SetParameter(15, command.Entidad.Sede.Domicilio.Altura);
            query.SetParameter(16, command.Entidad.Sede.Domicilio.CalleId);
            query.SetParameter(17, command.Entidad.Sede.Domicilio.Departamento);
            query.SetParameter(18, command.Entidad.Sede.Domicilio.Piso);
            query.SetParameter(19, command.Entidad.Sede.Domicilio.Torre);

            #endregion

            #region Responsable

            
            query.SetParameter(20, command.Entidad.Responsable.TelefonoCelular);//telefonoCElularRes
            query.SetParameter(21, command.Entidad.Responsable.CodArea);//codigo de area
            query.SetParameter(22, command.Entidad.Responsable.NumeroDocumento);//numDoc
            query.SetParameter(23, command.Entidad.Responsable.SexoId);//sexo requerido
            query.SetParameter(24, command.Entidad.Responsable.NumeroId);
            query.SetParameter(25, command.Entidad.Responsable.CodigoPais);//requerido NumeroTabla 
            query.SetParameter(26, command.Entidad.Responsable.Mail);

            #endregion
            query.SetParameter(27, command.idUsuarioLogueado);

            result.Resolve(query.UniqueResult());

            hasError(result);


        }

        //Armamos una lista de los errores surgidos en la BD.
        #region hasErrors
        public bool hasError(Result result)
        {
            StringBuilder errores = new StringBuilder();
           
            object[] objects = result.Data.ToArray();

            for (int i = 0; i < objects.Length; i++ )
            {
                if (!objects[i].ToString().Equals("OK"))
                {
                    errores.Append(objects[i].ToString() + " - ");
                }
            }

            if (errores.Length != 0)
            {
                throw new GobTechnicalException(errores.ToString());
            }

            return false;
        }

        #endregion

    }
}
