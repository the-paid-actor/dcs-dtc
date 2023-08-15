using System;
using System.IO;
using System.Net.Sockets;

namespace DTC.Utilities
{
	internal class DataSender
	{
		public static void Send(string str)
		{
			try
			{
				using (var tcpClient = new TcpClient("127.0.0.1", Settings.TCPSendPort))
				using (var ns = tcpClient.GetStream())
				using (var sw = new StreamWriter(ns))
				{
					var data = "[" + str + "]";
					Console.WriteLine(data);

					sw.WriteLine(data);
					sw.Flush();
				}
			}
			catch (SocketException)
			{
				DTCMessageBox.ShowError("Error connecting to DCS. Make sure DTC is installed correctly, DCS is running and you are in the cockpit.");
			}
		}
	}
}