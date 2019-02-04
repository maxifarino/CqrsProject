using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApi.Models.Usuario;

namespace WebApi.Controllers
{

    public class ApiControllerBase : ApiController
    {
        public CommandDispatcher _commandDispatcher;
        public QueryDispatcher _queryDispatcher;
        public Result _result;

        public ApiControllerBase() 
        {
            _commandDispatcher = ServiceLocator.Current.GetInstance<CommandDispatcher>();
            _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();       
        } 

        public Usuario GetUsuarioLogueado()
        {
            Usuario usuario = null; 
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            if (identity.Claims.Count() != 0) 
            {
                string usuarioSerialized = identity.Claims.ToList()[1].ToString();
                usuario = JsonConvert.DeserializeObject<Usuario>(usuarioSerialized.Substring(6));
                return usuario;            
            }
            return null;
        }
    }
}