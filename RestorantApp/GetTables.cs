using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class GetTables
    {
        public static List<Table> GetTablesFromDataFile(string pathToDataDirectory, out HashSet<int> tablesNoSet)
        {
            List<Table> tables = new List<Table>();
            tablesNoSet = new HashSet<int>();

            string pathToTablesDataFile = Path.Combine(pathToDataDirectory, "Tables.txt");
            List<string[]> datafromTxtFile = Read.LoadDataFromTxtFile(pathToTablesDataFile);

            int rowNo = 1;
            foreach (string[] dataRow in datafromTxtFile)
            {
                
                if (dataRow[0] == string.Empty)
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToTablesDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is table number string - " + dataRow[0] + "\n" +
                        "which cannot be empty." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }

                int tableNo;
                if (!Int32.TryParse(dataRow[0], out tableNo))
                {
                    string errorMessage = "In the file - " + "\n" +
                        pathToTablesDataFile + "\n" +
                        "row - " + rowNo + "\n" +
                        "is table number string - " + dataRow[0] + "\n" +
                        "which cannot be converted to integer number." + "\n" +
                        @"Without correct data from this file the program isn't able correctly form reports. 
Program will stop.
Corrrect data in the mentioned file and 
then restart the program.";
                    DisplayErrorMessage.InConsoleAndExit(errorMessage);
                }
                Table table = new Table();
                table.No = tableNo;
                tablesNoSet.Add(table.No);
                table.IsTableFree = true;
                tables.Add(table);
                rowNo++;
            }
            return tables;
        }
    }
}
