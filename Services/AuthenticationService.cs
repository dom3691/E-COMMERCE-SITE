using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Services
{
    internal class AuthenticationService : IAuthentication
    {
        private readonly ICommandHandler _connection;
        private readonly DbConnection _connectionob;

        public AuthenticationService(ICommandHandler connection, DbConnection connectionob)
        {
            _connection = connection;
            _connectionob = connectionob;
        }
        public async Task<User> Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                SqlDataReader reader = await _connection.SelectAllFromDB("spGetAllUsers");
                try
                {
                    List<User> users = new();
                    User user = null;
                    while (reader.Read())
                    {
                        user = new()
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            FullName = reader["Fullname"].ToString(),
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                        users.Add(user);
                    }
                    user = users.FirstOrDefault(x => x.Email == email && x.Password == password);
                    return user;
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
            return null;
        }
            
    }
}

