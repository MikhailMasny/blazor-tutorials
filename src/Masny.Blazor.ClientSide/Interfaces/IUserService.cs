using Masny.Blazor.ClientSide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}
