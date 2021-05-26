using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using ReadWriteKeyValut.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadWriteKeyValut.Implements
{
    internal sealed class KeyVaultClientWrapper : IKeyVaultClientWrapper
    {
        private readonly IKeyVaultAuthenticator _keyVaultAuthenticator;

        public KeyVaultClientWrapper(IKeyVaultAuthenticator keyVaultAuthenticator)
        {
            _keyVaultAuthenticator = keyVaultAuthenticator;
        }

        public async Task<SecretBundle> GetSecretAsync(string vaultBaseUrl, string secretName,
            CancellationToken cancellationToken = default)
        {
            using var client = GetVaultClient();
            return await client.GetSecretAsync(vaultBaseUrl, secretName, cancellationToken);
        }

        public IKeyVaultClient GetVaultClient() => new KeyVaultClient(_keyVaultAuthenticator.GetToken);
    }
}
