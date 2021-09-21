using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    class DapperProductsRepository : IProductsRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }

        public void InsertProduct(string newProductName, double newPrice, int newCategoryID, bool newOnSale, int newStockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@productName, @price, @categoryID, @onSale, @stockLevel);",
            new { productName = newProductName, price = newPrice, categoryID = newCategoryID, onSale = newOnSale, stockLevel = newStockLevel  });
        }

    }
}
