using System.Data.SqlClient;

namespace Ecomm.Contracts
{
    public interface IDbConnectionn
    {
        SqlConnection ConnectObj { get; }
        void Dispose();

    }
}
