using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using PalugaApi.Infrastructure.TokenGuard;
using ServiceLayer.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace PalugaApi
{
    public partial class Startup
    {
        protected IStudentService studentService { get; set; }

        private void ConfigureAuth(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            this.studentService = (IStudentService)serviceProvider.GetService(typeof(IStudentService));

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                Expiration = TimeSpan.FromMinutes(Double.Parse(Configuration.GetSection("TokenAuthentication:Expiration").Value)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,

                // Validate the token expiry
                ValidateLifetime = Convert.ToBoolean(Configuration.GetSection("TokenAuthentication:ValidateLifetime").Value),
                
                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            if (this.studentService.CheckCredits(username, password)) {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            }
            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
