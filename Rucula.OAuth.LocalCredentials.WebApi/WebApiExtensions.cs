using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Rucula.OAuth.LocalCredentials.WebApi;

public static class WebApiExtensions
{
    public static void AddLocalCredentials(this WebApplicationBuilder builder, Action<LocalCredentialsOptions> options)
    {
        options.Invoke(new LocalCredentialsOptions(builder));

        var appSettingsSection = builder.Configuration.GetSection("AppSettingsJwt");
        
        // builder.Configure<JsonWebToken>(appSettingsSection);

        var appSettings = appSettingsSection.Get<JsonWebToken>();
        // var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        // builder.Services.AddAuthentication(x =>
        // {
        //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        // }).AddJwtBearer(x =>
        // {
        //     x.RequireHttpsMetadata = false;
        //     x.SaveToken = true;
        //     x.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = new SymmetricSecurityKey(key),
        //         ValidateIssuer = true,
        //         ValidateAudience = true,
        //         ValidAudience = appSettings.ValidIn,
        //         ValidIssuer = appSettings.Issuer
        //     };
        // });

    }
}
