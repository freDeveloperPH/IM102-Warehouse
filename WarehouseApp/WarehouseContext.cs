using System;
using System.Collections.Generic;
using MySqlConnector;
using WarehouseApp.Models;

namespace WarehouseApp
{
    public class WarehouseAppContext
    {
        public string ConnectionString { get; set; }
        public WarehouseAppContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Get all Product
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Product;", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        });
                    }
                }
            }
            return list;
        }
    }
}