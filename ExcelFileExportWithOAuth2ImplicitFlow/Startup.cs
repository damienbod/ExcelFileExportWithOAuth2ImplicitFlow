using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using ExcelFileExportWithOAuth2ImplicitFlow.Security;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;


[assembly: OwinStartup(typeof(ExcelFileExportWithOAuth2ImplicitFlow.Startup))]

namespace ExcelFileExportWithOAuth2ImplicitFlow
{
    public class Startup
    {
        public const string SigningKey = "Bp3sKtrLxjqjkqxulWMr32m6Hsfkwq49KD6KVHeWdvY=";
        public List<string> SecurityAudiences = new List<string>() { "ExcelFileExportWithOAuth2ImplicitFlow" };
        public const string Issuer = "AS";
        public const string Token = "token";

        public void Configuration(IAppBuilder app)
        {
            // authorization manager
            ClaimsAuthorization.CustomAuthorizationManager = new AuthorizationManager();

            // no mapping of incoming claims to Microsoft types
            JwtSecurityTokenHandler.InboundClaimTypeMap = ClaimMappings.None;

            // validate JWT tokens from AuthorizationServer
            var jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = SecurityAudiences,
                IssuerSecurityTokenProviders =
                    new List<IIssuerSecurityTokenProvider>()
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(Issuer, SigningKey)
                    },
                Provider = new QueryStringOAuthBearerProvider(Token)
            };
            app.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
