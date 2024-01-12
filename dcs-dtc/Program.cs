using DTC.Utilities;

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

        var v7 = true;
        Form form;

        if (v7)
        {
            form = new DTC.New.UI.Base.MainForm();
            DCSInstallCheck.MAIN_LUA_FILE = "DCSDTC.lua";
        }
        else
        {
            form = new DTC.UI.MainForm();
            DCSInstallCheck.MAIN_LUA_FILE = "DCSDTC.lua";
        }

        Application.Run(form);
    }
}