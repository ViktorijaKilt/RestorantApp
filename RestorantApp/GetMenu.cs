using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class GetMenu
    {
        public static List<Product> GetProductsFromDataFile(string pathToDataDirectory, out HashSet<int> productsNoSet)
        {
            List<Product> products = new List<Product>();
            productsNoSet = new HashSet<int>();

            string pathToMenuDataFile = Path.Combine(pathToDataDirectory, "Menu.txt");
            List<string[]> datafromTxtFile = Read.LoadDataFromTxtFile(pathToMenuDataFile);
            int rowNo = 1;
            foreach (string[] dataRow in datafromTxtFile)
            {
                string productNoString = dataRow[0];
                if (productNoString == string.Empty)
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product number string - " + productNoString + "\n" +
                        "which cannot be empty." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                int productNo;
                if (!Int32.TryParse(productNoString, out productNo))
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product number string - " + productNoString + "\n" +
                        "which cannot be converted to integer number." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                productsNoSet.Add(productNo);
                string productName = dataRow[1];
                if (productName == string.Empty)
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product name string - " + productName + "\n" +
                        "which cannot be empty." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                string productType = dataRow[2];
                if (productType == string.Empty)
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product type string - " + productType + "\n" +
                        "which cannot be empty." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                string productPriceString = dataRow[3];
                if (productPriceString == string.Empty)
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product price string - " + productPriceString + "\n" +
                        "which cannot be empty." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                decimal productPrice;
                if (!Decimal.TryParse(productPriceString, out productPrice))
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToMenuDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is product price string - " + productPriceString + "\n" +
                        "which cannot be converted to decimal value." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                Product product = new Product(productNo, productName, productType, productPrice);
                products.Add(product);
                rowNo++;
            }
            return products;
        }
    }
}
