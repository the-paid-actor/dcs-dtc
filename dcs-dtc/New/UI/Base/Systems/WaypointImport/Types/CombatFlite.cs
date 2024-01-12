using DTC.Utilities;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DTC.New.UI.Base.Systems.WaypointImport.Types;

public class CombatFlite
{
    public static ImportRoute[]? Import()
    {
        var path = DTCOpenFileDialog.Open(new Tuple<string, string>[]
            {
            new("CombatFlite files", "*.cf")
            });

        if (path == null) return null;

        const string invalidFile = "The file is not a valid CombatFlite file.";

        ZipArchive? zipFile = null;

        try
        {
            zipFile = ZipFile.OpenRead(path);
        }
        catch (InvalidDataException)
        {
            DTCMessageBox.ShowError(invalidFile);
            return null;
        }
        catch (FileNotFoundException)
        {
            DTCMessageBox.ShowError("File was not found.");
            return null;
        }

        var entry = zipFile.Entries
            .Where(x => x.Name.Equals("mission.xml", StringComparison.InvariantCulture))
            .FirstOrDefault();
        if (entry == null)
        {
            DTCMessageBox.ShowError(invalidFile);
            return null;
        }

        var reader = new StreamReader(entry.Open(), Encoding.UTF8);
        var content = reader.ReadToEnd();
        reader.Close();

        zipFile.Dispose();

        if (string.IsNullOrEmpty(content))
        {
            DTCMessageBox.ShowError(invalidFile);
            return null;
        }

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

        var routes = xmlDoc.Descendants(XName.Get("Route"));
        if (routes == null || routes.Count() == 0)
        {
            DTCMessageBox.ShowError("The CombatFlite file has no routes.");
            return null;
        }

        ImportRoute[] cfRoutes;

        try
        {
            cfRoutes = routes.Select(r => new ImportRoute
            {
                Name = r.Descendants(XName.Get("Name")).First().Value,
                Aircraft = r.Descendants(XName.Get("Aircraft")).First().Descendants(XName.Get("Type")).First().Value,
                Waypoints = r.Descendants(XName.Get("Waypoint")).Select((w, index) => new ImportWaypoint
                {
                    Sequence = index + 1,
                    Name = w.Descendants(XName.Get("Name")).First().Value,
                    Coordinate = Coordinate.FromDCS(
                        w.Descendants(XName.Get("Lat")).First().Value,
                        w.Descendants(XName.Get("Lon")).First().Value),
                    Elevation = (int)decimal.Parse(w.Descendants(XName.Get("Altitude")).First().Value, CultureInfo.InvariantCulture),
                    TimeOverSteerpoint = ParseTOT(w.Descendants(XName.Get("TOT")).First().Value)
                }).ToArray()
            }).ToArray();
        }
        catch (XmlException)
        {
            DTCMessageBox.ShowError("The CombatFlite file is not valid.");
            return null;
        }

        Array.Sort(cfRoutes, (a, b) => a.Name.CompareTo(b.Name));

        return cfRoutes;
    }

    private static string ParseTOT(string value)
    {
        string result = "";

        try
        {
            result = DateTime.Parse(value, CultureInfo.CurrentCulture).ToString("HH:mm:ss");
        }
        catch
        {
            try
            {
                result = DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")).ToString("HH:mm:ss");
            }
            catch
            {
            }
        }

        return result;
    }
}
