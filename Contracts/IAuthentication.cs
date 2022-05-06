using Ecomm.Models;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface IAuthentication
    {
        Task<User> Login(string username, string password); 
    }
}
