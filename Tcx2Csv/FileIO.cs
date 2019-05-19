using System;
using System.Collections.Generic;
using System.Text;

namespace Tcx2Csv
{
    using System.IO;
    using System.Xml.Linq;

    internal class FileIO
    {
        internal XDocument ReadXDocumentFromFile(string fileName)
        {
            return XDocument.Load(fileName);
        }

        internal void SaveTextToFile(string textToSave, string fileName)
        {
            File.WriteAllText(fileName, textToSave);
        }
    }
}
