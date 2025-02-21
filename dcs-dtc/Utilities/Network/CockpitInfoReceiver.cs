using Newtonsoft.Json;

namespace DTC.Utilities.Network;

public class CockpitInfoReceiver
{
    public class Data
    {
        public string model;
        public string latitude;
        public string longitude;
        public string elevation;
        public string clock;
        public string upload;
        public string pilot;
        public string cpg;
        public string showDTC;
        public string hideDTC;
        public string toggleDTC;
    }

    private static UDPSocket socket = new UDPSocket();
    public static event Action<Data> DataReceived;

    public static void Start()
    {
        socket.StartReceiving("127.0.0.1", Settings.UDPReceivePort, (string s) =>
        {
            var d = JsonConvert.DeserializeObject<Data>(s);
            DataReceived?.Invoke(d);
        });
    }

    public static void Stop()
    {
        socket.Stop();
    }
}