using CoordinateSharp;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.Utilities
{
    public enum CoordinateFormat
    {
        NativeDCSFormat,
        DegreesMinutesHundredths,
        DegreesMinutesThousandths,
        DegreesMinutesTenThousandths,
        DegreesMinutesSeconds,
        DegreesMinutesSecondsHundredths,
        MGRSSixDigits,
        MGRSTenDigits
    }

    public class LatLon
    {
        public string Lat { get; set; }
        public string Lon { get; set; }

        public LatLon(string lat, string lon)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        public override string ToString()
        {
            return $"{Lat} {Lon}";
        }
    }

    public class Coordinate
    {
        public static Regex DegreesMinutesHundredthsRegex = new Regex("^([N|S] \\d\\d\\°\\d\\d\\.\\d\\d\\’) ([E|W] \\d\\d\\d\\°\\d\\d\\.\\d\\d\\’)$");
        public static Regex DegreesMinutesThousandthsRegex = new Regex("^([N|S] \\d\\d\\°\\d\\d\\.\\d\\d\\d\\’) ([E|W] \\d\\d\\d\\°\\d\\d\\.\\d\\d\\d\\’)$");
        
        public static string DegreesMinutesHundredthsMask = ">L 00°00\\.00’ L 000°00\\.00’";
        public static string DegreesMinutesThousandthsMask = ">L 00°00\\.000’ L 000°00\\.000’";
        public static string DegreesMinutesSecondsMask = ">L 00°00’00” L 000°00’00”";
        public static string DegreesMinutesSecondsHundredthsMask = ">L 00°00’00\\.00” L 000°00’00\\.00”";
        public static string MGRSTenDigitsMask = ">00 L LL 00000 00000";

        private readonly CoordinateSharp.Coordinate c;

        public static Coordinate FromString(string coordinate)
        {
            if (string.IsNullOrWhiteSpace(coordinate))
                return null;

            coordinate = coordinate.Replace("”", "\"").Replace("’", "'");

            if (CoordinateSharp.Coordinate.TryParse(coordinate, out var c) == false)
                throw new Exception("Cannot parse coordinate - " + coordinate);

            if (c == null) return null;
            return new Coordinate(c);
        }

        public static bool TryFromString(string str, out Coordinate? c)
        {
            try
            {
                c = FromString(str);
                if (c != null)
                {
                    return true;
                }
            }
            catch
            {
            }

            c = null;
            return false;
        }

        public static Coordinate? FromString(string lat, string lon)
        {
            if (string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                return null;

            return FromString(lat + " " + lon);
        }

        public static Coordinate? FromDCS(string lat, string lon)
        {
            if (string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                return null;

            var latitude = double.Parse(lat, NumberStyles.Any, CultureInfo.InvariantCulture);
            var longitude = double.Parse(lon, NumberStyles.Any, CultureInfo.InvariantCulture);
            var c = new CoordinateSharp.Coordinate(latitude, longitude);

            if (c == null) return null;
            return new Coordinate(c);
        }

        private Coordinate(CoordinateSharp.Coordinate c)
        {
            this.c = c;
        }

        private LatLon ToDegreesMinutesDecimal(int roundDigits)
        {
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var deg = part.Degrees.ToString().PadLeft(leadingDegZeros, '0');
                var minD = new decimal(part.DecimalMinute);
                var min = decimal.Truncate(minD).ToString().PadLeft(2, '0');
                var minRem = decimal.Round(decimal.Remainder(minD, 1m), roundDigits, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
                if (minRem.Length < 2) minRem = minRem.PadLeft(2, '0');
                var minFrac = minRem.Substring(2).PadRight(roundDigits, '0');
                var str = $"{part.Position} {deg}°{min}.{minFrac}’";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return new LatLon(latStr, lonStr);
        }

        public LatLon ToDegreesMinutesHundredths()
        {
            //DD°MM.MM’;
            return ToDegreesMinutesDecimal(2);
        }

        public LatLon ToDegreesMinutesThousandths()
        {
            //DD°MM.MMM’;
            return ToDegreesMinutesDecimal(3);
        }

        public LatLon ToDegreesMinutesTenThousandths()
        {
            //DD°MM.MMMM’;
            return ToDegreesMinutesDecimal(4);
        }

        public LatLon ToDegreesMinutesSeconds()
        {
            //DD°MM’SS”;
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var deg = part.Degrees.ToString().PadLeft(leadingDegZeros, '0');
                var min = part.Minutes.ToString().PadLeft(2, '0');
                var sec = Math.Round(part.Seconds, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var str = $"{part.Position} {deg}°{min}’{sec}”";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return new LatLon(latStr, lonStr);
        }

        public LatLon ToDegreesMinutesSecondsHundredths()
        {
            //DD°MM’SS.SS”;
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var deg = part.Degrees.ToString().PadLeft(leadingDegZeros, '0');
                var min = part.Minutes.ToString().PadLeft(2, '0');
                var secD = new decimal(Math.Round(part.Seconds, 2, MidpointRounding.AwayFromZero));
                var sec = decimal.Truncate(secD).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var secFrac = Math.Round(decimal.Remainder(secD, 1m) * 100, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

                var str = $"{part.Position} {deg}°{min}’{sec}.{secFrac}”";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return new LatLon(latStr, lonStr);
        }

        public string ToMGRSSixDigits()
        {
            var mgrs = this.ToMGRSTenDigits();
            var parts = mgrs.Split(' ');
            return $"{parts[0]} {parts[1]} {parts[2].Substring(0,3)} {parts[3].Substring(0,3)}";
        }

        public string ToMGRSTenDigits()
        {
            return this.c.MGRS.ToString();
        }

        public LatLon ToHornetPreplannedFormat()
        {
            return this.ToDegreesMinutesSecondsHundredths();
        }

        public LatLon ToHornetNonPreciseSteerpointFormat()
        {
            return this.ToDegreesMinutesSeconds();
        }

        public LatLon ToHornetPreciseSteerpointFormat()
        {
            return this.ToDegreesMinutesThousandths();
        }

        public LatLon ToF15EFormat()
        {
            return this.ToDegreesMinutesThousandths();
        }

        public LatLon ToF16Format()
        {
            return this.ToDegreesMinutesThousandths();
        }

        internal string ToString(CoordinateFormat format)
        {
            switch (format)
            {
                case CoordinateFormat.DegreesMinutesHundredths:
                    return this.ToDegreesMinutesHundredths().ToString();
                case CoordinateFormat.DegreesMinutesThousandths:
                    return this.ToDegreesMinutesThousandths().ToString();
                case CoordinateFormat.DegreesMinutesTenThousandths:
                    return this.ToDegreesMinutesTenThousandths().ToString();
                case CoordinateFormat.DegreesMinutesSeconds:
                    return this.ToDegreesMinutesSeconds().ToString();
                case CoordinateFormat.DegreesMinutesSecondsHundredths:
                    return this.ToDegreesMinutesSecondsHundredths().ToString();
                case CoordinateFormat.MGRSSixDigits:
                    return this.ToMGRSSixDigits();
                case CoordinateFormat.MGRSTenDigits:
                    return this.ToMGRSTenDigits();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
