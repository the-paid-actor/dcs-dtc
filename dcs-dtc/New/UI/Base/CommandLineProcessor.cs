
namespace DTC.New.UI.Base;

internal class CommandLineProcessor
{
    private readonly MainForm mainForm;

    public CommandLineProcessor(MainForm mainForm)
    {
        this.mainForm = mainForm;
    }

    public void ProcessCommandLineArgs()
    {
        var args = new Stack<string>(Environment.GetCommandLineArgs().Skip(1).Reverse());

        if (args.Count == 0)
        {
            return;
        }

        var loadedPreset = false;
        string aircraft = null;

        for (int i = 0; i < args.Count; i++)
        {
            var cmd = args.Peek();
            if (cmd == "--load")
            {
                args.Pop();

                var preset = args.Peek().Replace("\"", "");
                var parts = preset.Split('\\');
                aircraft = parts[0];
                var page = mainForm.NavigateTo(aircraft);
                if (parts.Length > 1)
                {
                    loadedPreset = page.ShowPreset(parts[1].Replace(".json", "", StringComparison.OrdinalIgnoreCase));
                }

                args.Pop();
            }
        }

        if (loadedPreset)
        {
            for (int i = 0; i < args.Count; i++)
            {
                var cmd = args.Peek();
                if (cmd == "--upload")
                {
                    args.Pop();
                    if (aircraft == "AH64D")
                    {
                        if (args.Peek() == "pilot")
                        {
                            args.Pop();
                            mainForm.ExecuteUpload(true, false);
                        }
                        else if (args.Peek() == "cpg")
                        {
                            args.Pop();
                            mainForm.ExecuteUpload(false, true);
                        }
                    }
                    else
                    {
                        mainForm.ExecuteUpload(false, false);
                    }
                }
            }
        }

        for (int i = 0; i < args.Count; i++)
        {
            var cmd = args.Peek();
            if (cmd == "--exit")
            {
                args.Pop();
                Application.Exit();
            }
        }
    }
}
