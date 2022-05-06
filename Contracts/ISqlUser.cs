using Ecomm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface ISqlUser
    {
        Task<bool> AddUser(User model);
        Task<User> GetUserByEmail(string email, string password);
        Task<List<Product>> GetAllProducts();
        Task<List<LatestNew>> GetAllLatestNews();
    }
}
