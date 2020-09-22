using System.Threading.Tasks;
using Hydra.IdentityServer.Models.Account;

namespace Hydra.IdentityServer.Helpers
{
    public interface IJwtTokenGenerator
    {
        Task<UserResponseLogin> GenerateToken(string email);
    }
}