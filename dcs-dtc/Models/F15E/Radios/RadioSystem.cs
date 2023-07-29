namespace DTC.Models.F15E.Radios
{
    public enum RadioMode
    {
        Frequency = 1,
        Preset = 2
    }

    public class Radio
    {
        public string[] Frequencies = new string[20];
        public string SelectedFrequency;
        public string SelectedPreset = "1";
        public bool EnableGuard = false;
        public RadioMode Mode = RadioMode.Frequency;
    }

    public class RadioSystem
    {
        public Radio Radio1 = new Radio();
        public Radio Radio2 = new Radio();
        public bool EnableUpload = false;
    }
}
