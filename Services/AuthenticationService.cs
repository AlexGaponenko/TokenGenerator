using Azure.Core;
using Azure.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using TokenGenerator.Domain.Interfaces;
using TokenGenerator.Domain.Models;
using TokenGenerator.Models;

namespace TokenGenerator.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<TokenData> AuthenticateInteractiveAsync(string loginHint = null, string tenantId = null)
        {
            var credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialOptions
                {
                    TenantId = tenantId,
                    LoginHint = loginHint,
                    TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
                }
            );


            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var token = await credential.GetTokenAsync(
                new TokenRequestContext(new[] { "https://ossrdbms-aad.database.windows.net/.default" }),
                cts.Token
            );
            return new TokenData(token.Token, token.ExpiresOn);

        }


    }
}

