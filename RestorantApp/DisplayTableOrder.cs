using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class DisplayTableOrder
    {
        public static bool CheckIsOrderReadyToPrint(int tableNo, List<Product> orderedProducts, ref decimal totalamount)
        {
            bool isOrderReadyToPrint = false;
            totalamount = 0;

            Console.Clear();
            Console.WriteLine("POS - Check ordered products");
            Console.WriteLine();
            Console.WriteLine($"The table is served No {tableNo}");
            Console.WriteLine();

            Console.WriteLine("Product  Product      Product      Product");
            Console.WriteLine("No       name         type         price");
            //https://www.codeproject.com/Questions/455766/Euro-symbol-does-not-show-up-in-Console-WriteLine
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (Product product in orderedProducts)
            {
                //https://code-maze.com/csharp-using-variables-inside-strings/
                Console.WriteLine($"{product.No}        {product.Name}     {product.Type}      {product.Price} €");
                totalamount += product.Price;
            }

            Console.WriteLine();
            Console.WriteLine($"Total order amount - {totalamount}");
            Console.WriteLine(("").PadRight(35, '-'));
            Console.WriteLine();
            string input = "";
            Console.WriteLine("Press 'p' to print bill for this order");
            Console.WriteLine("Press other key to include more products into order ");
            Console.WriteLine("Press Command:");
            input = Console.ReadLine();

            if (input == "p") isOrderReadyToPrint = true;

            return isOrderReadyToPrint;
        }
    }
}
