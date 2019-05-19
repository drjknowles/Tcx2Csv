using System;

namespace Tcx2Csv
{
    using System.IO;
    using System.Xml.Linq;

    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 1 && args[0].ToLower().EndsWith(".tcx") &&  File.Exists(args[0]))
            {
                var fileIo = new FileIO();
                var tcx = fileIo.ReadXDocumentFromFile(args[0]);
                var converter = new Tcx2CsvConverter();
                var output = converter.ConvertTcx2Csv(tcx);
                fileIo.SaveTextToFile(output, args[0].Substring(0, args[0].Length - 4) + ".csv");

                return 0;
            }
            else
            {
                Console.WriteLine("Usage: Enter the filename of the tcx file to be converted and a csv file will be created using the same filename. If you have entered a filename it may not exist.");
                return -1;
            }


        }

        
    }
}
