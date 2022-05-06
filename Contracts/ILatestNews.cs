using Ecomm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{
    public interface ILatestNews
    {
        Task<List<LatestNew>> GetAllLatestNews();
    }
}
