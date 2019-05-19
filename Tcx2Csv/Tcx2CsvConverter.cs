using System;
using System.Collections.Generic;
using System.Text;

namespace Tcx2Csv
{
    using System.Linq;
    using System.Xml.Linq;

    internal class Tcx2CsvConverter
    {
        internal string ConvertTcx2Csv(XDocument tcxDocument)
        {
            var csvFile = new StringBuilder();

            var xmlNamespace = tcxDocument.Root.GetDefaultNamespace();

            var trackPoints = tcxDocument.Root.Descendants(xmlNamespace + "Trackpoint").ToList();

            csvFile.AppendLine("Time,Latitude,Longitude,Altitude,Distance,HeartRate");

            foreach (var trackPoint in trackPoints)
            {
                string time = trackPoint.Element(xmlNamespace + "Time").Value;
                string latitude = trackPoint.Element(xmlNamespace + "Position").Element(xmlNamespace + "LatitudeDegrees").Value;
                string longitude = trackPoint.Element(xmlNamespace + "Position").Element(xmlNamespace + "LongitudeDegrees").Value;
                string altitude = trackPoint.Element(xmlNamespace + "AltitudeMeters").Value;
                string distance = trackPoint.Element(xmlNamespace + "DistanceMeters").Value;
                string heartRate = trackPoint.Element(xmlNamespace + "HeartRateBpm").Element(xmlNamespace + "Value").Value;

                csvFile.AppendLine($"{time},{latitude},{longitude},{altitude},{distance},{heartRate}");
            }

            return csvFile.ToString();
        }
    }
}
