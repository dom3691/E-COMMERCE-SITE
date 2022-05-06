using Ecomm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface IUserService
    {
        Task<bool> AddUser(User model);
        Task<List<User>> GetAllUsers();


    }
}
