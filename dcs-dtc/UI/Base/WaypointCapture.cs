using DTC.Utilities;
using System;
using System.Globalization;

namespace DTC.UI.Base
{
    public class WaypointCapture : IDisposable
    {
        public delegate void Callback(Coordinate coordinate, string elevation);

        private WaypointCaptureCrosshair _crossHair;
        private Callback _callback;

        public WaypointCapture(Callback callback)
        {
            _crossHair = new WaypointCaptureCrosshair();
            _crossHair.Show();

            this._callback = callback;

            DataReceiver.DataReceived += DataReceiver_DataReceived;
        }

        private void DataReceiver_DataReceived(DataReceiver.Data d)
        {
            var coord = Coordinate.FromString(d.latitude, d.longitude, CoordinateFormat.NativeDCSFormat);
            var elevation = decimal.Truncate(decimal.Parse(d.elevation, NumberStyles.Any, CultureInfo.InvariantCulture) * new decimal(3.281)).ToString("0");
            _callback(coord, elevation);
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

            DataReceiver.DataReceived -= DataReceiver_DataReceived;
        }
    }
}