using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _Connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _Connection.Query<Product>("Select * from  products");
        }
        public Product GetProduct(int id)
        {
            return _Connection.QuerySingle<Product>
                ("select * from products" +
                " where ProductId = @id; ",
          new { id = id });

        }

        public void UpdateProduct(Product product)
        {
            _Connection.Execute("Update product set" +
                " Name = @Name,price = @Price, OnSale = @OnSale," +
                " CategoryID = @CategoryID, stockLevel = @stock," +
                "Where ProductId = @id;",


            new { name = product.Name, price = product.price,
                CategoryID = product.CategoryId, OnSale = product.OnSale,
                stock = product.stockLevel,
            });
            
        }

        public void DeleteProduct(int id)
        {
            _Connection.Execute("Delete * from sales Where ProductId = @id", new { id = id });
            _Connection.Execute("Delete * from reviews Where ProductId = @id", new { id = id });
            _Connection.Execute("Delete * from products Where ProductId = @id", new { id = id });
        }
    }
}
