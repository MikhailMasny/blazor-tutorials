using Masny.Blazor.ClientSide.Models;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Interfaces
{
    public interface IAuthenticationService
    {
        User User { get; }

        Task Initialize();

        Task Login(string username, string password);

        Task Logout();
    }
}
