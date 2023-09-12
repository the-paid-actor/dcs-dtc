using System.Runtime.InteropServices;
using System.Text;

namespace DTC.Utilities
{
	public static class IniFile
	{
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,
				 string key, string def, StringBuilder retVal,
			int size, string filePath);

		public static string ReadValue(string path, string section, string key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(section, key, "", temp,
											255, path);
			return temp.ToString();
		}
	}
}
