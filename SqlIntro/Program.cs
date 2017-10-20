using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var connectionString = "Server=localhost;Database=AdventureWorks;Uid=root;Pwd=2344;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts().Take(1))
            {
                Console.WriteLine("Product Name:" + prod.Name + "Product List Price:" + prod.ListPrice);
            }

           
            Console.ReadLine();
        }

       
    }
}
