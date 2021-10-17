using FirebaseAdminAuthentication.DependencyInjection.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FirebaseAdminAuthentication.DependencyInjection.Extensions
{
    public static class GetFirebaseUserHttpContextExtensions
    {
        public static FirebaseUser GetFirebaseUser(this HttpContext httpContext)
        {
            ClaimsPrincipal claimsPrincipal = httpContext.User;

            string id = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.ID);
            string email = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL);
            string username = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.USERNAME);
            bool.TryParse(claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL_VERIFIED), out bool emailVerified);

            return new FirebaseUser(id, email, username, emailVerified);
        }
    }
}
