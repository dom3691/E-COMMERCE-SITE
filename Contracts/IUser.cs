using Ecomm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface IUser
    {
        Task<bool> CreateCustomer(User user);
        Task<User> GetCustomerByEmail(string email, string password);
        
    }
}
