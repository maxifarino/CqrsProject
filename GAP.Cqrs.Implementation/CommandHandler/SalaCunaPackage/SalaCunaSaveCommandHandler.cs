using GAP.Base;
using GAP.Base.Helper;
using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.SalaCunaPackage;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna;
using System;
using System.Text;

namespace GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage
{
    public class SalaCunaSaveCommandHandler : ICommandHandler<SalaCunaSaveCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalaCunaServiceBusiness _salaCunaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;

        public SalaCunaSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalaCunaServiceBusiness entidadServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salaCunaServiceBusiness = entidadServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
        }

        public Result Execute(SalaCunaSaveCommand command)
        {
            _salaCunaServiceBusiness.CompletarSalaCunaSave(command.SalaCuna);
            Result result = _salaCunaServiceBusiness.ValidateSave(command.SalaCuna);
            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.SalaCuna.Domicilio).GetErrors());

            if (result.success)
                SaveSalaCuna(command, ref result);

            return result;
        }

        private void SaveSalaCuna(SalaCunaSaveCommand command, ref Result result)
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_SALA_CUNA(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                .SetParameter(0, GlobalVars.IdApplication)
                .SetParameter(1, DateTimeHelper.GetMinDateTime())
                .SetParameter(2, command.SalaCuna.Nombre)
                .SetParameter(3, command.SalaCuna.FechaInicioTramite)
                .SetParameter(4, command.SalaCuna.FechaUltimaModificacion)
                .SetParameter(5, command.SalaCuna.Entidad.Cuit)
                .SetParameter(6, command.SalaCuna.Entidad.Sede.Id)
                .SetParameter(7, command.SalaCuna.Responsable.NumeroDocumento)
                .SetParameter(8, command.SalaCuna.Responsable.SexoId.ToString())
                .SetParameter(9, command.SalaCuna.Responsable.CodigoPais.ToString())
                .SetParameter(10, command.SalaCuna.Responsable.NumeroId)
                .SetParameter(11, command.idUsuarioLogueado)
                .SetParameter(12, command.SalaCuna.Estado)

            #region Domicilio
                .SetParameter(13, command.SalaCuna.Domicilio.DepartamentoId)
                .SetParameter(14, command.SalaCuna.Domicilio.LocalidadId)
                .SetParameter(15, command.SalaCuna.Domicilio.BarrioId)
                .SetParameter(16, command.SalaCuna.Domicilio.TipoCalleId)
                .SetParameter(17, command.SalaCuna.Domicilio.Direccion)
                .SetParameter(18, command.SalaCuna.Domicilio.Altura)
                .SetParameter(19, command.SalaCuna.Domicilio.CalleId)
                .SetParameter(20, command.SalaCuna.Domicilio.Departamento)
                .SetParameter(21, command.SalaCuna.Domicilio.Piso)
                .SetParameter(22, command.SalaCuna.Domicilio.Torre)
                .SetParameter(23, command.SalaCuna.Domicilio.Latitud)
                .SetParameter(24, command.SalaCuna.Domicilio.Longitud)
                .SetParameter(25,command.SalaCuna.Domicilio.Manzana)
                .SetParameter(26, command.SalaCuna.Domicilio.Parcela)

            #endregion

                .SetParameter(27, command.SalaCuna.NumeroSticker)
                .SetParameter(28, command.SalaCuna.NumeroExpediente)
                //codarea
                .SetParameter(29, command.SalaCuna.Responsable.CodArea)
                .SetParameter(30, command.SalaCuna.Responsable.TelefonoCelular)
                .SetParameter(31, command.SalaCuna.Responsable.Mail)
                //telefono
                .SetParameter(32, (command.SalaCuna.Capital != null && command.SalaCuna.Capital.Value) ? 'S' : 'N')
                .SetParameter(33, command.SalaCuna.CbuBancaria)
                .SetParameter(34, command.SalaCuna.SucursalId)
                .SetParameter(35, command.SalaCuna.NumeroDeCuentaBancaria)
                .SetParameter(36, command.SalaCuna.EntidadBancariaId)
                .SetParameter(37, command.SalaCuna.Codigo);

            result.Resolve(query.UniqueResult());
        }
    }
}
