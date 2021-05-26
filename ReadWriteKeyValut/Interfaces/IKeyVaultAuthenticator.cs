using System.Threading.Tasks;

namespace ReadWriteKeyValut.Interfaces
{
    public interface IKeyVaultAuthenticator
    {
        Task<string> GetToken(string authority, string resource, string scope);
    }
}