using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FirebaseAdminAuthentication.DependencyInjection.Services
{
    public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly FirebaseAuthenticationFunctionHandler _authenticationFunctionHandler;

        public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            FirebaseAuthenticationFunctionHandler authenticationFunctionHandler)
            : base(options, logger, encoder, clock)
        {
            _authenticationFunctionHandler = authenticationFunctionHandler;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return _authenticationFunctionHandler.HandleAuthenticateAsync(Context);   
        }
    }
}
