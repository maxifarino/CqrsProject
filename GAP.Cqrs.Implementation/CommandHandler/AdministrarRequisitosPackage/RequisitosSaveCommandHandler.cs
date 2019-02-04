using GAP.Cqrs.Implementation.Command.AdministrarRequisitos;
using GAP.CqrsCore.Commands;
using System;
using System.Collections.Generic;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceDomicilio;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSalaCuna;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceAdministrarRequisitos;
using GAP.Base.ResultValidation;
using GAP.Domain.Entities;
using GAP.Base.Helper;
using GAP.Base;

namespace GAP.Cqrs.Implementation.CommandHandler.AdministrarRequisitos
{
    public class RequisitosSaveCommandHandler : ICommandHandler<RequisitosSaveCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly RequisitosServiceBusiness _requisitosServiceBusiness;
        Int16? IdSalaCuna;

        public RequisitosSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, RequisitosServiceBusiness entidadServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _requisitosServiceBusiness = entidadServiceBusiness;
        }

        public Result Execute(RequisitosSaveCommand command)
        {
            #region DeclaracionVariables
            Result result = new Result();
            bool tieneErrores = false;
            string reqSala = "";
            string fecha;
            string fechaHasta;
            string EstadoRq;
            string OBS;
            #endregion

            #region Validaciones

            foreach (Requisito requisito in command.ListaRequisitos)
            {
                OBS = "-1";
                fechaHasta = "01/01/0001";
                fecha = "01/01/0001";
                IdSalaCuna = requisito.IdSalaCuna;
                result = null;

                //Transforma booleano a String
                if (requisito.Estado)
                    EstadoRq = "S";
                else
                    EstadoRq = "N";


                //Parsea tipo date a string
                
                if (requisito.fechaPresentacion != null && DateTimeHelper.SameOrBefore(requisito.fechaPresentacion.Value, DateTime.Today))
                {

                    if (requisito.fechaPresentacion <= requisito.fechaVigenciaHasta || !requisito.fechaVigenciaHasta.HasValue)
                        fecha = ((DateTime)requisito.fechaPresentacion).ToString("dd/MM/yyyy");

                    else
                    {
                        result = _requisitosServiceBusiness.ValidateSave(requisito);
                        tieneErrores = true;
                        break;
                    }
                }

                else
                {
                    result = _requisitosServiceBusiness.ValidateSave(requisito);
                    if (result.Errors.Count != 0)
                    {
                        tieneErrores = true;
                        break;
                    }
                }

                result = _requisitosServiceBusiness.ValidateSave(requisito);
                if (result.Errors.Count != 0)
                {
                    tieneErrores = true;
                    break;
                }


                if (requisito.Observaciones != null)
                    OBS = requisito.Observaciones;

                if (requisito.fechaVigenciaHasta.HasValue)
                    fechaHasta = ((DateTime)requisito.fechaVigenciaHasta).ToString("dd/MM/yyyy");

                reqSala += requisito.IdRequisito + "," + EstadoRq + "," + fecha + "," + fechaHasta + "," + OBS + ";";
                
                //TODO:remplazar lo de arriba por lo que sigue,es mas eficiente.
                //reqSala = string.Format("{0},{1},{2},{3},{4};", requisito.IdRequisito, EstadoRq, fecha, fechaHasta, OBS);
            }

            #endregion

            if (!tieneErrores)
            {
                SaveRequisito(IdSalaCuna, reqSala, command, ref result);
            }

            return result;
        }

        #region FuncionGuardarRequisitos

        private void SaveRequisito(Int16? IdSalaCuna, String requisito, RequisitosSaveCommand command, ref Result result)
        {
            //TODO Agustin: Llamar a SP para actualizar/crear requisitos para una Sala Cuna.
            StringBuilder builder = new StringBuilder();
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_INSERTAR_REQS_SC(?,?,?)")
                .SetParameter(0, IdSalaCuna)//fecha nula. Refactorizar
                .SetParameter(1, requisito)
                .SetParameter(2, 1); // cambiar despues

            result.Resolve(query.UniqueResult());
        }

        #endregion
    }
}
