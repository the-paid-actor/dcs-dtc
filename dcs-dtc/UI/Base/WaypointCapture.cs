using DTC.Models.Base;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;

namespace DTC.UI.Base
{
	public class WaypointCapture : IDisposable
	{
		public class Data
		{
			public string model;
			public string latitude;
			public string longitude;
			public string elevation;
			public string clock;
		}


        public delegate void Callback(string latitude, string longitude, string elevation);

		WaypointCaptureCrosshair _crossHair;

		public WaypointCapture(Callback callback, CoordinateFormatter formatter)
		{
			_crossHair = new WaypointCaptureCrosshair();
			_crossHair.Show();

			UDPSocket.StartReceiving("127.0.0.1", Settings.UDPReceivePort, (string s) => {
				var d = JsonConvert.DeserializeObject<Data>(s);

				Console.WriteLine(d.clock);

				var latitudeHem = "N";
				var longitudeHem = "E";

				if (d.latitude.Contains("-"))
					latitudeHem = "S";

				if (d.longitude.Contains("-"))
					longitudeHem = "W";

				var latitude = decimal.Parse(d.latitude.Replace("-", ""), NumberStyles.Any, CultureInfo.InvariantCulture);
				var longitude = decimal.Parse(d.longitude.Replace("-", ""), NumberStyles.Any, CultureInfo.InvariantCulture);
				var elevation = decimal.Truncate(decimal.Parse(d.elevation, NumberStyles.Any, CultureInfo.InvariantCulture) * new decimal(3.281)).ToString("0");

				var latDegrees = decimal.Truncate(latitude);
				var longDegrees = decimal.Truncate(longitude);

				var latMinutes = Decimal.Multiply(Decimal.Remainder(latitude, Decimal.One), new decimal(60));
				var longMinutes = Decimal.Multiply(Decimal.Remainder(longitude, Decimal.One), new decimal(60));

				var latSeconds = Decimal.Multiply(Decimal.Remainder(latMinutes, Decimal.One), new decimal(60));
				var longSeconds = Decimal.Multiply(Decimal.Remainder(longMinutes, Decimal.One), new decimal(60));

				callback(
					formatter.FormatLat(latitudeHem, latDegrees, latMinutes, latSeconds), 
					formatter.FormatLon(longitudeHem, longDegrees, longMinutes, longSeconds), 
					elevation
					);
			});
		}

		public static decimal TruncateDecimal(decimal value, int precision)
		{
			decimal step = (decimal)Math.Pow(10, precision);
			decimal tmp = Math.Truncate(step * value);
			return tmp / step;
		}

		public void Dispose()
		{
			_crossHair.Close();
			_crossHair.Dispose();
			_crossHair = null;

			UDPSocket.Stop();
		}
	}

    public interface CoordinateFormatter
    {
        string FormatLat(string hem, Decimal latDegrees, Decimal latMinutes, Decimal latSeconds);
        string FormatLon(string hem, Decimal longDegrees, Decimal longMinutes, Decimal longSeconds);
    }

    public class DdmShortFormatter : CoordinateFormatter
    {
        string CoordinateFormatter.FormatLat(string hem, Decimal latDegrees, Decimal latMinutes, Decimal latSeconds)
        {
            var latStr = $"{hem} {latDegrees.ToString("00")}.{WaypointCapture.TruncateDecimal(latMinutes,3).ToString("00.000", CultureInfo.InvariantCulture)}";
            return latStr;
        }

        string CoordinateFormatter.FormatLon(string hem, Decimal longDegrees, Decimal longMinutes, Decimal longSeconds)
        {
            var longStr = $"{hem} {longDegrees.ToString("000")}.{WaypointCapture.TruncateDecimal(longMinutes,3).ToString("00.000", CultureInfo.InvariantCulture)}";
            return longStr;
        }
    }

    public class DdmLongFormatter : CoordinateFormatter
    {
        string CoordinateFormatter.FormatLat(string hem, Decimal latDegrees, Decimal latMinutes, Decimal latSeconds)
        {
            var latStr = $"{hem} {latDegrees.ToString("00")}.{WaypointCapture.TruncateDecimal(latMinutes,4).ToString("00.0000", CultureInfo.InvariantCulture)}";
            return latStr;
        }

        string CoordinateFormatter.FormatLon(string hem, Decimal longDegrees, Decimal longMinutes, Decimal longSeconds)
        {
            var longStr = $"{hem} {longDegrees.ToString("000")}.{WaypointCapture.TruncateDecimal(longMinutes,4).ToString("00.0000", CultureInfo.InvariantCulture)}";
            return longStr;
        }
    }

    public class DmsShortFormatter : CoordinateFormatter
    {
        string CoordinateFormatter.FormatLat(string hem, Decimal latDegrees, Decimal latMinutes, Decimal latSeconds)
        {
            var latStr = $"{hem} {latDegrees.ToString("00")}.{decimal.Truncate(latMinutes).ToString("00")}.{decimal.Truncate(latSeconds).ToString("00")}";
            return latStr;
        }

        string CoordinateFormatter.FormatLon(string hem, Decimal longDegrees, Decimal longMinutes, Decimal longSeconds)
        {
            var longStr = $"{hem} {longDegrees.ToString("000")}.{decimal.Truncate(longMinutes).ToString("00")}.{decimal.Truncate(longSeconds).ToString("00")}";

            return longStr;
        }
    }

        public class DmsLongFormatter : CoordinateFormatter
        {
            string CoordinateFormatter.FormatLat(string hem, Decimal latDegrees, Decimal latMinutes, Decimal latSeconds)
            {
                var latStr = $"{hem} {latDegrees.ToString("00")}.{decimal.Truncate(latMinutes).ToString("00")}.{WaypointCapture.TruncateDecimal(latSeconds, 2).ToString("00.00", CultureInfo.InvariantCulture)}";
				return latStr;
            }

            string CoordinateFormatter.FormatLon(string hem, Decimal longDegrees, Decimal longMinutes, Decimal longSeconds)
            {
                var longStr = $"{hem} {longDegrees.ToString("000")}.{decimal.Truncate(longMinutes).ToString("00")}.{WaypointCapture.TruncateDecimal(longSeconds,2).ToString("00.00", CultureInfo.InvariantCulture)}";

				return longStr;
            }
        }
}
