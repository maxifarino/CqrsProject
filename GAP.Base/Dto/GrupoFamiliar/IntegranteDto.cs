﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto.GrupoFamiliar
{
    public class IntegranteDto
    {
        public Int64 IdIntegrante { get; set; }
        public string Departamento { get; set; }
        public int Altura { get; set; }
        public string Torre { get; set; }
        public string NombreSexo { get; set; }
        public string Piso { get; set; }
        public string NombrePais { get; set; }
        public string NombrePaisNacionalidad { get; set; }
        public string CodigoPaisTipoDocumento { get; set; }
        public string CodigoPaisOrigen { get; set; }
        public string CodigoPaisNacionalidad { get; set; }
        public string CodigoPais { get; set; }
        public string NombreTipoDomicilio { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string NombreTipoCalle { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreProvincia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreLocalidad { get; set; }
        public string NombreDepartamento { get; set; }
        public string TieneObraSocial { get; set; }
        public string Profesion { get; set; }
        public string ObraSocial { get; set; }
        public string NivelAlcanzado { get; set; }
        public string NombreCalle { get; set; }
        public string NombreBarrio { get; set; }
        public int LocalidadId { get; set; }  //---NUMBER(6)
        public string VinculoId { get; set; }
        public string VinculoNombre { get; set; }
        public decimal DomicilioId { get; set; }  //--NUMBER (20)
        public int TipoDomicilioId { get; set; } //--NUMBER(4)
        public string TipoDocumentoId { get; set; }
        public string TieneObraSocialTipoId { get; set; }
        public string ProfesionTipoId { get; set; }
        public string ObraSocialTipoId { get; set; }
        public string NivelAlcanzadoTipoId { get; set; }
        public int TipoCalleId { get; set; } //-- NUMBER(2)
        public string SexoId { get; set; }
        public string ProvinciaId { get; set; }
        public Int64 NumeroId { get; set; } //-- NUMBER(10)
        //public int LocalidadId { get; set; } //-- NUMBER(6)
        public string GrupoFamiliarId { get; set; }
        public string EstadoCivilId { get; set; }
        public int DepartamentoId { get; set; } //--NUMBER(6)
        public string TieneObraSocialId { get; set; }
        public string ProfesionId { get; set; }
        public string ObraSocialId { get; set; }
        public string NivelAlcanzadoId { get; set; }
        public Int64 CalleId { get; set; } //-- NUMBER(10)
        public Int64 BarrioId { get; set; } //--NUMBER(10)
        public string HorariosOcupacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaDefuncion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string EsTutor { get; set; }
        public string ProgramaSocial { get; set; }
        public string ProgramaSocialTipoId { get; set; }
        public string ProgramaSocialId { get; set; }
        public string CodigoArea { get; set; }
        public string TelefonoCelular { get; set; }
        public string CodigoAreaAlternativo { get; set; }
        public string TelefonoAlternativo { get; set; }



    }
}
