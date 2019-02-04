using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GAP.Base
{
    public static class GlobalVars
    {
        /// <summary>
        /// Id de la aplicacion.
        /// Es requerido en algunos STORE PROCEDURES de gobierno.
        /// </summary>
        //public const int IdApplication = 206;
        public static int IdApplication
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["IdApplicationSalasCunas"]);
            }
        }

        /// <summary>
        /// Utilizado para indicar cuando se este trabajando con objetos MOCK
        /// en algunos bloques de código.
        /// 
        /// Solo puede estar en true en un ambiente de desarrollo.
        /// En producción debe estar en false.
        /// </summary>

        public static bool MockedMode
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["MockedMode"]);
            }
        }

        /// <summary>
        /// 
        /// UTN desarrollo: default_conection
        /// UTN Testing: utn_testing
        /// Gobierno dba: salas_cuna_dba 
        /// Gobierno app: salas_cuna_app 
        /// </summary>       
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultConectionString"];
            }
        }

        /// <summary>
        /// Activa la validación en el acceso a cada método de los controladores de acuerdo a 
        /// los que tiene permiso el rol del usuario autenticado.
        /// 
        /// Solo puede estar en false en un ambiente de desarrollo. 
        /// En producción debe estar en true.
        /// </summary>

        public static bool AuthenticationByRouteController
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["AuthenticationByRouteController"]);
            }
        }

        /// <summary>
        /// Recupera el path del directorio utilizado para almacenar archivos temporales.
        /// </summary>
        public static int CantDiasArchivosPersistidos
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CantDiasArchivosPersistidos"]);
            }
        }

        public static String EmailMensaje
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailMensaje"];
            }
        }

        public static String EmailInfoDesc
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailInfoDesc"];
            }
        }

        public static String EmailInfoDato
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailInfoDato"];
            }
        }

        public static String EmailFirma
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailFirma"];
            }
        }

        public static String EmailEnte
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailEnte"];
            }
        }

        /// <summary>
        /// Recupera la ruta relativa del recurso de la api para descargar reportes.
        /// </summary>
        public static String ApiDescargarReporte
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiDescargarReporte"];
            }
        }
        
        

        /// <summary>
        /// Utilizada para diferenciar cuando la aplicación desplegará en entorno de 
        /// producción o test en CIDI.
        /// </summary>

        public static bool CiDiProduccion
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["CiDiProduccion"]);
            }
        }

        /// <summary>
        /// UTN desarrollo / testing / Gob dba: '' (vacio)
        /// Gobierno app: 'SALAS_CUNA.' 
        /// </summary>

        public static string NombreEsquema
        {
            get
            {
                return ConfigurationManager.AppSettings["NombreEsquema"];
            }
        }

        /// <summary>
        /// Nombre del paquete de seguridad
        /// </summary>
        public static string PackageName
        {
            get
            {
                return ConfigurationManager.AppSettings["PackageName"];
            }
        }

        #region Variables Ciudadano Digital


        public static String CiDiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrl"].ToString();
            }
        }

        public static String CiDiUrlIniciarSesion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlIniciarSesion"].ToString() + "?app=" + CiDiIdAplicacion;
            }
        }  

        public static String CiDiUrlCerrarSesion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlCerrarSesion"].ToString();
            }
        }        

        public static String UrlEjemplo
        {
            get
            {
                return ConfigurationManager.AppSettings["MyAppUrl"].ToString();
            }
        }

        public static int CiDiIdAplicacion
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CiDiIdAplicacion"].ToString());
            }
        }

        public static String CiDiPassAplicacion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiPassAplicacion"].ToString();
            }
        }

        public static String CiDiKeyAplicacion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiKeyAplicacion"].ToString();
            }
        }

        public static String APICuenta
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlAPICuenta"].ToString();
            }
        }

        public static String APIComunicacion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlAPIComunicacion"].ToString();
            }
        }

        public static String APIDocumentacion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlAPIDocumentacion"].ToString();
            }
        }

        public static String APIMobile
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlAPIMobile"].ToString();
            }
        }

        public static String CiDiUrlRelacion
        {
            get
            {
                return ConfigurationManager.AppSettings["CiDiUrlRelacion"].ToString();
            }
        }

        public static String CiDi_OK
        {
            get
            {
                return "OK";
            }
        }

        #endregion

    }
}
