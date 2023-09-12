using Newtonsoft.Json;
using System;

namespace DTC.Utilities
{
	public class DataReceiver
	{
		public class Data
		{
			public string model;
			public string latitude;
			public string longitude;
			public string elevation;
			public string clock;
			public string upload;
			public string showDTC;
			public string hideDTC;
			public string toggleDTC;
        }

		public static event Action<Data> DataReceived;

		public static void Start()
		{
			UDPSocket.StartReceiving("127.0.0.1", Settings.UDPReceivePort, (string s) =>
			{
				var d = JsonConvert.DeserializeObject<Data>(s);
				DataReceived?.Invoke(d);
			});
		}

		public static void Stop()
		{
			UDPSocket.Stop();
		}
	}
}