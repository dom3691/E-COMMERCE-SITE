using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ecomm.Services
{
    public class LatestNewsService : ILatestNews
    {

        private readonly ICommandHandler _connection;
        private readonly DbConnection _connectionob;

        public LatestNewsService(ICommandHandler connection, DbConnection connectionob)
        {
            _connection = connection;
            _connectionob = connectionob;
        }
        public async Task<List<LatestNew>> GetAllLatestNews()
        {
            SqlDataReader reader = await _connection.SelectAllFromDB("spGetAllLatestNews");
            try
            {
                List<LatestNew> latestNews = new();

                while (reader.Read())
                {
                    LatestNew news = new()
                    {

                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Body = reader["Body"].ToString(),
                        NewsImage = reader["NewsImage"].ToString(),
                        Date = reader["Date"].ToString()

                    };

                    latestNews.Add(news);
                }

                return latestNews;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (_connectionob.ConnectObj.State == ConnectionState.Open)
                {
                    _connectionob.ConnectObj.Close();
                }

            }
        }
    }
}
