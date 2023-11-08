using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class DisplayErrorMessage
    {
        public static void InConsoleAndExit(string errorMessage)
        {
            Console.WriteLine();
            Console.WriteLine("Error:");
            Console.WriteLine(errorMessage);
            Console.WriteLine();
            Console.WriteLine("Press any key to stop the program.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void InConsoleAndWait(string errorMessage)
        {
            Console.WriteLine();
            Console.WriteLine(errorMessage);
            Console.WriteLine();
            
        }

    }
}
