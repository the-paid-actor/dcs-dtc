
using DTC.Utilities.Network;

namespace DTC.Utilities;

internal class CockpitUploadHelper : IDisposable
{
    private Action<bool, bool> callback;
    private bool pressed;
    private long uploadPressedTimestamp = 0;
    private bool pilot = false;
    private bool cpg = false;

    public CockpitUploadHelper(Action<bool, bool> callback)
    {
        this.callback = callback;
        CockpitInfoReceiver.DataReceived += this.DataReceiver_DataReceived;
    }

    public void Dispose()
    {
        CockpitInfoReceiver.DataReceived -= this.DataReceiver_DataReceived;
    }

    private void DataReceiver_DataReceived(CockpitInfoReceiver.Data d)
    {
        if (!pressed && d.upload == "1" && uploadPressedTimestamp == 0)
        {
            uploadPressedTimestamp = DateTime.Now.Ticks;
        }
        if (d.upload == "0")
        {
            uploadPressedTimestamp = 0;
        }

        pilot = d.pilot == "1";
        cpg = d.cpg == "1";

        pressed = d.upload == "1";

        if (uploadPressedTimestamp != 0 && pressed)
        {
            var timespan = new TimeSpan(DateTime.Now.Ticks - uploadPressedTimestamp);
            if (timespan.TotalMilliseconds > 1000)
            {
                uploadPressedTimestamp = 0;
                callback(pilot, cpg);
            }
        }
    }
}