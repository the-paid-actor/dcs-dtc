using Newtonsoft.Json;

namespace DTC.Utilities.Network;

public class WaypointCaptureData
{
    public bool upload;
    public bool resetAllPP;
    public bool resetAllSmart;
    public WaypointCaptureWptData[] data;
}

public class WaypointCaptureWptData
{
    public string latitude;
    public string longitude;
    public string elevation;
    public bool target;
    public string route;
    public bool pp;
    public int ppStation;
    public int ppNumber;
    public bool smart;
    public string smartStation;
    public string pointType;
    public string identifier;
    public string free;
}

public class WaypointCaptureReceiver
{
    public static event Action<WaypointCaptureData> DataReceived;
    public static event Action<string, string> KneeboardNotesReceived;

    private static UDPSocket socket = new UDPSocket();
    private static bool running = false;

    public static void Start()
    {
        if (running) return;

        socket.StartReceiving("127.0.0.1", 43002, (string s) =>
        {
            if (s.StartsWith("preset_name:"))
            {
                var i = s.IndexOf("|kneeboard_notes:");
                var p = s.Substring(0, i);
                p = p.Replace("preset_name:", "");
                var k = s.Substring(i);
                k = k.Replace("|kneeboard_notes:", "");

                KneeboardNotesReceived?.Invoke(p, k);
            }
            else
            {
                var d = JsonConvert.DeserializeObject<WaypointCaptureData>(s);
                DataReceived?.Invoke(d);
            }
        });

        running = true;
    }

    public static void Stop()
    {
        socket.Stop();
        running = false;
    }
}