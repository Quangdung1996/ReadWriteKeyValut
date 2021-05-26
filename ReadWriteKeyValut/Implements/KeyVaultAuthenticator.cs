using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ReadWriteKeyValut.Configs;
using ReadWriteKeyValut.Interfaces;
using System.Threading.Tasks;

namespace ReadWriteKeyValut.Implements
{
    internal sealed class KeyVaultAuthenticator : IKeyVaultAuthenticator
    {
        private readonly KeyVaultConfig _settings;

        public KeyVaultAuthenticator(IOptions<KeyVaultConfig> options)
        {
            _settings = options.Value;
        }

        public async Task<string> GetToken(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var adCredential = new ClientCredential(_settings.ClientId, _settings.ClientSecret);
            var result = await context.AcquireTokenAsync(resource, adCredential);

            return result.AccessToken;
        }
    }
}
