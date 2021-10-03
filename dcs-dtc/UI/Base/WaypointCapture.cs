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
		}

		public delegate void Callback(string latitude, string longitude, string elevation);

		WaypointCaptureCrosshair _crossHair;

		public WaypointCapture(Callback callback)
		{
			_crossHair = new WaypointCaptureCrosshair();
			_crossHair.Show();

			var port = ConfigurationManager.AppSettings["UDPReceivePort"];

			UDPSocket.StartReceiving("127.0.0.1", int.Parse(port ?? "42069"), (string s) => {
				var d = JsonConvert.DeserializeObject<Data>(s);

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

				var latStr = $"{latitudeHem} {latDegrees.ToString("00")}.{latMinutes.ToString("00.000", CultureInfo.InvariantCulture)}";
				var longStr = $"{longitudeHem} {longDegrees.ToString("000")}.{longMinutes.ToString("00.000", CultureInfo.InvariantCulture)}";

				callback(latStr, longStr, elevation);
			});
		}

		public void Dispose()
		{
			_crossHair.Close();
			_crossHair.Dispose();
			_crossHair = null;

			UDPSocket.Stop();
		}
	}
}
