using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public class Order : IPrintable
    {
        private int tableNo { get; set; }

        private List<Product> orderedProducts { get; set; }

        private decimal totalAmount;

        public Order(int tableNo, List<Product> orderedProducts, decimal totalAmount)
        {
            //this - suggested by Visual Studio
            this.tableNo = tableNo;
            this.orderedProducts = orderedProducts;
            this.totalAmount = totalAmount;
        }


        //Public members doesn't required as publicly is used only print method

        ////https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
        //public int TableNo
        //{
        //    get => tableNo;
        //}
        //public List<Product> OrderedProducts
        //{
        //    get => orderedProducts;
        //}

        //public decimal TotalAmount
        //{
        //    get => totalAmount;
        //}


        public void Print()
        {
            
            //https://learn.microsoft.com/en-us/dotnet/api/system.console.writeline?view=net-7.0
            Console.Clear();
            Console.WriteLine();
            //https://stackoverflow.com/questions/15128766/write-boldface-text-using-console-writeline-c-or-printfn-f
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bill");
            Console.ResetColor(); // To return colors back
            Console.WriteLine($"Table number:\t{this.tableNo}");
            Console.WriteLine($"Bill total:\t{this.totalAmount} €");
            Console.WriteLine($"Bill printed:\t{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}");
            Console.WriteLine(("").PadRight(35, '-'));
            Console.WriteLine();
            Console.WriteLine("Product\tProduct\t\t\tProduct\t\t\tProduct");
            Console.WriteLine("No\tname\t\t\ttype\t\t\tprice");
            Console.WriteLine(("").PadRight(65, '-'));
            foreach (Product product in this.orderedProducts)
            {
                Console.WriteLine($"{product.No}\t{product.Name}\t\t{product.Type}\t\t{product.Price} €");
                
            }

            Console.WriteLine();
            string input = "";
            do
            {
                Console.WriteLine("Press 'c' to continue ");
                Console.WriteLine("Press other key to postpone this action.");
                Console.WriteLine("Press Command:");
                input = Console.ReadLine();
            } while (input != "c");

        }
    }
}
