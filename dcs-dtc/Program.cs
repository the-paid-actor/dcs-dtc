using System.Globalization;

namespace DTC;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// using System.Globalization;

    
    [STAThread]
    static void Main()
    {
        var culture = CultureInfo.InvariantCulture;

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var form = new New.UI.Base.MainForm();

        Application.Run(form);
    }
}