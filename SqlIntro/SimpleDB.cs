using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class SimpleDB
    {
        private readonly string _connectionString;

        public SimpleDB(string connectionString)
        {
            _connectionString = connectionString;
        }
       
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("Select * from Product");
            }
        }

       
        public void DeleteProduct(int productId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Delete from Product Where ProductId = @id", new { id = productId });
            }
        }
       
        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Update Product Set Name = @Name Where ProductId = @id", new { id = prod.ProductId, name = prod.Name});
            }

        }
        
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Insert into Product  (Name) values (@Name)", new { name = prod.Name });
            }

            

        }
     }
}
