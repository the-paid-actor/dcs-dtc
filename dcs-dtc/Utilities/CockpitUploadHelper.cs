
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
        DataReceiver.DataReceived += this.DataReceiver_DataReceived;
    }

    public void Dispose()
    {
        DataReceiver.DataReceived -= this.DataReceiver_DataReceived;
    }

    private void DataReceiver_DataReceived(DataReceiver.Data d)
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