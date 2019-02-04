using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Repository.Cidi.CidiUtil
{
    #region Model Cuenta

    public class Usuario
    {
        public String CUIL { get; set; }
        public String CuilFormateado { get; set; }
        public String NroDocumento { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public String NombreFormateado { get; set; }
        public String FechaNacimiento { get; set; }
        public String Id_Sexo { get; set; }
        public String PaiCodPais { get; set; }
        public int Id_Numero { get; set; }
        public int? Id_Estado { get; set; }
        public String Estado { get; set; }
        public String Email { get; set; }
        public String TelArea { get; set; }
        public String TelNro { get; set; }
        public String TelFormateado { get; set; }
        public String CelArea { get; set; }
        public String CelNro { get; set; }
        public String CelFormateado { get; set; }
        public String Empleado { get; set; }
        public String Id_Empleado { get; set; }
        public String FechaRegistro { get; set; }
        public String FechaBloqueo { get; set; }
        public String IdAplicacionOrigen { get; set; }
        public String TieneRepresentados { get; set; }
        //public Domicilio Domicilio { get; set; }
        //public Representado Representado { get; set; }
        public Respuesta Respuesta { get; set; }
        public Usuario()
        {
            //Domicilio = new Domicilio();
            //Representado = new Representado();
            Respuesta = new Respuesta();
        }
    }
    public class Respuesta
    {
        public String Resultado { get; set; }
        public String CodigoError { get; set; }
        public String ExisteUsuario { get; set; }
        public String SesionHash { get; set; }
    }

    #endregion

    #region Model Comunicaciones

    public class Email
    {
        public int Id_App { get; set; }
        public string Pass_App { get; set; }
        public string Cuil { get; set; }
        public string Asunto { get; set; }
        public string Subtitulo { get; set; }
        public string Mensaje { get; set; }
        public string InfoDesc { get; set; }
        public string InfoDato { get; set; }
        public string InfoLink { get; set; }
        public string Firma { get; set; }
        public string Ente { get; set; }
        public string TokenValue { get; set; }
        public string TimeStamp { get; set; }
    }
    public class ResultadoEmail
    {
        public string Resultado { get; set; }
        public string Mensaje { get; set; }
        public string Email { get; set; }
    }

    #endregion
}
