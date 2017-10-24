using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var connectionString = "Server=localhost;Database=AdventureWorks;Uid=root;Pwd=2344;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new SimpleDB(connectionString);
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name + "ModifiedDate: " + prod.ModifiedDate.DayOfWeek);
            }

            repo.DeleteProduct(3);
            Console.WriteLine("Should have product 3 deleted now");

            var product = new Product()
            {
                ProductId = 316,
                Name = "Something totally different"
            };

            repo.UpdateProduct(product);
            Console.WriteLine("Should have updated 316");

            var productB = new Product()
            {
                Name = "Large Ball Bearings",
                ProductNumber = "BMS-1234",
                ListPrice = 8000,
                MakeFlag = true,
                FinishedGoodsFlag = false,
                Color = null,
                SafetyStockLevel = 600,
                ReorderPoint = 250,
                DaysToManufacture = 0,
                StandardCost =  150,
                ModifiedDate = DateTime.UtcNow,
                SellStartDate =DateTime.UtcNow
            };
           
          
            repo.InsertProduct(productB);

            Console.ReadLine();
        }

       
    }
}
