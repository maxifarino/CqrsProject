using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base
{
    public static class MessageError
    {

        #region Entidad

        public static string ENTIDAD_SAVE_ERROR_RAZON_SOCIAL = "La razón social es requerida";
        public static string ENTIDAD_SAVE_ERROR_RAZON_SOCIAL_LENGTH = "La razón social excede los 150 caracteres";
        public static string ENTIDAD_SAVE_ERROR_NOMBRE_FANTASIA_LENGTH = "El nombre de fantasía excede los 150 caracteres";
        public static string ENTIDAD_SAVE_ERROR_CUIL = "El cuil es requerido";
        public static string ENTIDAD_SAVE_ERROR_FORMATO_CUIL = "El cuil no cumple con el formato";
        public static string ENTIDAD_SAVE_ERROR_ALREADY_EXIST_ENTIDAD = "Existe una entidad registrada con el mismo número de Cuit o Razón Social";
        public static string ENTIDAD_SAVE_ERROR_FORMAJURIDICA_ID = "La Forma Juridica requerida";
        public static string ENTIDAD_SAVE_ERROR_FECHA_ALTA = "La Fecha es requerida";
        public static string ENTIDAD_SAVE_ERROR_ENTIDAD_BANCARIA = "Los datos de la entidad bancaria son requeridos";
        public static string ENTIDAD_SAVE_ERROR_RESPONSABLE = "El responsable asignado es requerido";
        #endregion

        #region Domicilio

        public static string DOMICILIO_SAVE_ERROR = "El domicilio tiene valores requeridos incompletos";
        public static string DOMICILIO_SAVE_ERROR_DIRECCION = "La dirección es un valor requerido";
        public static string DOMICILIO_SAVE_ALTURA = "La altura es un valor requerido";
        //public static string DOMICILIO_SAVE_ERROR_DEPARTAMENTO_ID = "El Departamento es un valor requerido, debe seleccionar";
        //public static string DOMICILIO_SAVE_ERROR_LOCALIDAD_ID = "La localidad es un valor requerido, debe seleccionar";
        //public static string DOMICILIO_SAVE_ERROR_BARRIO_ID = "El barrio es un valor requerido, debe seleccionar";
        //public static string DOMICILIO_SAVE_ERROR_TIPOCALLE_ID = "El Tipo de calle es un valor requerido, debe seleccionar";
        //public static string DOMICILIO_SAVE_ERROR_CALLE_ID = "La calle es un valor requerido, debe seleccionar";

        #endregion

        #region FormaJuridica

        #endregion

        #region Sala cuna
        public static string SALA_CUNA_SAVE_ERROR_NOMBRE = "El nombre de la sala cuna es un valor requerido.";
        public static string SALA_CUNA_SAVE_ERROR_FECHA_INICIO_TRAMITE = "La fecha de inicio de trámite de la sala cuna es un valor requerido.";
        public static string SALA_CUNA_SAVE_ERROR_ALREADY_EXIST_SALA_CUNA = "Existe una sala cuna registrada con el mismo código.";
        public static string SALA_CUNA_SAVE_ERROR_ENTIDAD_SELECCIONADA = "Debe seleccionar una entidad.";
        public static string SALA_CUNA_SAVE_ERROR_RESPONSABLE_SELECCIONADO = "Debe seleccionar un responsable.";
        public static string SALA_CUNA_SAVE_ERROR_FECHA_MAYOR_ACTUAL = "La fecha de inicio tramite es mayor a la fecha actual.";
        public static string SALA_CUNA_DELETE_ERROR_FECHA_BAJA = "La fecha de baja es un dato requerido.";
        public static string SALA_CUNA_DELETE_ERROR_FECHA_BAJA_ACTUAL = "La fecha de baja debe ser menor o igual a la fecha actual.";
        public static string SALA_CUNA_DELETE_ERROR_FECHA_BAJA_FECHA_TRAMITE = "La fecha de baja debe ser mayor a la fecha de inicio trámite.";
        public static string SALA_CUNA_DELETE_ERROR_FECHA_BAJA_FECHA_DEFINITIVA = "La fecha de baja debe ser mayor a la fecha de alta definitiva.";
        public static string SALA_CUNA_DELETE_ERROR_MOTIVO_BAJA = "Debe ingresar un motivo de baja.";
        public static string SALA_CUNA_DELETE_ERROR_BENEFICIARIOS_ACTIVOS = "La sala cuna tiene beneficiarios activos.";
        public static string SALA_CUNA_DELETE_ERROR_CAPITAL = "Debe seleccionar la zona de la Sala Cuna.";
        public static string SALA_CUNA_UPDATE_ERROR_FECHA_TRAMITE_MAYOR_DEFINITIVA = "La fecha de inicio de trámite debe ser menor a la fecha de alta definitiva.";
        public static string SALA_CUNA_DELETE_ERROR_CODIGO = "Debe ingresar el código de la Sala Cuna.";
        public static string SALA_CUNA_SAVE_ERROR_TURNO_DUPLICADO = "Ya existe ese turno para la Sala Cuna.";
        public static string SALA_CUNA_UPDATE_ERROR_FECHA_TRAMITE_MAYOR_INAUGURACION = "La fecha de inauguración debe ser mayor a la fecha de inicio de trámite.";
        
        #endregion

        #region Requisito
        public static string REQUISITO_SAVE_ERROR_FECHA_MAYOR_HOY = " Alguno de los requisitos tienen fecha mayor a la actual.";
        public static string REQUISITO_SAVE_ERROR_EXIST = " El requisito no existe.";
        public static string REQUISITO_SAVE_ERROR_FECHA_NULL = " Algunos requisitos no poseen fecha.";
        public static string REQUISITO_SAVE_ERROR_FECHA_PRESENTACION_MAYOR_VIGENCIA = " Alguno de los requisitos tienen fecha de presentación mayor a la fecha de Vigencia Hasta.";
        public static string REQUISITO_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION = " Alguno de los requisitos tienen fecha de presentación menor a la fecha de creación de la Sala Cuna.";

        #endregion

        #region Convenio
        //public static string REQUISITO_SAVE_ERROR_FECHA_MAYOR_HOY = "Alguno de los requisitos tienen fecha mayor a la actual.";
        //public static string REQUISITO_SAVE_ERROR_EXIST = "El requisito no existe.";
        //public static string REQUISITO_SAVE_ERROR_FECHA_NULL = "Algunos requisitos no poseen fecha.";
        public static string REQUISITO_SAVE_ERROR_FECHA_DESDE_MAYOR_HASTA = "La fecha desde no puede ser mayor a la fecha hasta.";
        public static string CONVENIO_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION = "El convenio tiene fecha desde menor a la fecha de creación de la Sala Cuna.";
        public static string CONVENIO_SAVE_ERROR_FECHA_DESDE_NULL = "La fecha desde debe ser una fecha válida";
        public static string CONVENIO_SAVE_ERROR_FECHA_HASTA_NULL = "La fecha hasta debe ser una fecha válida";
        #endregion

        #region Usuario
        public static string USUARIO_SAVE_ERROR_CUIL = "El cuil es un valor requerido.";
        public static string USUARIO_SAVE_NOT_EXISTS_IN_CIDI = "El usuario no existe en CIDI";
        public static string USUARIO_SAVE_LIST_ROL_EMPTY = "Al menos un rol es requerido.";
        public static string USUARIO_UPDATE_ID_EMPTY = "Parametro id_Usuario null.";
        public static string USUARIO_SAVE_ERROR_ROL = "El rol es un dato requerido";
        #endregion

        #region Rol
        public static string ROL_NO_EXISTE = "El Rol {0} no existe.";
        public static string ALREADY_HAS_ROL = "El Rol {0} ya esta asignado";
        #endregion

        #region Curso
        public static string CURSO_CANT_DIAS = "La cantidad de días es un dato requerido.";
        public static string CURSO_CANT_DIAS_MAX = "La cantidad de días es mayor a 99.";
        public static string CURSO_CANT_DIAS_MIN = "La cantidad de días es menor a 1.";
        public static string CURSO_FECHA_ALTA = "La fecha de alta es un dato requerido.";
        public static string CURSO_FECHA_INICIO = "La fecha de inicio es un dato requerido.";
        public static string CURSO_CANT_HORAS = "La cantidad de horas debe ser un valor entre 0.5 y 24.";
        public static string CURSO_ZONA = "Debe ingresar la zona.";
        public static string CURSO_PORCENTAJE = "Debe ingresar el porcentaje de asistencia del curso.";
        public static string CURSO_EXISTE = "Ya existe el curso para los datos ingresados";
        public static string CURSO_FECHA_MAYOR_ACTUAL = "La fecha de inicio no puede ser menor a la fecha de hoy";
        public static string CURSO_FECHA_FIN_MENOR_FECHA_INICIO = "La fecha fin no puede ser menor a la fecha de inicio";
        public static string CURSO_FECHA_INICIO_MAYOR_FECHA_ALTA = "La fecha inicio no puede ser mayor a la fecha de alta";
        public static string CURSO_NOMBRE = "El nombre del curso es un dato requerido";
        public static string CURSO_PORCENTAJE_MAYOR = "El porcentaje no puede ser mayor a 100";
        public static string CURSO_FECHA_ALTA_MAYOR = "La fecha de alta no puede ser mayor a la fecha de hoy";
        public static string CURSO_FECHA_INICIO_MENOR_FECHA_ALTA = "La fecha de inicio no puede ser menor a la fecha de alta";
        public static string CURSO_FECHA_MENOR_ACTUAL = "La fecha inicio no puede ser menor a la actual";

        #endregion

        #region SalitaCuna

        public static string SALITA_CUPO_VALOR_NO_NUMERICO = "El cupo máximo debe ser un valor numerico mayor o igual 0";
        public static string SALITA_CUPO_NO_CARGADO = "El cupo máximo debe ingresarse";
        public static string SALITA_TURNO_NO_ASIGNADO = "Se debe seleccionar el turno para la nueva salita";
        public static string SALITA_TIPO_SALITA_NO_ASIGNADA = "Se debe seleccionar el tipo de salita para la nueva salita";
        public static string SALITA_FECHA_BAJA_NO_ASIGNADA = "Se debe ingresar una fecha de baja para la eliminación salita, ésta debe ser una fecha menor o igual a la fecha: "+DateTime.Today.Date;
        public static string SALITA_SIN_ID_SALA_CUNA = "Falta identificador de la SALA CUNA";
        public static string SALITA_SIN_ID_SALITA_CUNA = "Falta identificador de la SALITA CUNA";
        public static string SALITA_DELETE_POSEE_BENEFICIARIOS = "Existen beneficiarios inscriptos en la salita, que asisten actualmente";
        public static string SALITA_POSEE_FECHABAJA = "Esta salita ya fue dada de baja con anterioridad";
        public static string SALITA_SIN_NOMBRE = "Se debe ingresar el nombre de la salita";
        public static string SALITA_CUPO_MAYOR_CANTIDAD_BENF = "Se debe ingresar un cupo que sea mayor a la cantidad de beneficiarios";
        public static string SALITA_SIN_ID_GRUPOETARIO = "Se debe seleccionar un Grupo Etario al beneficiario";
        #endregion

        #region Inmueble
        public static string INMUEBLE_DESCRIPCION_REQUERIDA = "La descripción es un dato requerido.";
        public static string INMUEBLE_MONTO_REQUERID0 = "El monto es un dato requerido.";
        public static string INMUEBLE_FECHAREALIZACION_REQUERIDA = "La fecha de realización es un dato requerido.";
        public static string INMUEBLE_SAVE_ERROR_FECHA_PRESENTACION_MENOR_CREACION = "La infraestructura tiene fecha desde menor a la fecha de creación de la Sala Cuna.";
        #endregion

        #region Beneficiario
        public static string BENEFICIARIO_SAVE_ERROR_FECHA_INSCRIPCION = " La fecha de inscripción del beneficiario es menor que la fecha de creación de la salita: ";
        public static string BENEFICIARIO_SAVE_ERROR_SEXOID_NULL = " El sexo es un dato requerido. ";
        public static string BENEFICIARIO_SAVE_ERROR_DOCUMENTO_NULL = " El DNI es un dato requerido. ";
        public static string BENEFICIARIO_SAVE_ERROR_PAIS_ORIGEN_ID_NULL = " El país de origen es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_PROVINCIA_ORIGEN_ID_NULL = " La provincia de origen es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_NOMBRE_NULL = " El nombre es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_APELLIDO_NULL = " El apellido es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_FECHA_NACIMIENTO_NULL = " La fecha de nacimiento es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_FECHA_NACIMIENTO_MAX = " La fecha de nacimiento es mayor a la fecha actual.";
        public static string BENEFICIARIO_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL = " El tipo de documento es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_ORGANISMO_EMISOR_NULL = " El organismo emisor es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_CORDIGO_PAIS_TD_NULL = " El país TD es un dato requerido";
        //public static string BENEFICIARIO_SAVE_ERROR_LOCALIDAD_ORIGEN_NULL = " La localidad del beneficiario origen es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_NACIONALIDAD_ID_NULL = " La nacionalidad del beneficiario es un dato requerido";
        public static string BENEFICIARIO_SAVE_ERROR_DETALLE_GUARDERIA_ID_NULL = " El detalle guardería es dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_DETALLE_ALERGIA_ID_NULL = " El detalle de alergia es dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_DETALLE_MEDICAMENTO_ID_NULL = " El detalle del medicamento es dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_DETALLE_INSTITUCION_MEDICA_ID_NULL = " La institución médica es dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_FECHA_CONTROL_NULL = " La fecha de último control.";
        public static string BENEFICIARIO_SAVE_ERROR_PESO_NULL = " El peso es dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_TALLA_NULL = " La talla es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_ENFERMEDAD_NULL = " La enfermedad es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_DISCAPACIDAD_NULL = " La discapacidad es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_DETALLE_OBRA_SOCIAL_NULL = " La obra social del beneficiario es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_GRUPO_SANGUINEO_NULL = " El grupo sanguíneo es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_SALITA_NULL = " La salita es un dato requerido.";
        public static string BENEFICIARIO_SAVE_ERROR_FECHA_ALTA_NULL = " La fecha de inscripción es requerida.";
        public static string BENEFICIARIO_PERSONA_SELECCIONADA_NULL = "Se debe seleccionar un beneficiario antes de registrarlo en la sala.";
        public static string BENEFICIARIO_SAVE_ERROR_LECHE_NULL = "La leche a recibir es un dato requerido";
        public static string BENEFICIARIO_SAVE_ERROR_PANIAL_NULL = "Los pañales a recibir es un dato requerido";
        public static string BENEFICIARIO_SAVE_ERROR_MOTIVO_NULL = "El motivo a recibir es un dato requerido";
        public static string BENEFICIARIO_INTEGRANTE_NULL = "Se debe seleccionar un Tutor antes de registrar un beneficiario en la sala";
        #endregion

        #region Tutor

        public static string TUTOR_SAVE_ERROR_SEXOID_NULL = " El sexo del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_DOCUMENTO_NULL = " El DNI del tutor es un dato requerido. ";
        public static string TUTOR_SAVE_ERROR_PAIS_ORIGEN_ID_NULL = " El país de origen del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_PROVINCIA_ORIGEN_ID_NULL = " La provincia de origen del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_NOMBRE_NULL = " El nombre del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_APELLIDO_NULL = " El apellido del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_FECHA_NACIMIENTO_NULL = " La fecha de nacimiento del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_FECHA_NACIMIENTO_MAX = " La fecha de nacimiento del tutor es mayor a la actual.";
        public static string TUTOR_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL = " El tipo de documento del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_ORGANISMO_EMISOR_NULL = " El organismo emisor del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_CORDIGO_PAIS_TD_NULL = " El país TD del tutor es un dato requerido";
       // public static string TUTOR_SAVE_ERROR_LOCALIDAD_ORIGEN_NULL = " La localidad origen del tutor es un dato requerido.";
        public static string TUTOR_SAVE_ERROR_NACIONALIDAD_ID_NULL = " La nacionalidad del tutor es un dato requerido";
        public static string TUTOR_SAVE_ERROR_OCUPACION_ID_NULL = " La ocupación del tutor es un dato requerido";
        public static string TUTOR_SAVE_ERROR_HORARIO_NULL = " El horario del tutor es un dato requerido";
        public static string TUTOR_SAVE_ERROR_NIVEL_ESCOLARIDAD_ID_NULL = " El nivel de escolaridad alcanzado del tutor es un dato requerido";
        public static string TUTOR_SAVE_ERROR_PROGRAMA_SOCIAL_ID_NULL = " El programa social del tutor es un dato requerido";
        public static string TUTOR_SAVE_ERROR_OBRA_SOCIAL_ID_NULL = " La obra social del integrante es un dato requerido";
        #endregion

        #region Integrante
        public static string INTEGRANTE_SAVE_ERROR_SEXOID_NULL = " El sexo del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_DOCUMENTO_NULL = " El DNI del integrante es un dato requerido. ";
        public static string INTEGRANTE_SAVE_ERROR_PAIS_ORIGEN_ID_NULL = " El país del integrante de origen es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_NOMBRE_NULL = " El nombre del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_APELLIDO_NULL = " El apellido del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_FECHA_NACIMIENTO_NULL = " La fecha de nacimiento del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_FECHA_NACIMIENTO_MAX = " La fecha de nacimiento del integrante es mayor a la actual.";
        public static string INTEGRANTE_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL = " El tipo de documento del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_ORGANISMO_EMISOR_NULL = " El organismo emisor del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_CORDIGO_PAIS_TD_NULL = " El país TD del integrante es un dato requerido";
       // public static string INTEGRANTE_SAVE_ERROR_LOCALIDAD_ORIGEN_NULL = " La localidad origen del integrante es un dato requerido.";
        public static string INTEGRANTE_SAVE_ERROR_NACIONALIDAD_ID_NULL = " La nacionalidad del integrante es un dato requerido";
        public static string INTEGRANTE_SAVE_ERROR_OCUPACION_ID_NULL = " La ocupación del integrante es un dato requerido";
        public static string INTEGRANTE_SAVE_ERROR_HORARIO_NULL = " El horario del integrante es un dato requerido";
        public static string INTEGRANTE_SAVE_ERROR_OBRA_SOCIAL_ID_NULL = " La obra social del integrante es un dato requerido";
        public static string INTEGRANTE_SAVE_ERROR_DISCAPACIDAD_ID_NULL = " Debe seleccionar una opción en la característica de Discapacidad";
        public static string INTEGRANTE_SAVE_ERROR_ENFERMEDAD_ID_NULL = " Debe seleccionar una opción en la característica de Enfermedad";
        public static string INTEGRANTE_SAVE_ERROR_NIVEL_ESCOLARIDAD_ID_NULL = " El nivel de escolaridad alcanzado del integrante es un dato requerido";
        public static string INTEGRANTE_SAVE_ERROR_PROGRAMA_SOCIAL_ID_NULL = " El programa social del integrante es un dato requerido";
        public static string INTEGRANTE_PERSONA_SELECCIONADA_NULL = "Faltan datos en la persona seleccionada en el integrante.";
        public static string INTEGRANTE_SAVE_ERROR_ESTADO_CIVIL_ID_NULL = "Debe seleccionar una opción del campo estado civil";
        public static string INTEGRANTE_SAVE_ERROR_VINCULO_ID_NULL = "Debe seleccionar un vínculo";
        public static string INTEGRANTE_SAVE_ERROR_OTRO_APORTE_NULL = "Debe ingresar otros aportes";
        public static string INTEGRANTE_SAVE_ERROR_PAIS_ORIGEN_NULL = "El país de origen es un datos requerido";
        #endregion

        #region SocioAmbiental

        public static string SOCIO_AMBIENTAL_SAVE_ERROR_NUM_SA_STRING = "Debe ingresar valores en el campo 'Número de socio ambiental'.";
        public static string SOCIO_AMBIENTAL_SAVE_ERROR_SIN_NUM_SA = "Debe ingresar Número de Socio Ambiental.";
        public static string SOCIO_AMBIENTAL_SAVE_ERROR_CANT_HIJOS = "Debe ingresar valores numéricos en el campo 'Cantidad de Hijos'.";
        public static string SOCIO_AMBIENTAL_SAVE_ERROR_RED_SOSTEN = "Debe seleccionar algún Tipo de  Sostén del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_AMBIENTE = "Debe seleccionar algún Tipo de Ambiente donde vive del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_PROGRAMA = "Debe seleccionar algún Programa de Control Médico  del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_SIT_CRISIS = "Debe seleccionar algún tipo de Situación de Crisis  del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_TIPOLECHE = "Debe seleccionar algún tipo de Leche que consume el niño.";
        public static string SOCIO_AMBIENTAL_SAVE_OBTENCIONLECHE = "Debe seleccionar como obtiene la leche Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_FECHA_ENTREVISTA = "Debe ingresar una fecha de registro.";
        public static string SOCIO_AMBIENTAL_SAVE_PRPFESIONAL = "Debe ingresar un profesional.";
        public static string SOCIO_AMBIENTAL_SAVE_TIPO_FAMILIA = "Debe seleccionar el tipo de familia del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_COCINA = "Debe seleccionar el tipo de Cocina del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_UTILIZACION_BANIO = "Debe seleccionar el tipo de Utilización de Baño del Beneficiario.";
        public static string SOCIO_AMBIENTAL_SAVE_LECHE_ESPECIAL = "Debe seleccionar la leche especial que consume el niño.";
        public static string SOCIO_AMBIENTAL_OTRO_RED_SOSTEN = "Debe seleccionar otro red Sostén.";
        public static string SOCIO_AMBIENTAL_TIPO_VIVIENDA= "Debe seleccionar Tipo de Vivienda.";
        public static string SOCIO_AMBIENTAL_ACCESOVIVIENDA = "Debe seleccionar Tipo de Acceso Vivienda.";
        public static string SOCIO_AMBIENTAL_TERRENO = "Debe ingresar Tenencia de Terreno.";
        public static string SOCIO_AMBIENTAL_PISO = "Debe seleccionar Tipo de Piso Vivienda.";
        public static string SOCIO_AMBIENTAL_BANIO = "Debe seleccionar Tipo de baño Vivienda.";
        public static string SOCIO_AMBIENTAL_MUROS = "Debe seleccionar Tipo de Muros Vivienda.";
        public static string SOCIO_AMBIENTAL_TECHO = "Debe seleccionar Tipo de Techo Vivienda.";
        public static string SOCIO_AMBIENTAL_OTRO_PROGRAMA_MEDICO = "Debe Insegrar algún otro programa de control Médico que posee el beneficiario.";
        public static string SOCIO_AMBIENTAL_TARJETA = "Seleccione si el Beneficiario posee o no algún tipo de Tarjeta de crédito.";
        public static string SOCIO_AMBIENTAL_TIPO_DEUDA = "Ingrese tipo de deuda que posee el Beneficiario.";
        #endregion
        public static string PERSONAL_TURNO = "Debe seleccionar un Turno.";
        public static string PERSONAL_FECHA = "Debe seleccionar una Fecha de Asignación.";
        public static string PERSONAL_CARGO = "Debe seleccionar un Cargo.";
        public static string PERSONAL_FECHA_PRESENTACION = "Hay requisitos presentados sin fecha de presentación.";
        public static string PERSONAL_SAVE_ERROR_SEXOID_NULL = " El sexo del personal es un dato requerido.";
        public static string PERSONAL_SAVE_ERROR_FECHA_ASIG = "La fecha de asignación es menor a la fecha de la creación de la Sala Cuna.";
        public static string PERSONAL_SAVE_ERROR_NOMBRE_NULL = " El nombre del personal es un dato requerido.";
        public static string PERSONAL_SAVE_ERROR_APELLIDO_NULL = " El apellido del personal es un dato requerido.";
        public static string PERSONAL_SAVE_ERROR_FECHA_NACIMIENTO_NULL = " La fecha de nacimiento del personal es un dato requerido.";
        public static string PERSONAL_SAVE_ERROR_FECHA_NACIMIENTO_MAX = " La fecha de nacimiento del personal es mayor a la fecha actual.";
        public static string PERSONAL_SAVE_ERROR_TIPO_DOCUMENTO_ID_NULL = " El tipo de documento del personal es un dato requerido.";
        //public static string PERSONAL_SAVE_ERROR_LOCALIDAD_ORIGEN_NULL = " La localidad origen del personal es un dato requerido.";
        public static string PERSONAL_SAVE_ERROR_NACIONALIDAD_ID_NULL = " La nacionalidad del personal es un dato requerido";
        public static string PERSONAL_SAVE_ERROR_PAIS_ID_NULL = " El país del personal es un dato requerido";
        public static string PERSONAL_SAVE_ERROR_PROVINCIA_ID_NULL = " La provincia del personal es un dato requerido";
        public static string PERSONAL_SAVE_ERROR_ESTADO_CIVIL_ID_NULL = "Debe seleccionar una opción del campo estado civil";
        public static string PERSONAL_PERSONA_SELECCIONADA_NULL = "Faltan datos en la persona seleccionada en el personal.";
        public static string PERSONAL_SAVE_ERROR_DOS_TURNOS = " El personal se encuentra en mas de dos turnos.";
        public static string PERSONAL_FECHA_MAYOR_ACTUAL = "Hay requisitos presentados con fecha mayor a la actual.";
        


        #region Personal

        public static string INSCRIPCION_ERROR_PERSONAL = "La personada seleccionada no es un personal registrado";
        public static string INSCRIPCION_ERROR_PERSONA_SELECCIONADA = "Debe seleccionar una persona";

        #endregion

       
    }
}
