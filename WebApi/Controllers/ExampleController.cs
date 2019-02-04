using GAP.Base;
using GAP.Base.Helper;
using GAP.Cqrs.Implementation.Query.ProvisionProductosCEQuery;
using GAP.Cqrs.Implementation.Query.ProvisionProductosQuery;
using GAP.Cqrs.Implementation.Query.UsuarioQuery;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers.Soporte;
using WebApi.Models.Usuario;

namespace WebApi.Controllers
{
    public class ExampleController : ReporteControllerBase
    {

        public IHttpActionResult Get() { return Ok(); }

        public IHttpActionResult Get(int id) { return Ok(default(object)); }

        [HttpGet]
        [ActionName("EnviarMail")]
        [AllowAnonymous]
        public IHttpActionResult EnviarMail([FromUri]ProvisionProductosQuery query)
        {            
            return Ok();
        }

    }
}
