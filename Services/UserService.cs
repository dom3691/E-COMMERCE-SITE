using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Services
{
    public class UserService : IUserService
    {

        private readonly ICommandHandler _connection;
        private readonly DbConnection _connectionob;
       
        public UserService(ICommandHandler connection, DbConnection connectionob)
        {
            _connection = connection;
            _connectionob = connectionob;
        }
        private static List<User> userDB = new List<User>();
        public async Task<bool> AddUser(User model)
        {
            model.FullName = model.FirstName + " " + model.LastName;
            SqlParameter[] parameter = {
                new SqlParameter("@FirstName", model.FirstName),
                new SqlParameter("@LastName", model.LastName),
                new SqlParameter("@FullName", model.FullName),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@Password", model.Password)
            };

            try
            {

                if (await _connection.InsertToDB("spCreateUser", parameter))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
        public async Task<List<User>> GetAllUsers()
        {
            SqlDataReader reader = await _connection.SelectAllFromDB("spGetAllUsers");
            try
            {
                List<User> users = new();

                while (reader.Read())
                {
                    User user = new()
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

                return users;
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
