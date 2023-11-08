using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Form path to data folder

            string pathToProgramDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int length = pathToProgramDirectory.IndexOf("RestorantApp");
            pathToProgramDirectory = pathToProgramDirectory.Substring(0, length);
            string pathToDataDirectory = Path.Combine(pathToProgramDirectory, "Data");

            #endregion 


            #region Get tables
            //https://www.geeksforgeeks.org/c-sharp-check-if-a-hashset-contains-the-specified-element/
            HashSet<int> tablesNoSet;
            List<Table> tables = GetTables.GetTablesFromDataFile(pathToDataDirectory, out tablesNoSet);

            #endregion


            #region Get products menu

            HashSet<int> productsNoSet;
            List<Product> products = GetMenu.GetProductsFromDataFile(pathToDataDirectory, out productsNoSet);

            #endregion

            int userSelection = DisplayUserMenu.GetUserSelection();
            int selectedTableNo;
            List<Product> orderedProducts = new List<Product>();
            switch (userSelection)
            {
                case 1:
                    //ref is used for the clearity that list data can be changed inside this method
                    selectedTableNo = SelectTable.FromAll(tablesNoSet, ref tables);
                    bool isOrderReadyToPrint;
                    decimal totalAmount = 0;
                    do
                    {
                        isOrderReadyToPrint = false;
                        SelectProducts.FromAll(selectedTableNo, productsNoSet, products, ref orderedProducts);
                        isOrderReadyToPrint = DisplayTableOrder.CheckIsOrderReadyToPrint(selectedTableNo, orderedProducts,
                            ref totalAmount);
                    } while (!isOrderReadyToPrint);
                    //http://www.java2s.com/Tutorials/CSharp/Custom_Types/Interface/How_to_implement_an_interface_in_C_.htm
                    IPrintable thisTableOrder = new Order(selectedTableNo, orderedProducts, totalAmount);
                    thisTableOrder.Print();
                    bool isTableFree;
                    do
                    {
                        isTableFree = false;
                        isTableFree = SelectTable.FreeServedTableAfterBill(selectedTableNo, ref tables);
                    } while (!isTableFree);


                    break;
                case 2:
                    //Do nothing - the case for Quit the program
                    break;
                //case 3:

                //    break;
                //case 4:

                //    break;
                //case 5:

                    break;
                default:
                    string errorMessage = "Entered in the menu value  - " + "\n" +
                        userSelection + "\n" +
                        "is not included in the possible selections." + "\n" +
                        @"Without correct data from console the program isn't able correctly form reports. 
Program will stop.
Restart the program, if you need, and then enter correct value.";

                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                    break;

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The end of POS application.");
            Console.WriteLine("Press any key to exit the console window.");
            
            
            Console.ReadKey();
        }
    }
}
