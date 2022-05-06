
using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ecomm.DataLayer
{
    public class CustomerDL : ICommandHandler
    {
        private readonly DbConnection _dbConnection;
        public CustomerDL(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> InsertToDB(string procedure, SqlParameter[] parameters)
        {
            try
            {

                using (SqlConnection connection = _dbConnection.ConnectObj)
                {
                    SqlCommand cmd = new SqlCommand(procedure, connection)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    connection.Open();
                    foreach (SqlParameter item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    int result = await cmd.ExecuteNonQueryAsync();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<SqlDataReader> SelectAllFromDB(string procedure)
        {
            try
            {
                SqlConnection connection = _dbConnection.ConnectObj;

                SqlCommand cmd = new SqlCommand(procedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                return sdr;
            }
            catch (Exception)
            {
                throw;
            }
         }
        public async Task<SqlDataReader> SelectARecordFromDB(string procedure, string parameterName1, string detail1)
        {
            try
            {
                SqlConnection connection = _dbConnection.ConnectObj;
                SqlCommand cmd = new SqlCommand(procedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                if (int.TryParse(detail1, out int result))
                {
                    cmd.Parameters.AddWithValue(parameterName1, result);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parameterName1, detail1);
                }
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                return sdr;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateToDB(string procedure, string accNum, decimal balance)
        {
            try
            {
                using (SqlConnection connection = _dbConnection.ConnectObj)
                {
                    SqlCommand cmd = new SqlCommand(procedure, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open();
                    cmd.Parameters.AddWithValue("@a_accountNum", accNum);
                    cmd.Parameters.AddWithValue("@a_balance", balance);

                    int result = await cmd.ExecuteNonQueryAsync();
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
