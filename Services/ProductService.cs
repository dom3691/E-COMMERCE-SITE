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
    public class ProductService : IProductService
    {
        private readonly ICommandHandler _connection;
        private readonly DbConnection _connectionob;

        public ProductService(ICommandHandler connection, DbConnection connectionob)
        {
            _connection = connection;
            _connectionob = connectionob;
        }
        public async Task<Product> GetProductById(int id)
        {
            SqlDataReader reader = await _connection.SelectARecordFromDB("spGetProductById", "@id", id.ToString());
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
    }
}
