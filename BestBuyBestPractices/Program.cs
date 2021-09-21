using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentsRepository(conn);
            var reno = new DapperProductsRepository(conn);

            Console.WriteLine("Type a new department name.");
            var newDepartment = Console.ReadLine();
            //Get product traits -- Name, price, category ID, on sale, stock level
            Console.WriteLine("Type a new product name.");
            var newProductName = Console.ReadLine();
            Console.WriteLine("Type the new product's price.");
            double newPrice = double.Parse(Console.ReadLine());
            int newCategoryID = 0;
            do
            {
                Console.WriteLine("What is the new product's numerical category ID?");
                Console.WriteLine("1 - Computers    // 2 - Appliances");
                Console.WriteLine("3 - Phones       // 4 - Audio");
                Console.WriteLine("5 - Home Theater // 6 - Printers");
                Console.WriteLine("7 - Music        // 8 - Games");
                Console.WriteLine("9 - Services     // 10 - Other");

                int.TryParse(Console.ReadLine(), out newCategoryID);
                if (newCategoryID < 1 || newCategoryID > 10)
                {
                    Console.WriteLine("Invalid category ID.");
                    Console.WriteLine();
                }
            } while (newCategoryID < 1 || newCategoryID > 10);
            string saleChecker;
            bool checker = true;
            bool newOnSale = false;
            do {
                Console.WriteLine("Is the product on Sale? Y/N");
                saleChecker = Console.ReadLine().ToLower();
                if (saleChecker == "y")
                {
                    newOnSale = true;
                    checker = false;
                }
                else if (saleChecker == "n")
                {
                    checker = false;
                }
                else
                {
                    Console.WriteLine("Not valid input.");
                }
            } while (checker);
            Console.WriteLine("What is the product's stock level?");
            int newStockLevel = int.Parse(Console.ReadLine());



            repo.InsertDepartment(newDepartment);
            reno.InsertProduct(newProductName, newPrice, newCategoryID, newOnSale, newStockLevel);

            Console.WriteLine("The departments are:");
            var departments = repo.GetAllDepartments();
            Console.ReadLine();

            Console.WriteLine("The products are:");
            var products = reno.GetAllProducts();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name} ~ {prod.Price} ~ {prod.CategoryID} ~ {prod.OnSale} ~ {prod.StockLevel}");
            }
        }
    }
}
