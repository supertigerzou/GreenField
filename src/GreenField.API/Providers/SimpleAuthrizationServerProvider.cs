using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GreenField.Users.Data;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace GreenField.API.Providers
{
    internal class SimpleAuthrizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var authRepo = new AuthRepository())
            {
                var user = await authRepo.FindUser(context.UserName, context.Password);

                if(user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "as:client_id", context.ClientId ?? string.Empty
                    },
                    {
                        "username", context.UserName
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
    }
}
