using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ecomm.Contracts
{    public interface ICommandHandler
    {
        Task<bool> InsertToDB(string procedure, SqlParameter[] parameters);
        Task<SqlDataReader> SelectAllFromDB(string procedure);
        Task<SqlDataReader> SelectARecordFromDB(string procedure, string parameterName1, string detail1);
        Task<bool> UpdateToDB(string procedure, string accNum, decimal balance);
    }
    
}
