using System;
using System.Data;
using System.Data.SqlClient;
using Ecomm.Contracts;
using Microsoft.Extensions.Configuration;

namespace Ecomm.Utilities
{
    public class DbConnection 
    {
        private SqlConnection con;
        private IConfiguration _configuration;
        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection ConnectObj
        {
            get
            {
                if (con == null)
                {
                    string connString = _configuration.GetConnectionString("DefaultConnection");
                    con = new SqlConnection(connString);
                }
                return con;
            }
        }
    }
}
