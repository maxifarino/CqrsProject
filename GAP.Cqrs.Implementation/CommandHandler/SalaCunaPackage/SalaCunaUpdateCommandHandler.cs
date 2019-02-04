using GAP.Base;
using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.SalaCunaPackage
{
    public class SalaCunaUpdateCommandHandler : ICommandHandler<SalaCunaUpdateCommand>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SalaCunaServiceBusiness _salaCunaServiceBusiness;
        private readonly DomicilioServiceBusiness _domicilioServiceBusiness;

        public SalaCunaUpdateCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SalaCunaServiceBusiness entidadServiceBusiness, DomicilioServiceBusiness domicilioServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _salaCunaServiceBusiness = entidadServiceBusiness;
            _domicilioServiceBusiness = domicilioServiceBusiness;
        }

        public Result Execute(SalaCunaUpdateCommand command)
        {
            Result result = _salaCunaServiceBusiness.ValidateUpdate(command.SalaCuna);
            result.AddErrorsRange(_domicilioServiceBusiness.ValidateSave(command.SalaCuna.Domicilio).GetErrors());
            
            if (result.success)
                UpdateSalaCuna(command, ref result);

            return result;
        }

        private void UpdateSalaCuna(SalaCunaUpdateCommand command, ref Result result) 
        {
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_ACTUALIZAR_SALA_CUNA(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                .SetParameter(0, command.SalaCuna.Id)
                .SetParameter(1, command.SalaCuna.Nombre)
                .SetParameter(2, command.SalaCuna.FechaInicioTramite)
                .SetParameter(3, command.SalaCuna.NumeroSticker)
                .SetParameter(4, command.SalaCuna.NumeroExpediente)
                .SetParameter(5, command.idUsuarioLogueado)
                .SetParameter(6, GlobalVars.IdApplication)
                .SetParameter(7, 1)//RESPONSABLE
                .SetParameter(8, 1)//RESPONSABLE
                .SetParameter(9, 1)//RESPONSABLE
                .SetParameter(10, 1);//RESPONSABLE
                if(command.SalaCuna.Domicilio != null){
                    query.SetParameter(11, command.SalaCuna.Domicilio.DepartamentoId)//iddepartamento
                    .SetParameter(12, command.SalaCuna.Domicilio.LocalidadId)//id localidad
                    .SetParameter(13, command.SalaCuna.Domicilio.BarrioId)//id barrio
                    .SetParameter(14, command.SalaCuna.Domicilio.TipoCalleId)//id tipo calle
                    .SetParameter(15, command.SalaCuna.Domicilio.Direccion)//nombre calle
                    .SetParameter(16, command.SalaCuna.Domicilio.Altura)//altura
                    .SetParameter(17, command.SalaCuna.Domicilio.CalleId)//id calle
                    .SetParameter(18, command.SalaCuna.Domicilio.Departamento)//depto
                    .SetParameter(19, command.SalaCuna.Domicilio.Piso)//piso
                    .SetParameter(20, command.SalaCuna.Domicilio.Torre)//torre
                    .SetParameter(21, command.SalaCuna.Domicilio.Parcela)//Lote
                    .SetParameter(22, command.SalaCuna.Domicilio.Manzana)//manzana
                    .SetParameter(23, command.SalaCuna.Domicilio.Latitud)
                    .SetParameter(24, command.SalaCuna.Domicilio.Longitud);
                }
                else
                {
                    query.SetParameter(11, -1)//iddepartamento
                    .SetParameter(12, -1)//id localidad
                    .SetParameter(13, -1)//id barrio
                    .SetParameter(14, -1)//id tipo calle
                    .SetParameter(15, -1)//nombre calle
                    .SetParameter(16, -1)//altura
                    .SetParameter(17, -1)//id calle
                    .SetParameter(18, -1)//depto
                    .SetParameter(19, -1)//piso
                    .SetParameter(20, -1)//torre
                    .SetParameter(21, command.SalaCuna.Domicilio.Parcela)//Lote
                    .SetParameter(22, command.SalaCuna.Domicilio.Manzana)//manzana
                    .SetParameter(23, command.SalaCuna.Domicilio.Latitud)
                    .SetParameter(24, command.SalaCuna.Domicilio.Longitud);//torre
                }
                var capital = (command.SalaCuna.Capital != null && command.SalaCuna.Capital.Value) ? 'S' : 'N';
                query.SetParameter(25, capital)
                .SetParameter(26, command.SalaCuna.CbuBancaria)
                .SetParameter(27, command.SalaCuna.SucursalId)
                .SetParameter(28, command.SalaCuna.NumeroDeCuentaBancaria)
                .SetParameter(29, command.SalaCuna.EntidadBancariaId)
                .SetParameter(30, command.SalaCuna.Codigo)
                .SetParameter(31, command.SalaCuna.FechaInauguracion);

            result.Resolve(query.UniqueResult());
        }
    }
}
