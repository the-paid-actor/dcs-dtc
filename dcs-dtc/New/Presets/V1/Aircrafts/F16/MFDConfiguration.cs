namespace DTC.New.Presets.V1.Aircrafts.F16;

public class MFDConfiguration
{
    public int SelectedPage { get; set; }
    public Page Page1 { get; set; }
    public Page Page2 { get; set; }
    public Page Page3 { get; set; }

    public MFDConfiguration(Page page1, Page page2, Page page3, int selectedPage)
    {
        Page1 = page1;
        Page2 = page2;
        Page3 = page3;
        SelectedPage = selectedPage;
    }
}
