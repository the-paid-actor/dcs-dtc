using CoordinateSharp;
using System;
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
        DegreesMinutesSecondsHundredths,
        MGRSSixDigits,
        MGRSTenDigits
    }

    public class Coordinate
    {
        public static Regex DegreesMinutesHundredthsRegex = new Regex("^([N|S] \\d\\d\\°\\d\\d\\.\\d\\d\\’) ([E|W] \\d\\d\\d\\°\\d\\d\\.\\d\\d\\’)$");
        public static Regex DegreesMinutesThousandthsRegex = new Regex("^([N|S] \\d\\d\\°\\d\\d\\.\\d\\d\\d\\’) ([E|W] \\d\\d\\d\\°\\d\\d\\.\\d\\d\\d\\’)$");
        
        public static string DegreesMinutesHundredthsMask = ">L 00°00\\.00’ L 000°00\\.00’";
        public static string DegreesMinutesThousandthsMask = ">L 00°00\\.000’ L 000°00\\.000’";
        public static string DegreesMinutesSecondsHundredthsMask = ">L 00°00’00\\.00” L 000°00’00\\.00”";

        private readonly CoordinateSharp.Coordinate c;
        public readonly CoordinateFormat Format;

        public static Coordinate FromString(string lat, string lon, CoordinateFormat format)
        {
            if (string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                return null;

            CoordinateSharp.Coordinate c;
            switch (format)
            {
                case CoordinateFormat.NativeDCSFormat:
                    var latitude = double.Parse(lat, NumberStyles.Any, CultureInfo.InvariantCulture);
                    var longitude = double.Parse(lon, NumberStyles.Any, CultureInfo.InvariantCulture);
                    c = new CoordinateSharp.Coordinate(latitude, longitude);
                    break;
                default:
                    if (CoordinateSharp.Coordinate.TryParse(lat + " " + lon, out c) == false)
                        throw new Exception("Cannot parse coordinate - " + lat + " " + lon);
                    break;
            }

            if (c == null) return null;
            return new Coordinate(c, format);
        }

        private Coordinate(CoordinateSharp.Coordinate c, CoordinateFormat format)
        {
            this.c = c;
            this.Format = format;
        }

        private string ToDegreesMinutesDecimal(int roundDigits)
        {
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var minD = new decimal(part.DecimalMinute);
                var deg = part.Degrees.ToString(CultureInfo.InvariantCulture).PadLeft(leadingDegZeros, '0');
                var min = decimal.Truncate(minD).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var minRem = decimal.Round(decimal.Remainder(minD, 1m), roundDigits).ToString(CultureInfo.InvariantCulture);
                var minFrac = minRem.Substring(2).PadRight(roundDigits, '0');
                var str = $"{part.Position} {deg}°{min}.{minFrac}’";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return latStr + " " + lonStr;
        }

        public string ToDegreesMinutesHundredths()
        {
            //DD°MM.MM’;
            return ToDegreesMinutesDecimal(2);
        }

        public string ToDegreesMinutesThousandths()
        {
            //DD°MM.MMM’;
            return ToDegreesMinutesDecimal(3);
        }

        public string ToDegreesMinutesTenThousandths()
        {
            //DD°MM.MMMM’;
            return ToDegreesMinutesDecimal(4);
        }

        public string ToDegreesMinutesSeconds()
        {
            //DD°MM’SS”;
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var deg = part.Degrees.ToString().PadLeft(leadingDegZeros, '0');
                var min = part.Minutes.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var sec = ((int)part.Seconds).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var str = $"{part.Position} {deg}°{min}’{sec}”";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return latStr + " " + lonStr;
        }

        public string ToDegreesMinutesSecondsHundredths()
        {
            //DD°MM’SS.SS”;
            string formatLatLong(CoordinatePart part, int leadingDegZeros)
            {
                var deg = part.Degrees.ToString().PadLeft(leadingDegZeros, '0');
                var min = part.Minutes.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var secD = new decimal(part.Seconds);
                var sec = decimal.Truncate(secD).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                var secRem = decimal.Remainder(secD, 1m).ToString(CultureInfo.InvariantCulture);
                var secFrac = secRem.Substring(0, Math.Min(secRem.Length, 4)).Substring(2).PadRight(2, '0');

                var str = $"{part.Position} {deg}°{min}’{sec}.{secFrac}”";
                return str;
            }

            var latStr = formatLatLong(this.c.Latitude, 2);
            var lonStr = formatLatLong(this.c.Longitude, 3);
            return latStr + " " + lonStr;
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
    }
}
