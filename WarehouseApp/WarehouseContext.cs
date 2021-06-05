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

#region Product
        // Get all Product
        public List<Product> GetAllProducts()
        {
            List<Product> lstProduct = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {             
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Product;", conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.Name = rdr["Name"].ToString();
                    product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    
                    lstProduct.Add(product);
                }
                conn.Close();
            }
            return lstProduct;
        }

         //Add Product
         public void CreateProduct(Product product)
         {
             using(MySqlConnection conn = GetConnection())
             {
                 MySqlCommand cmd = new MySqlCommand("INSERT INTO Product(Name, Quantity) VALUES (@Name, @Quantity)", conn);

                 cmd.Parameters.AddWithValue("@Name", product.Name);
                 cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

                 conn.Open();
                 cmd.ExecuteNonQuery();
                 conn.Close();
             }
         }

         //Edit/ Update Product
         public void UpdateProduct(Product product)
         {
             using(MySqlConnection conn = GetConnection())
             {
                 MySqlCommand cmd = new MySqlCommand("UPDATE Product SET Name = @Name, Quantity = @Quantity WHERE Id = @Id", conn);

                 cmd.Parameters.AddWithValue("@Id", product.Id);
                 cmd.Parameters.AddWithValue("@Name", product.Name);
                 cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

                 conn.Open();
                 cmd.ExecuteNonQuery();
                 conn.Close();
             }
         }

         //Get the details of a particular Product
        public Product GetProduct(int? id)
        {
            Product product = new Product();

            using (MySqlConnection conn = GetConnection())
            {             
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Product WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.Name = rdr["Name"].ToString();
                    product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                }
                conn.Close();
            }
            return product;
        }

        //Delete the record on particular Product
        public void DeleteProduct(int? id)
        {
             using (MySqlConnection conn = GetConnection())
            {             
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Product WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }   
        }
    }
#endregion
}