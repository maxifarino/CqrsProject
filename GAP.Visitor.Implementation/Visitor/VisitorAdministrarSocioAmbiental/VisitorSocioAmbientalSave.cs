using GAP.Base;
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor.VisitorAdministrarSocioAmbiental
{
    public class VisitorSocioAmbientalSave : IVisitorSocioAmbiental
    {
        private Int64 numero = 0;
        public int flagSosten = 0;
        public int flagAmbiental = 0;
        public int flagControl = 0;
        public int flagCrisis = 0;
        public int idRedSosten = 0;
        public int idOtroPrograma = 0;


        private readonly RepositoryLocalScheme _repositoryLocalScheme;
        public VisitorSocioAmbientalSave(RepositoryLocalScheme repository)
        {
            _repositoryLocalScheme = repository;
        }
        public override void Visit(SocioAmbiental socioAmbiental)
        {
            #region (Listas: RedSosten, Ambiente, ControlMedico, Crisis)- Validar que las listas por lo menos tenga seleccionado un valor//Estado =true.
            
            foreach (var item in socioAmbiental.listRedSostenFamiliar)
            {
                if (item.Estado != false)
                    flagSosten = 1;
                if (item.Id == 6 && item.Estado == true) { idRedSosten = item.Id; }

            }

            foreach (var item in socioAmbiental.listAmbiente)
            {
                if (item.Estado != false)
                    flagAmbiental = 1;
            }

            foreach (var item in socioAmbiental.listPorgramaControlMedico)
            {
                if (item.Estado != false)
                    flagControl = 1;
                if (item.Id == 8 && item.Estado == true) { idOtroPrograma = item.Id; }

            }

            //foreach (var item in socioAmbiental.listSituacionCrisis)
            //{
            //    if (item.Estado != false)
            //        flagCrisis = 1;
            //}

            //Validacion Vivienda
            if (string.IsNullOrEmpty(socioAmbiental.TipoVivienda.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_TIPO_VIVIENDA);
            if (string.IsNullOrEmpty(socioAmbiental.AccesoVivienda.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_ACCESOVIVIENDA);
            if (string.IsNullOrEmpty(socioAmbiental.TenenciaTerreno.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_TERRENO);
            if (string.IsNullOrEmpty(socioAmbiental.Muros.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_MUROS);
            if (string.IsNullOrEmpty(socioAmbiental.Techo.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_TECHO);
            if (string.IsNullOrEmpty(socioAmbiental.Piso.IdCaracteristica))
                this.AddError(MessageError.SOCIO_AMBIENTAL_PISO);
            if (socioAmbiental.Banio==null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_BANIO);

            //
            if (flagSosten != 1)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_ERROR_RED_SOSTEN);

            if (flagAmbiental != 1)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_AMBIENTE);

            if (flagControl != 1)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_PROGRAMA);

            //if (flagCrisis != 1)
            //    this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_SIT_CRISIS);

            #endregion

            if (!Int64.TryParse(socioAmbiental.NumSocioId.ToString(), out numero) || socioAmbiental.NumSocioId == null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_ERROR_NUM_SA_STRING);

            //if (!int.TryParse(socioAmbiental.CantidadNinos.ToString(), out numero))
            //    this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_ERROR_CANT_HIJOS);

            if (socioAmbiental.LecheId == 0)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_TIPOLECHE);

            if (socioAmbiental.TipoFamiliaId == 0)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_TIPO_FAMILIA);

            if (socioAmbiental.ObtencionLeche == 0)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_OBTENCIONLECHE);

            if (socioAmbiental.FechaEntrevista == null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_FECHA_ENTREVISTA);

            if (socioAmbiental.Profesional == null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_PRPFESIONAL);

            if (socioAmbiental.Cocina == null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_COCINA);

            if (socioAmbiental.UtilizacionBanio == null)
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_UTILIZACION_BANIO);

            if (socioAmbiental.Tarjeta != null) {

                if (socioAmbiental.Tarjeta.IdCaracteristica == null)
                {
                    this.AddError(MessageError.SOCIO_AMBIENTAL_TARJETA);
                }
            }
            else
            {
                this.AddError(MessageError.SOCIO_AMBIENTAL_TARJETA);
            }
                
              

            if (socioAmbiental.TieneDeuda == true && string.IsNullOrEmpty(socioAmbiental.TipoDeuda))
                this.AddError(MessageError.SOCIO_AMBIENTAL_TIPO_DEUDA);

            //Leche especial id=15 si lo selecciona debe ingresar la tipo de leche
            if (socioAmbiental.LecheId == 15 && string.IsNullOrEmpty(socioAmbiental.LecheEspecial))
                this.AddError(MessageError.SOCIO_AMBIENTAL_SAVE_LECHE_ESPECIAL);
            
            //Red sosten 
            if (idRedSosten == 6 && string.IsNullOrEmpty(socioAmbiental.OtraRedSostenFamiliar))
                this.AddError(MessageError.SOCIO_AMBIENTAL_OTRO_RED_SOSTEN);

            //Programa de control Médico
            if (idOtroPrograma == 8 && string.IsNullOrEmpty(socioAmbiental.OtroProgramaMedico))
                this.AddError(MessageError.SOCIO_AMBIENTAL_OTRO_PROGRAMA_MEDICO);

        }
    }
}
