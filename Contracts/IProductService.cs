using Ecomm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
    }
}
