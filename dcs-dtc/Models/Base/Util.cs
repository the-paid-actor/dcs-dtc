namespace DTC.Models.Base
{
	public class Util
	{
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
	}
}
