using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();

        public void InsertProduct(string newProductName, double newPrice, int newCategoryID, bool newOnSale, int newStockLevel);


    }
}
