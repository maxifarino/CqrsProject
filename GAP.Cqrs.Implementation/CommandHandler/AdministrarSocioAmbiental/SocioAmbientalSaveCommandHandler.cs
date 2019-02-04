using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceSocioAmbiental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.Administrar_Socio_Ambiental
{
    public class SocioAmbientalSaveCommandHandler : ICommandHandler<SocioAmbientalSaveCommand>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;
        private readonly SocioAmbientalServiceBusiness _socioAmbientalServiceBusiness;
        public string RedSosten { get; set; }
        //public string AporteHogar { get; set; }
        public string Ambiente { get; set; }
        public string SituacionCrisis { get; set; }
        public string ControlMedico { get; set; }

        public SocioAmbientalSaveCommandHandler(RepositoryLocalScheme repositoryLocalScheme, SocioAmbientalServiceBusiness socioAmbientalServiceBusiness)
        {
            _repositryLocalScheme = repositoryLocalScheme;
            _socioAmbientalServiceBusiness = socioAmbientalServiceBusiness;

        }

        public Result Execute(SocioAmbientalSaveCommand command)
        {
            Result result = _socioAmbientalServiceBusiness.ValidateSave(command.SocioAmbiental);
            if (result.success)
            {
                //Set List RedSosten,AporteHogar,Ambiente;SituacionCrisis, ControlMedico  
                #region Agregar item a listas de RedSosten,Ambiente,SituacionCrisis,ControlMedico
                //Lista Red sosten
                foreach (var item in command.SocioAmbiental.listRedSostenFamiliar)
                {
                    if (item.Estado == true)
                    {
                        RedSosten += item.Id + ",";
                    }
                }
                //Lista AporteHogar
                //foreach (var item in command.SocioAmbiental.listAporteHogar)
                //{
                //    if (item.Estado == true)
                //    {
                //        AporteHogar += item.Id + ",";
                //    }
                //}
                //Lista Ambiente
                foreach (var item in command.SocioAmbiental.listAmbiente)
                {
                    if (item.Estado == true)
                    {
                        Ambiente += item.Id + ",";
                    }
                }
                //Lista SituacionCrisis
                foreach (var item in command.SocioAmbiental.listSituacionCrisis)
                {
                    if (item.Estado == true)
                    {
                        SituacionCrisis += item.Id + ",";
                    }
                }
                //Lista ControlMedico
                foreach (var item in command.SocioAmbiental.listPorgramaControlMedico)
                {
                    if (item.Estado == true)
                    {
                        ControlMedico += item.Id + ",";
                    }
                }
                #endregion

                SaveSocioAmbiental(command, ref result);
            }







            return result;
        }
        public void SaveSocioAmbiental(SocioAmbientalSaveCommand command, ref Result result)
        {
            var query = _repositryLocalScheme.Session.CallFunction("PCK_SALAS_CUNA.PR_REGISTRAR_SOC_AMBIENTAL (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");

            query.SetParameter(0, command.SocioAmbiental.TipoSocioAmbiental);
            query.SetParameter(1, command.SocioAmbiental.IdSocioAmbiental);
            query.SetParameter(2, command.SocioAmbiental.BeneficiarioId);
            query.SetParameter(3, command.ProgramaAplicacionId);
            query.SetParameter(4, command.UsuarioLogueadoId);
            
            query.SetParameter(5, command.SocioAmbiental.NumSocioId);
            query.SetParameter(6, command.SocioAmbiental.FechaEntrevista);
            query.SetParameter(7, command.SocioAmbiental.Profesional);
            query.SetParameter(8, command.SocioAmbiental.FechaRegistro);

            query.SetParameter(9, command.SocioAmbiental.CantidadNinos);
            query.SetParameter(10, command.SocioAmbiental.TieneDeuda == true ? 'S' : 'N');
            query.SetParameter(11, command.SocioAmbiental.TipoDeuda);
            query.SetParameter(12, command.SocioAmbiental.CantidadHabitaciones);
            query.SetParameter(13, command.SocioAmbiental.CursosRealizados);
            query.SetParameter(14, command.SocioAmbiental.GustosAprendizaje);
            query.SetParameter(15, command.SocioAmbiental.LecheEspecial);
            query.SetParameter(16, command.SocioAmbiental.EntregaLeche == true ? 'S' : 'N');
            query.SetParameter(17, command.SocioAmbiental.InstitucionSalud);
            query.SetParameter(18, command.SocioAmbiental.Observaciones);
            //--List
            query.SetParameter(19, command.SocioAmbiental.LecheId);
            query.SetParameter(20, command.SocioAmbiental.ObtencionLeche);
            query.SetParameter(21, command.SocioAmbiental.TipoFamiliaId);
            query.SetParameter(22, RedSosten);
            query.SetParameter(23, command.SocioAmbiental.OtraRedSostenFamiliar);
            
            query.SetParameter(24, Ambiente);
            query.SetParameter(25, ControlMedico);
            query.SetParameter(26, command.SocioAmbiental.OtroProgramaMedico);
            query.SetParameter(27, SituacionCrisis);
            query.SetParameter(28, command.SocioAmbiental.ObserCrisis);




            //--Caracteristicas
            query.SetParameter(29, command.SocioAmbiental.TipoVivienda.IdCaracteristica);
            query.SetParameter(30, command.SocioAmbiental.TipoVivienda.IdTipoCaracteristica);

            query.SetParameter(31, command.SocioAmbiental.AccesoVivienda.IdCaracteristica);
            query.SetParameter(32, command.SocioAmbiental.AccesoVivienda.IdTipoCaracteristica);

            query.SetParameter(33, command.SocioAmbiental.TenenciaTerreno.IdCaracteristica);
            query.SetParameter(34, command.SocioAmbiental.TenenciaTerreno.IdTipoCaracteristica);

            query.SetParameter(35, command.SocioAmbiental.Muros.IdCaracteristica);
            query.SetParameter(36, command.SocioAmbiental.Muros.IdTipoCaracteristica);

            query.SetParameter(37, command.SocioAmbiental.Techo.IdCaracteristica);
            query.SetParameter(38, command.SocioAmbiental.Techo.IdTipoCaracteristica);

            query.SetParameter(39, command.SocioAmbiental.Piso.IdCaracteristica);
            query.SetParameter(40, command.SocioAmbiental.Piso.IdTipoCaracteristica);



            query.SetParameter(41, command.SocioAmbiental.Banio.IdCaracteristica);
            query.SetParameter(42, command.SocioAmbiental.Banio.IdTipoCaracteristica);

            query.SetParameter(43, command.SocioAmbiental.UtilizacionBanio);
          

            query.SetParameter(44, command.SocioAmbiental.Cocina);


            query.SetParameter(45, command.SocioAmbiental.Agua != null ? command.SocioAmbiental.Agua.IdCaracteristica:null);
            query.SetParameter(46, command.SocioAmbiental.Agua != null ? command.SocioAmbiental.Agua.IdTipoCaracteristica:null);

            query.SetParameter(47, command.SocioAmbiental.Energia != null ? command.SocioAmbiental.Energia.IdCaracteristica:null);
            query.SetParameter(48, command.SocioAmbiental.Energia != null ?command.SocioAmbiental.Energia.IdTipoCaracteristica:null);

            query.SetParameter(49, command.SocioAmbiental.Coccion != null ? command.SocioAmbiental.Coccion.IdCaracteristica:null);
            query.SetParameter(50, command.SocioAmbiental.Coccion != null ? command.SocioAmbiental.Coccion.IdTipoCaracteristica:null);

            query.SetParameter(51, command.SocioAmbiental.Tarjeta != null ?command.SocioAmbiental.Tarjeta.IdCaracteristica:null);
            query.SetParameter(52, command.SocioAmbiental.Tarjeta != null ?command.SocioAmbiental.Tarjeta.IdTipoCaracteristica:null);


            result.Resolve(query.UniqueResult());
        }
    }
}
