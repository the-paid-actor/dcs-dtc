using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DTC.Utilities.Network;

public class UDPSocket
{
    private Socket socket;
    private const int bufSize = 8 * 1024;
    private State state = new State();
    private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
    private AsyncCallback recv = null;
    private bool running = false;
    private bool stop = false;

    public delegate void ReceiveCallback(string s);

    public class State
    {
        public byte[] buffer = new byte[bufSize];
    }

    public void StartReceiving(string address, int port, ReceiveCallback callback)
    {
        if (!running)
        {
            running = true;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive(callback);
        }
    }

    public void Send(string text, string address, int port)
    {
        text = text.Replace("\r\n", "\n");
        using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            var serverAddr = IPAddress.Parse(address);
            var endPoint = new IPEndPoint(serverAddr, port);
            var send_buffer = Encoding.UTF8.GetBytes(text);
            sock.SendTo(send_buffer, endPoint);
        }
    }

    public void Stop()
    {
        stop = true;
    }

    private void Receive(ReceiveCallback callback)
    {
        socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
        {
            var so = (State)ar.AsyncState;
            var bytes = socket.EndReceiveFrom(ar, ref epFrom);
            var str = Encoding.ASCII.GetString(so.buffer, 0, bytes);
            callback(str);

            if (!stop)
            {
                socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
            }
            else
            {
                socket.Close();
                socket.Dispose();
                stop = false;
                running = false;
            }
        }, state);
    }
}
