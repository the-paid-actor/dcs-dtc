namespace DTC.Utilities.Network;

internal class KneeboardSender
{
    private static UDPSocket socket = new UDPSocket();

    public static void SendInfo(string presetName, string text)
    {
        socket.Send(string.Concat("preset_name:", presetName), "127.0.0.1", 43001);
        socket.Send(string.Concat("kneeboard_info:", text), "127.0.0.1", 43001);
    }

    public static void SendNotes(string text)
    {
        socket.Send(string.Concat("kneeboard_notes:", text), "127.0.0.1", 43001);
    }
}
