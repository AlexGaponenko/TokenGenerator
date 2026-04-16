using System.Threading.Tasks;
using TokenGenerator.Domain.Models;

namespace TokenGenerator.Domain.Interfaces
{

    public interface IAuthenticationService
    {
        Task<TokenData> AuthenticateInteractiveAsync();
    }

}
