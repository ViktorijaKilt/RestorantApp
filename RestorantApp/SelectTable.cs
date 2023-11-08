using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class SelectTable
    {
        public static int FromAll(HashSet<int> tablesNoSet, ref List<Table> tables)
        {
            Console.Clear();
            Console.WriteLine("POS - a table selection");
            Console.WriteLine();
            Console.WriteLine(@"Please enter a free table number 
from the list below and
then press[Enter] key.");
            Console.WriteLine();
            Console.WriteLine("Table  Table");
            Console.WriteLine("No     status");
            foreach (Table table in tables)
            {
                //https://josipmisko.com/posts/c-sharp-one-line-if-else
                string status = table.IsTableFree ? status = "Free" : status = "Busy";
                Console.WriteLine($"{table.No}      {status}");
            }

            int selectedTableNo;
            bool isEnteredDataCorrect;
            do
            {
                isEnteredDataCorrect = true;
                string userSelectionString = Console.ReadLine();

                if (!Int32.TryParse(userSelectionString, out selectedTableNo))
                {
                    isEnteredDataCorrect = false;
                    string errorMessage = "Entered in menu value  - " + userSelectionString + "\n" +
                        "cannot be converted to integer number." + "\n" +
                        @"Without correct data from console the program isn't able correctly form reports. 
Please enter corrrect option value.";
                    DisplayErrorMessage.InConsoleAndWait(errorMessage);
                }
                //https://www.geeksforgeeks.org/c-sharp-check-if-a-hashset-contains-the-specified-element/
                if (isEnteredDataCorrect && !tablesNoSet.Contains(selectedTableNo))
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

            //Use for because in foreach impossible to change element value
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].No == selectedTableNo)
                {
                    tables[i].IsTableFree = false;
                    break;
                }
            }

            return selectedTableNo;
        }
        public static bool FreeServedTableAfterBill(int tableNo, ref List<Table> tables)
        {
            bool isTableFree = false;

            Console.Clear();
            Console.WriteLine("POS - Free this served table after bill");
            Console.WriteLine();
            Console.WriteLine($"The table is served No {tableNo}");
            Console.WriteLine();

            Console.WriteLine();
            string input = "";
            Console.WriteLine("Press 'f' to free served table");
            Console.WriteLine("Press other key to postpone this action.");
            Console.WriteLine("Press Command:");
            input = Console.ReadLine();

            if (input == "f")
            {
                isTableFree = true;
                //Use for because in foreach impossible to change element value
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].No == tableNo)
                    {
                        tables[i].IsTableFree = true;
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Table  Table");
                Console.WriteLine("No     status");
                foreach (Table table in tables)
                {
                    //https://josipmisko.com/posts/c-sharp-one-line-if-else
                    string status = table.IsTableFree ? status = "Free" : status = "Busy";
                    Console.WriteLine($"{table.No}      {status}");
                }
                input = "";
                do
                {
                    Console.WriteLine("Press 'c' to continue ");
                    Console.WriteLine("Press other key to postpone this action.");
                    Console.WriteLine("Press Command:");
                    input = Console.ReadLine();
                } while (input != "c");

            }
            return isTableFree;
        }
    }

}
