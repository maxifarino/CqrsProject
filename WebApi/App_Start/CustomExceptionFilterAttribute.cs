using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http.Filters;

namespace WebApi.App_Start
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Se encarga de capturar y manejar las excepciones no controladas de la aplicación.
        /// </summary>
        /// <param name="actionExecutedContext"></param>

        public static readonly ILog log = log4net.LogManager.GetLogger(" CustomExceptionFilterAttribute ");
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            System.Configuration.Configuration configuration =
             System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");

             System.Web.Configuration.CustomErrorsSection section =
                (CustomErrorsSection)configuration.GetSection("system.web/customErrors");

             var inner = actionExecutedContext.Exception.InnerException;
             var exceptionMessage = (inner == null) ? actionExecutedContext.Exception.Message : inner.Message;

             CustomErrorsMode mode = section.Mode;
             if (mode == CustomErrorsMode.Off)
             {
                 exceptionMessage = actionExecutedContext.Exception.StackTrace.ToString();
             }
            // TODO Alvaro implementar log
            // Por cada excepción no controlada devolvemos un error 500 con una lista de errores.

            log.Error("ERROR: " + exceptionMessage);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new ErrorResult { Error = exceptionMessage });
            Task.FromResult<object>(null);
            //actionExecutedContext.Response.Headers.Add("X-Error", actionExecutedContext.Exception.Message);
        }       


    }
}
