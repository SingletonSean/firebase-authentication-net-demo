using FirebaseAdminAuthentication.DependencyInjection.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace FirebaseAdminAuthentication.DependencyInjection.Extensions
{
    public static class AddFirebaseAuthenticationExtensions
    {
        public static IServiceCollection AddFirebaseAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddScheme<AuthenticationSchemeOptions, FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, (o) => { });

            services.AddScoped<FirebaseAuthenticationFunctionHandler>();

            return services;
        }
    }
}
