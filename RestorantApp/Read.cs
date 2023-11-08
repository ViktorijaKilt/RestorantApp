using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public static class Read
    {
        public static List<string[]> LoadDataFromTxtFile(string pathToDataFile)
        {
            CheckIsDataFileExist(pathToDataFile);
            List<string[]> datafromTxtFile = new List<string[]>();
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(pathToDataFile))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        string[] columnsTextArray = line.Split('\t');
                        datafromTxtFile.Add(columnsTextArray);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage.InConsoleAndExit(ex.Message);
            }
           
            return datafromTxtFile;
        }

        public static void CheckIsDataFileExist(string pathToDataFile)
        {
            if (!File.Exists(pathToDataFile))
            {
                string errorMessage = "File - " + "\n" +
                        pathToDataFile + "\n" +
                        "can't be found. " + "\n" +
                        @"Without data from this file the program isn't able correctly form reports. 
Program will stop.
Place the required file in the correct folder and 
then restart the program.";
                DisplayErrorMessage.InConsoleAndExit(errorMessage);
            }
        }

    }
}
