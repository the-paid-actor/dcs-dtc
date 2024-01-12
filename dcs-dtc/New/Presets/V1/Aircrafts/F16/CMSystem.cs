namespace DTC.New.Presets.V1.Aircrafts.F16;

public class CMSystem
{
    private Program[] programs;

    public Program[] Programs { get => programs; set => programs = value; }
    public int ChaffBingo { get; set; }
    public int FlareBingo { get; set; }
    public bool EnableUpload { get; set; }

    public CMSystem()
    {
        Programs = new Program[6];
        Programs[0] = new Program(1, 1, (decimal)0.02, 10, (decimal)1.0, 1, (decimal)0.02, 10, (decimal)1.0, false);
        Programs[1] = new Program(2, 1, (decimal)0.02, 10, (decimal)0.5, 1, (decimal)0.02, 10, (decimal)0.5, false);
        Programs[2] = new Program(3, 2, (decimal)0.1, 5, (decimal)1.0, 2, (decimal)0.1, 5, (decimal)1.0, false);
        Programs[3] = new Program(4, 2, (decimal)0.1, 5, (decimal)0.5, 2, (decimal)0.1, 5, (decimal)0.5, false);
        Programs[4] = new Program(5, 2, (decimal)0.05, 20, (decimal)0.75, 2, (decimal)0.05, 20, (decimal)0.75, false);
        Programs[5] = new Program(6, 1, (decimal)0.02, 1, (decimal)0.5, 1, (decimal)0.02, 1, (decimal)0.5, false);

        ChaffBingo = 10;
        FlareBingo = 10;
    }

    public void AfterLoadFromJson()
    {
        if (Programs.Length == 5)
        {
            Array.Resize(ref programs, 6);
            programs[5] = new Program(6, 1, (decimal)0.02, 1, (decimal)0.5, 1, (decimal)0.02, 1, (decimal)0.5, false);
        }
    }
}
