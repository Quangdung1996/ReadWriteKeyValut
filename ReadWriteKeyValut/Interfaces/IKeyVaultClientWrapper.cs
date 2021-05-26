using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ReadWriteKeyValut.Interfaces
{
    public interface IKeyVaultClientWrapper
    {
        IKeyVaultClient GetVaultClient();

        Task<SecretBundle> GetSecretAsync(string vaultBaseUrl, string secretName, CancellationToken cancellationToken = default);
    }
}