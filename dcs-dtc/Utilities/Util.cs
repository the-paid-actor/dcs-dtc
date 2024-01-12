using System.Dynamic;

namespace DTC.Utilities
{
    public class Util
    {
        public static bool HasProperty(dynamic obj, string name)
        {
            Type objType = obj.GetType();

            if (objType == typeof(ExpandoObject))
            {
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            }

            return objType.GetProperty(name) != null;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool IsValidInt(string text)
        {
            try
            {
                int.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidTime(string txt)
        {
            var parts = txt.Split(':');
            if (parts.Length < 3) return false;
            if (parts[0].Trim() == "" || int.Parse(parts[0]) > 23) return false;
            if (parts[1].Trim() == "" || int.Parse(parts[1]) > 59) return false;
            if (parts[2].Trim() == "" || int.Parse(parts[2]) > 59) return false;
            return true;
        }

        public static string DecimalToString(decimal value)
        {
            return value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }

        internal static string GetAppVersion()
        {
            var version = Application.ProductVersion;
            var parts = version.Split('+');
            if (parts.Length > 0)
            {
                return parts[0];
            }
            return "";
        }

        public static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "");
        }
    }
}
