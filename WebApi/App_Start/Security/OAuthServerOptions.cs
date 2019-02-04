using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.App_Start.Security
{
    public class OAuthServerOptions : OAuthAuthorizationServerOptions
    {

        public OAuthServerOptions()
        {
            
            #if DEBUG
                AllowInsecureHttp = true;
            #endif
            AllowInsecureHttp = true;
            TokenEndpointPath = new PathString("/v1/authenticationUser/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(518400);//518400 (un año)
            Provider = new AuthorizationServerProvider();
            RefreshTokenProvider = new RefreshTokenProvider();
        }
        
    }
}