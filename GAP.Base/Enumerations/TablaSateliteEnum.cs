using GAP.Base.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Enumerations
{
    public enum TablaSateliteEnum
    {
        [CallSpAttribute(NameSp = "PR_OBTENER_SEXOS()")]
        SEXO = 1,

        [CallSpAttribute(NameSp = "PR_OBTENER_TIPO_DOCUMENTO()")]
        TIPO_DOCUMENTO = 2,

        [CallSpAttribute(NameSp = "PR_OBTENER_EST_SAL_CUN()")]
        ESTADO_SALACUNA = 3,

        [CallSpAttribute(NameSp = "PR_OBTENER_FORMAS_JURIDICAS()")]
        FORMA_JURIDICA = 4,

        [CallSpAttribute(NameSp = "PR_OBTENER_TURNOS_SALITA()")]
        TURNO_SALITA = 5,

        [CallSpAttribute(NameSp = "PR_OBTENER_TIPO_SALITAS()")]
        TIPO_SALITA = 6,

        [CallSpAttribute(NameSp = "PR_OBTENER_BANCOS()")]
        BANCO = 7,

        [CallSpAttribute(NameSp = "PR_OBTENER_OBRA_SOCIAL()")]
        OBRA_SOCIAL = 8,

        [CallSpAttribute(NameSp = "PR_OBTENER_NACIONALIDAD()")]
        NACIONALIDAD = 9,

        [CallSpAttribute(NameSp = "PR_OBTENER_GRUPO_SANGUINEO()")]
        GRUPO_SANGUINEO = 10,

        [CallSpAttribute(NameSp = "PR_OBTENER_ENFERMEDADES()")]
        ENFERMEDAD = 11,

        [CallSpAttribute(NameSp = "PR_OBTENER_NIV_ESCOLARIDAD()")]
        NIVEL_ESCOLARIDAD = 12,

        [CallSpAttribute(NameSp = "PR_OBTENER_OCUPACIONES()")]
        OCUPACION = 13,

        [CallSpAttribute(NameSp = "PR_OBTENER_PAISES()")]
        PAIS = 14,

        [CallSpAttribute(NameSp = "PR_OBTENER_PROG_SOCIAL()")]
        PROGRAMA = 15,

        [CallSpAttribute(NameSp = "PR_OBTENER_DISCAPACIDAD()")]
        DISCAPACIDAD = 16,

        [CallSpAttribute(NameSp = "PR_OBTENER_OBTEN_LECHE()")]
        LECHE = 17,

        [CallSpAttribute(NameSp = "PR_OBTENER_TARJETA_CREDITO()")]
        TARJETACREDITO = 18,

        [CallSpAttribute(NameSp = "PR_OBTENER_RED_SOSTEN()")]
        REDSOSTEN = 19,

        [CallSpAttribute(NameSp = "PR_OBTENER_APORTE_HOGAR()")]
        APORTEHOGAR = 20,

        [CallSpAttribute(NameSp = "PR_OBTENER_TIPOS_VIVIENDA()")]
        TIPOVIVIENDA = 21,

        [CallSpAttribute(NameSp = "PR_OBTENER_ACCESO_VIVIENDA()")]
        ACCESOVIVIENDA = 22,

        [CallSpAttribute(NameSp = "PR_OBTENER_TERRENO()")]
        TERRENO = 23,

        [CallSpAttribute(NameSp = "PR_OBTENER_MUROS()")]
        MUROS = 24,

        [CallSpAttribute(NameSp = "PR_OBTENER_TECHOS()")]
        TECHOS = 25,

        [CallSpAttribute(NameSp = "PR_OBTENER_PISOS()")]
        PISOS = 26,

        [CallSpAttribute(NameSp = "PR_OBTENER_BANIO()")]
        BANIO = 27,

        [CallSpAttribute(NameSp = "PR_OBTENER_UTIL_BANIO()")]
        UTILBANIO = 28,

        [CallSpAttribute(NameSp = "PR_OBTENER_AMBIENTE()")]
        AMBIENTE = 29,

        [CallSpAttribute(NameSp = "PR_OBTENER_AGUA()")]
        AGUA = 30,

        [CallSpAttribute(NameSp = "PR_OBTENER_ENERGIA()")]
        ENERGIA = 31,

        [CallSpAttribute(NameSp = "PR_OBTENER_COCCION()")]
        COCCION = 32,

        [CallSpAttribute(NameSp = "PR_OBTENER_SIT_CRISIS()")]
        CRISIS = 33,

        [CallSpAttribute(NameSp = "PR_OBTENER_LECHE_CONSUMO()")]
        CONSUMO = 34,

        [CallSpAttribute(NameSp = "PR_OBTENER_CONTROL_MEDICO()")]
        CONTROLMEDICO = 35,

        [CallSpAttribute(NameSp = "PR_OBTENER_TIPO_FAMILIA()")]
        TIPOFAMILIA = 36,

        [CallSpAttribute(NameSp = "PR_OBTENER_COCINA()")]
        COCINA = 37,

        [CallSpAttribute(NameSp = "PR_OBTENER_VINCULOS()")]
        VINCULO = 38,

        [CallSpAttribute(NameSp = "PR_OBTENER_ESTADO_CIVIL()")]
        ESTADO_CIVIL = 39,

        [CallSpAttribute(NameSp = "PR_OBTENER_COBERTURA_MEDICA()")]
        COBERTURA_MEDICA = 40,

        [CallSpAttribute(NameSp = "PR_OBTENER_BENEF_SOCIAL()")]
        BENEFICIO = 41,

        [CallSpAttribute(NameSp = "PR_OBTENER_CARGOS_PERSONAL()")]
        CARGOS = 42,

        [CallSpAttribute(NameSp = "PR_OBTENER_RQS_PERSONAL()")]
        REQUISITOS = 43,
   
        [CallSpAttribute(NameSp = "PR_OBTENER_SALAS()")]
        SALAS_CUNA = 44,

        [CallSpAttribute(NameSp = "PR_OBTENER_CURSOS()")]
        CURSOS = 45,

        [CallSpAttribute(NameSp = "PR_OBTENER_MOTIVOS_ESPECIAL()")]
        MOTIVOS_ESPECIAL = 46,

        [CallSpAttribute(NameSp = "PR_OBTENER_LECHE_CASO_ESPECIAL()")]
        LECHE_ESPECIAL = 47,

        [CallSpAttribute(NameSp = "PR_OBTENER_PANIAL_CASO_ESP()")]
        PANIAL_ESPECIAL = 48  
    }
}
