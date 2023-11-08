using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class SelectProducts
    {
        public static void FromAll(int selectedTableNo, HashSet<int> productsNoSet, List<Product> products, ref List<Product> orderedProducts)
        {
            Console.Clear();
            Console.WriteLine("POS - order products");
            Console.WriteLine();
            Console.WriteLine($"The table is served No {selectedTableNo}");
            Console.WriteLine();
            Console.WriteLine(@"Please enter a product number 
from the list below and
then press[Enter] key.");
            Console.WriteLine();

            int orderedProductNo;
            Console.WriteLine("Product  Product      Product      Product");
            Console.WriteLine("No       name         type         price");
            //https://www.codeproject.com/Questions/455766/Euro-symbol-does-not-show-up-in-Console-WriteLine
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (Product product in products)
            {
                //https://code-maze.com/csharp-using-variables-inside-strings/
                Console.WriteLine($"{product.No}        {product.Name}     {product.Type}      {product.Price} €");
            }

            List<int> selectedProductsNo = new List<int>();
            if (orderedProducts.Count > 0)
            {
                foreach (Product product in orderedProducts)
                {
                    selectedProductsNo.Add(product.No);
                }
                //empty list before update
                orderedProducts = new List<Product>();
            }
            string input = "";
            do
            {
                if (selectedProductsNo.Count > 0)
                {
                    //https://stackoverflow.com/questions/4981390/convert-a-list-to-a-string-in-c-sharp
                    string combinedString = string.Join(",", selectedProductsNo.ToArray());
                    Console.WriteLine();
                    Console.WriteLine($"Already ordered products numbers: {combinedString}");
                    Console.WriteLine("Please enter another product number");

                }
                int selectedProductNo;
                bool isEnteredDataCorrect;
                do
                {
                    isEnteredDataCorrect = true;
                    string userSelectionString = Console.ReadLine();

                    if (!Int32.TryParse(userSelectionString, out selectedProductNo))
                    {
                        isEnteredDataCorrect = false;
                        string errorMessage = "Entered in menu value  - " + userSelectionString + "\n" +
                            "cannot be converted to integer number." + "\n" +
                            @"Without correct data from console the program isn't able correctly form reports. 
Please enter corrrect option value.";
                        DisplayErrorMessage.InConsoleAndWait(errorMessage);
                    }
                    //https://www.geeksforgeeks.org/c-sharp-check-if-a-hashset-contains-the-specified-element/
                    if (isEnteredDataCorrect && !productsNoSet.Contains(selectedProductNo))
                    {
                        isEnteredDataCorrect = false;
                        string errorMessage = "Entered in the menu value  - " + "\n" +
                            userSelectionString + "\n" +
                            "is not included in the possible selections." + "\n" +
                            @"Without correct data from console the program isn't able correctly form reports. 
Please enter corrrect option value.";
                        DisplayErrorMessage.InConsoleAndWait(errorMessage);
                    }

                } while (!isEnteredDataCorrect);

                selectedProductsNo.Add(selectedProductNo);

                Console.WriteLine("Press 'c' to continue include products in order");
                Console.WriteLine("Press other key to finish order ");
                Console.WriteLine("Press Command:");
                input = Console.ReadLine();

            } while (input=="c");

            foreach (int no in selectedProductsNo)
            {
                int index = no - 1;
                orderedProducts.Add(products[index]);
            }
        }
    }
}
