using DTC.Utilities;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace DTC.New.UI.Base.Systems.WaypointImport.Types;

public class CombatFliteXML
{
    public static ImportRoute[]? Import()
    {
        var path = DTCOpenFileDialog.Open(new Tuple<string, string>[]
            {
                new("CombatFlite XML Export files", "*.xml")
            });

        if (path == null) return null;

        const string invalidFile = "The file is not a valid CombatFlite XML Export file.";

        var content = File.ReadAllText(path);

        XDocument xmlDoc;
        try
        {
            xmlDoc = XDocument.Parse(content);
        }
        catch (XmlException)
        {
            DTCMessageBox.ShowError(invalidFile);
            return null;
        }

        var routes = xmlDoc.Descendants(XName.Get("Waypoints"));
        if (routes == null || routes.Count() == 0)
        {
            DTCMessageBox.ShowError("The CombatFlite XML Export file has no routes.");
            return null;
        }

        ImportRoute[] cfRoutes;

        try
        {
            cfRoutes = routes.Select((r, routeIndex) => new ImportRoute
            {
                Name = "Route " + routeIndex++,
                Aircraft = "Unknown",
                Waypoints = r.Descendants(XName.Get("Waypoint")).Select((w, index) => new ImportWaypoint
                {
                    Sequence = index + 1,
                    Name = w.Descendants(XName.Get("Name")).First().Value,
                    Coordinate = Coordinate.FromDCS(
                        w.Descendants(XName.Get("Position")).First().Descendants(XName.Get("Latitude")).First().Value,
                        w.Descendants(XName.Get("Position")).First().Descendants(XName.Get("Longitude")).First().Value),
                    Elevation = (int)decimal.Parse(w.Descendants(XName.Get("Position")).First().Descendants(XName.Get("Altitude")).First().Value, CultureInfo.InvariantCulture),
                    TimeOverSteerpoint = "00:00:00"
                }).ToArray()
            }).ToArray();
        }
        catch (XmlException)
        {
            DTCMessageBox.ShowError("The CombatFlite XML Export file is not valid.");
            return null;
        }

        Array.Sort(cfRoutes, (a, b) => a.Name.CompareTo(b.Name));

        return cfRoutes;
    }
}
