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
        private readonly IAuthSettingsProvider _settingsProvider;

        public AuthenticationService(IAuthSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public async Task<TokenData> AuthenticateInteractiveAsync()
        {
            var settings = _settingsProvider.Get();

            var credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialOptions
                {
                    LoginHint = settings.UserEmail,
                    TenantId = settings.TenantId,
                    TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
                });

            var token = await credential.GetTokenAsync(
                new TokenRequestContext(new[]
                {
                "https://ossrdbms-aad.database.windows.net/.default"
                }));

            return new TokenData(token.Token, token.ExpiresOn);

        }


    }
}

