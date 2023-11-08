using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class DisplayUserMenu
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
        public static int GetUserSelection()
        {
            //https://www.techiedelight.com/initialize-a-hashset-in-csharp/
            //https://stackoverflow.com/questions/14882287/using-hashsetint-to-create-an-integer-set
            //HashSet<int> possibleSelections = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> possibleSelections = new HashSet<int> { 1, 2};

            Console.Clear();
            Console.WriteLine(
                @"WELCOME TO POS

Please enter an option integer number and
then press [Enter] key.

1. Select a table
2. Quit"       );
            /*
             * 2. Select products
3. Print bill
4. Free busy table
            5. Quit
             * */
            int userSelection;
            bool isEnteredDataCorrect;
            do
            {
                isEnteredDataCorrect = true;
                string userSelectionString = Console.ReadLine();
                
                if (!Int32.TryParse(userSelectionString, out userSelection))
                {
                    isEnteredDataCorrect = false;
                    string errorMessage = "Entered in menu value  - " + userSelectionString + "\n" +
                        "cannot be converted to integer number." + "\n" +
                        @"Without correct data from console the program isn't able correctly form reports. 
Please enter corrrect option value.";
                    DisplayErrorMessage.InConsoleAndWait(errorMessage);
                }
                if (isEnteredDataCorrect && !possibleSelections.Contains(userSelection))
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

            return userSelection;
        }

    }
}
