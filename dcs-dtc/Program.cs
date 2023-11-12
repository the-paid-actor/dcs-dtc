using DTC.UI;
using System.Globalization;

namespace DTC;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
		InitializeCulture();

		Application.Run(new MainForm());
    }

	private static void InitializeCulture()
	{
		CultureInfo cultureInfo = CultureInfo.InvariantCulture;
		//CultureInfo cultureInfo = new CultureInfo("fr-FR");
		CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentCulture = cultureInfo;
	}

}