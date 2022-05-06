using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Services
{
    public class SqldbConnect : ISqlUser
    {
        private readonly ICommandHandler _connection;
        private readonly DbConnection _connectionob;
        public SqldbConnect(ICommandHandler connection, DbConnection connectionob)
        {
            _connection = connection;
            _connectionob = connectionob;
        }
        public async Task<bool> AddUser(User model)
        {
            List<User> users;
            users = await GetAllUsers();
            model.FullName = model.FirstName + " " + model.LastName;
            SqlParameter[] parameter = {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@FirstName", model.FirstName),
                new SqlParameter("@LastName", model.LastName),
                new SqlParameter("@FullName", model.FullName),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@Password", model.Password)
                
            };
            
            try
            {
                
               if(await _connection.InsertToDB("spCreateUser", parameter))
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
                        Id = (int) reader["Id"],
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


        public async Task<User> GetUserByEmail(string email,string password)
        {
            SqlDataReader reader = await _connection.SelectAllFromDB("spGetUserByEmail");
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
        public async Task<Product> GetProductById(int id)
        {
            SqlDataReader reader = await _connection.SelectARecordFromDB("spGetProductById", "@id", "id");
            try
            {
                Product product = null;
                while (reader.Read())
                {
                     product = new()
                    {
                        Id = (int)reader["Id"],
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        ProductImage = reader["ProductImage"].ToString(),
                        UnitPrice = (decimal)reader["UnitPrice"],
                        Description = reader["Description"].ToString(),
                        Featured = (bool)reader["Featured"],
                        NumberOfSale = (int)reader["NumberOfSale"],
                        Ratings = (int)reader["Ratings"],
                        Brand = reader["Brand"].ToString(),
                        Color = reader["Color"].ToString(),
                        Size = reader["size"].ToString(),
                        PercentOff = (int)reader["PercentOff"],
                        DiscountedUnitPrice = (decimal)reader["DiscountedUnitPrice"],
                        Quantity = (int)reader["Quantity"],
                        Availability = (bool)reader["Availability"]
                    };
                }

                return product;
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

        public async Task<List<Product>> GetAllProducts()
        {
            SqlDataReader reader = await _connection.SelectAllFromDB("spGetAllProducts");
            try
            {
                List<Product> products = new();

                while (reader.Read())
                {
                    Product product = new()
                    {
                        Id= (int)reader["Id"],
                        CategoryId = (int) reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        ProductImage = reader["ProductImage"].ToString(),
                        UnitPrice = (decimal) reader["UnitPrice"],
                        Description = reader["Description"].ToString(),
                        Featured = (bool)reader["Featured"],
                        NumberOfSale = (int) reader["NumberOfSale"],
                        Ratings = (int)reader["Ratings"],
                        Brand = reader["Brand"].ToString(),
                        Color = reader["Color"].ToString(),
                        Size =  reader["size"].ToString(),
                        PercentOff = (int)reader["PercentOff"],
                        DiscountedUnitPrice = (decimal) reader["DiscountedUnitPrice"],
                        Quantity = (int) reader["Quantity"],
                        Availability = (bool) reader["Availability"]
                    };

                    products.Add(product);
                }

                return products;
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
