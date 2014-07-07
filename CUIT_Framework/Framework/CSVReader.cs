using System;
using System.IO;

namespace CUIT_Framework.Framework
{
    public class CSVReader
    {
        public static String ControlType;
        public static String LocatorType;
        public static String LocatorValue;
        public static void ReadDataFromCsv(String fileName, String element)
        {
            var data = new StreamReader(File.OpenRead(fileName));

            while (!data.EndOfStream)
            {
                var line = data.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');
                if (values[0].Equals(element))
                {
                    var elementsControl = values[1].Split('|');
                    ControlType = elementsControl[0];
                    LocatorType = elementsControl[1];
                    LocatorValue = elementsControl[2];
                    break;
                }    
            }
        }
    }
}
