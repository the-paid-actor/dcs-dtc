
namespace DTC.Utilities;

public class DTCOpenFileDialog
{
    public static string? Open(Tuple<string, string>[] filter)
    {
        var dlg = new OpenFileDialog();
        //dlg.Filter = "CombatFlite files (*.cf)|*.cf|CombatFlite XML Export files (*.xml)|*.xml";
        dlg.Filter = string.Join("|", filter.Select(f => $"{f.Item1} ({f.Item2})|{f.Item2}"));
        dlg.Multiselect = false;
        var result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
            var fileName = dlg.FileName;
            return fileName;
        }
        return null;
    }
}
