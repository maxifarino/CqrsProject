using CiDi.SDK.Common;
using CiDi.SDK.Login.Service;
using GAP.Base;
using GAP.Base.Dto.Usuario;
using GAP.Repository.Cidi.CidiUtil;
using GAP.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Repository.Cidi
{
    public class RepositoryCidi : IRepositoryCidi, IRepository
    {

        public UsuarioCidiDto ObtenerUsuarioActivo(string hash)
        {

            GAP.Repository.Cidi.CidiUtil.Usuario usuario;
            Entrada entrada = new Entrada();
            entrada.IdAplicacion = GlobalVars.CiDiIdAplicacion;
            entrada.Contrasenia = GlobalVars.CiDiPassAplicacion;
            entrada.HashCookie = hash;
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = Config.ObtenerToken_SHA1(entrada.TimeStamp);
            usuario = Config.LlamarWebAPI<Entrada, GAP.Repository.Cidi.CidiUtil.Usuario>(APICuenta.Usuario.Obtener_Usuario_Aplicacion, entrada);

            UsuarioCidiDto usuarioCidiDto = null;

            if (usuario.Respuesta.Resultado == GlobalVars.CiDi_OK)
            {
                usuarioCidiDto = new UsuarioCidiDto { 
                    Nombre = usuario.Nombre, 
                    Apellido = usuario.Apellido, 
                    Cuil = usuario.CUIL,
                    Email = usuario.Email
                };
            }
            return usuarioCidiDto;
        }

        public void EnviarMailUsuarioLogueado(String hash)
        {
            Email _Email = new Email();
            ResultadoEmail _ResultadoEmail = new ResultadoEmail();

            //_Email.HashCookie = hash;
            _Email.Asunto = "Prueba";
            _Email.Subtitulo = "Subtitulo";
            _Email.Mensaje = "Contenido del mail";
            _Email.InfoDesc = "InfoDesc";
            _Email.InfoDato = "InfoDato";
            _Email.InfoLink = "http://google.com";
            _Email.Firma = "Firma";
            _Email.Ente = "Gobierno de Córdoba";
            _Email.Id_App = GlobalVars.CiDiIdAplicacion;
            _Email.Pass_App = GlobalVars.CiDiPassAplicacion;
            _Email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _Email.TokenValue = Config.ObtenerToken_SHA1(_Email.TimeStamp);

            /*Entrada entrada = new Entrada();
            entrada.IdAplicacion = ;
            entrada.Contrasenia = ;
            entrada.HashCookie = hash;
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = Config.ObtenerToken_SHA1(entrada.TimeStamp);*/

            _ResultadoEmail = Config.LlamarWebAPI<Email, GAP.Repository.Cidi.CidiUtil.ResultadoEmail>(APIComunicacion.Email.Enviar, _Email);
        }

        public ResultadoEmail EnviarMailPorCuil(String cuil, String link, String mensaje, String nombreReporte)
        {
            //Cidi.CidiUtil.APIComunicacion.;
            Email _Email = new Email();
            ResultadoEmail _ResultadoEmail = new ResultadoEmail();

            _Email.Cuil = cuil;
            _Email.Asunto = nombreReporte;
            _Email.Subtitulo = String.Empty;
            _Email.Mensaje = mensaje;
            _Email.InfoDesc = GlobalVars.EmailInfoDesc;
            _Email.InfoDato = GlobalVars.EmailInfoDato;
            _Email.InfoLink = link;
            _Email.Firma = GlobalVars.EmailFirma;
            _Email.Ente = GlobalVars.EmailEnte;
            _Email.Id_App = GlobalVars.CiDiIdAplicacion;
            _Email.Pass_App = GlobalVars.CiDiPassAplicacion;
            _Email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _Email.TokenValue = Config.ObtenerToken_SHA1(_Email.TimeStamp);
            _ResultadoEmail = Config.LlamarWebAPI<Email, GAP.Repository.Cidi.CidiUtil.ResultadoEmail>(APIComunicacion.Email.Enviar, _Email);

            return _ResultadoEmail;
        }
    }
}
