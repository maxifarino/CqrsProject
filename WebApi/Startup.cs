using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using WebApi.App_Start.Security;
using System.Web.Http;
using GAP.Infraestructure;
using System.Web;
using System.Web.SessionState;
using System.Web.Routing;
using System.Security.Claims;
using WebApi.App_Start;
using CiDi.SDK.Common;
using System.Globalization;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GAP.Base;
using GAP.Cqrs.Implementation.CommandHandler.ReportePackage;

[assembly: OwinStartup(typeof(WebApi.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new GuyWire().Wire();

            log4net.Config.XmlConfigurator.Configure();

            // Soporte para OAuth Bearer Tokens Generation.
            ConfigureOAuth(app);

            var webApiConfiguration = new HttpConfiguration();

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new CiDi.SDK.Login.WebApi.NET45.CiDiLoginWebApiHandler());

            webApiConfiguration.MessageHandlers.Add(new CiDi.SDK.Login.WebApi.NET45.CiDiLoginWebApiHandler());

            webApiConfiguration.MapHttpAttributeRoutes();

            webApiConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RouteTable.Routes.MapRoute(
                name: "DefaultApiMvc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            webApiConfiguration.Filters.Add(new CustomExceptionFilterAttribute());
            webApiConfiguration.Filters.Add(new AuthorizationFilter());

            var jsonFormatter = webApiConfiguration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Culture = new CultureInfo("es-AR");
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");          

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //// Filtro para el manejo de excepciones no controladas.
            //config.Filters.Add(new CustomExceptionFilterAttribute());

            //// Filtro para el control de autorización de peticiones.
            //config.Filters.Add(new AuthorizationFilter());

            app.UseWebApi(webApiConfiguration);

            RegisterCDI();

            SaveContextValues();
            RemoveTempFilesTimer.Init();
            ConsultarReportesTimer.Init();
        }

        public void RegisterCDI()
        {
            var appCidi = new App();
            appCidi.ID = GlobalVars.CiDiIdAplicacion;
            appCidi.EntornoEjecucion = GlobalVars.CiDiProduccion ? Entorno.Produccion: Entorno.Desarrollo;
            appCidi.Password = GlobalVars.CiDiPassAplicacion;
            appCidi.Key = GlobalVars.CiDiKeyAplicacion;                
            appCidi.Registrar();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthServerOptions());
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void SaveContextValues()
        {
            string _tempReportsPath = HttpContext.Current.Server.MapPath("~/TempReports/");

            string _applicationPath = HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath);

            ContextSingleton.InitInstance(_tempReportsPath, _applicationPath);
        }

    }
}
