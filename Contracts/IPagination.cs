using Ecomm.Models;
using System.Collections.Generic;

namespace Ecomm.Contracts
{
    public interface IPagination
    {
        int PageCount(List<Product> products);
        IEnumerable<Product> Paginate(List<Product> products);
    }
}
