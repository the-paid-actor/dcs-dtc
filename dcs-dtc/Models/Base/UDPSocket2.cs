using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DTC.Models.Base
{
    public class UDPSocket2
    {
        private Socket _socket;
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;
        private bool _running = false;
        private bool _stop = false;

        public delegate void ReceiveCallback(string s);

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public void StartReceiving(string address, int port, ReceiveCallback callback)
        {
            if (!_running)
            {
                _running = true;
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
                Receive(callback);
            }
        }

        public void Stop()
        {
            _stop = true;
        }

        private void Receive(ReceiveCallback callback)
        {
            _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                var str = Encoding.ASCII.GetString(so.buffer, 0, bytes);
                callback(str);

                if (!_stop)
                {
                    _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                }
                else
                {
                    _socket.Close();
                    _socket.Dispose();
                    _stop = false;
                    _running = false;
                }
            }, state);
        }
    }
}
