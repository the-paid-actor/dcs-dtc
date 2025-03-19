using System.IO.Pipes;

namespace DTC.Utilities;

public class NamedPipeServer
{
    public class MessageReceivedEventArgs
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    private readonly string _pipeName;
    private NamedPipeServerStream _pipeServer;
    private bool _isRunning;

    public event Action<MessageReceivedEventArgs>? OnMessageReceived;

    public NamedPipeServer(string pipeName)
    {
        _pipeName = pipeName;
    }

    public void Start()
    {
        _isRunning = true;


        WaitForClientAsync();
    }

    private void WaitForClientAsync()
    {
        if (!_isRunning) return;

        _pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 
            1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

        _pipeServer.BeginWaitForConnection(OnClientConnected, _pipeServer);
    }

    private void OnClientConnected(IAsyncResult ar)
    {
        if (!_isRunning) return;

        try
        {
            _pipeServer.EndWaitForConnection(ar);

            using (StreamReader reader = new StreamReader(_pipeServer))
            using (StreamWriter writer = new StreamWriter(_pipeServer) { AutoFlush = true })
            {
                string? message = reader.ReadLine();
                if (message != null)
                {
                    var args = new MessageReceivedEventArgs { Message = message };
                    OnMessageReceived?.Invoke(args);
                    if (args.Success)
                    {
                        writer.WriteLine("OK");
                    }
                }
            }
        }
        catch(Exception)
        {
        }
        finally
        {
            _pipeServer.Dispose();
            WaitForClientAsync();
        }
    }

    public void Stop()
    {
        _isRunning = false;
        _pipeServer?.Dispose();
    }
}
