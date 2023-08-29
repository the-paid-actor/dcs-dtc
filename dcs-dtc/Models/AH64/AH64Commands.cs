using DTC.Models.DCS;

namespace DTC.Models.AH64
{
    public class AH64Commands : IAircraftDeviceManager
    {
        private Dictionary<string, Device> Devices = new Dictionary<string, Device>();
        public AH64Commands()
        {
            var delay = 200;

            var mpd = new Device(47, "Right_MPD");
            mpd.AddCommand(new Command(3024, "L1", delay, 1));
            mpd.AddCommand(new Command(3023, "L2", delay, 1));
            mpd.AddCommand(new Command(3022, "L3", delay, 1));
            mpd.AddCommand(new Command(3021, "L4", delay, 1));
            mpd.AddCommand(new Command(3020, "L5", 0, 1));
            mpd.AddCommand(new Command(3019, "L6", 0, 1));
            mpd.AddCommand(new Command(3007, "R1", 0, 1));
            mpd.AddCommand(new Command(3008, "R2", 0, 1));
            mpd.AddCommand(new Command(3009, "R3", 0, 1));
            mpd.AddCommand(new Command(3010, "R4", 0, 1));
            mpd.AddCommand(new Command(3011, "R5", 0, 1));
            mpd.AddCommand(new Command(3012, "R6", 0, 1));
            mpd.AddCommand(new Command(3018, "B1", 0, 1));
            mpd.AddCommand(new Command(3017, "B2", 0, 1));
            mpd.AddCommand(new Command(3016, "B3", 0, 1));
            mpd.AddCommand(new Command(3015, "B4", 0, 1));
            mpd.AddCommand(new Command(3014, "B5", 0, 1));
            mpd.AddCommand(new Command(3013, "B6", 0, 1));
            mpd.AddCommand(new Command(3001, "T1", 0, 1));
            mpd.AddCommand(new Command(3002, "T2", 0, 1));
            mpd.AddCommand(new Command(3003, "T3", 0, 1));
            mpd.AddCommand(new Command(3004, "T4", 0, 1));
            mpd.AddCommand(new Command(3005, "T5", 0, 1));
            mpd.AddCommand(new Command(3006, "T6", 0, 1));
            mpd.AddCommand(new Command(3029, "TSD", 0, 1));
            mpd.AddCommand(new Command(3030, "WPN", 0, 1));
            mpd.AddCommand(new Command(3031, "FCR", 0, 1));
            mpd.AddCommand(new Command(3027, "COM", 0, 1));
            mpd.AddCommand(new Command(3026, "VID", 0, 1));
            mpd.AddCommand(new Command(3028, "AC", 0, 1));
            mpd.AddCommand(new Command(3025, "*", 0, 1));
            mpd.AddCommand(new Command(3060, "F1", 0, 1));
            
            AddDevice(mpd);

            var ku = new Device(31, "KU");
            ku.AddCommand(new Command(3001, "CLR", delay, 1));
            ku.AddCommand(new Command(3002, "BKS", delay, 1));
            ku.AddCommand(new Command(3003, "SPACE", delay, 1));
            ku.AddCommand(new Command(3004, "LEFT", delay, 1));
            ku.AddCommand(new Command(3005, "RIGHT", delay, 1));
            ku.AddCommand(new Command(3006, "ENTR", delay, 1));
            ku.AddCommand(new Command(3007, "A", delay, 1));
            ku.AddCommand(new Command(3008, "B", delay, 1));
            ku.AddCommand(new Command(3009, "C", delay, 1));
            ku.AddCommand(new Command(3010, "D", delay, 1));
            ku.AddCommand(new Command(3011, "E", delay, 1));
            ku.AddCommand(new Command(3012, "F", delay, 1));
            ku.AddCommand(new Command(3013, "G", delay, 1));
            ku.AddCommand(new Command(3014, "H", delay, 1));
            ku.AddCommand(new Command(3015, "I", delay, 1));
            ku.AddCommand(new Command(3016, "J", delay, 1));
            ku.AddCommand(new Command(3017, "K", delay, 1));
            ku.AddCommand(new Command(3018, "L", delay, 1));
            ku.AddCommand(new Command(3019, "M", delay, 1));
            ku.AddCommand(new Command(3020, "N", delay, 1));
            ku.AddCommand(new Command(3021, "O", delay, 1));
            ku.AddCommand(new Command(3022, "P", delay, 1));
            ku.AddCommand(new Command(3023, "Q", delay, 1));
            ku.AddCommand(new Command(3024, "R", delay, 1));
            ku.AddCommand(new Command(3025, "S", delay, 1));
            ku.AddCommand(new Command(3026, "T", delay, 1));
            ku.AddCommand(new Command(3027, "U", delay, 1));
            ku.AddCommand(new Command(3028, "V", delay, 1));
            ku.AddCommand(new Command(3029, "W", delay, 1));
            ku.AddCommand(new Command(3030, "X", delay, 1));
            ku.AddCommand(new Command(3031, "Y", delay, 1));
            ku.AddCommand(new Command(3032, "Z", delay, 1));
            ku.AddCommand(new Command(3033, "1", delay, 1));
            ku.AddCommand(new Command(3034, "2", delay, 1));
            ku.AddCommand(new Command(3035, "3", delay, 1));
            ku.AddCommand(new Command(3036, "4", delay, 1));
            ku.AddCommand(new Command(3037, "5", delay, 1));
            ku.AddCommand(new Command(3038, "6", delay, 1));
            ku.AddCommand(new Command(3039, "7", delay, 1));
            ku.AddCommand(new Command(3040, "8", delay, 1));
            ku.AddCommand(new Command(3041, "9", delay, 1));
            ku.AddCommand(new Command(3042, ".", delay, 1));
            ku.AddCommand(new Command(3043, "0", delay, 1));
            ku.AddCommand(new Command(3044, "+/-", delay, 1));
            ku.AddCommand(new Command(3045, "/", delay, 1));
            ku.AddCommand(new Command(3046, "+", delay, 1));
            ku.AddCommand(new Command(3047, "-", delay, 1));
            ku.AddCommand(new Command(3048, "num/", delay, 1));
            ku.AddCommand(new Command(3049, "*", delay, 1));

            AddDevice(ku);
        }
        private void AddDevice(Device d)
        {
            Devices.Add(d.Name, d);
        }

        public Device GetDevice(string id)
        {
            return Devices[id];
        }
    }
}
