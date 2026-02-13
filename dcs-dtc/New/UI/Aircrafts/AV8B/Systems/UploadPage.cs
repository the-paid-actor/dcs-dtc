using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.AV8B.Systems;

public class UploadPage : AircraftSystemPage
{
    public UploadPage(AV8BPage parent) : base(parent, nameof(parent.Configuration.Upload))
    {
    }

    public override string GetPageTitle()
    {
        return "Upload Settings";
    }
}
