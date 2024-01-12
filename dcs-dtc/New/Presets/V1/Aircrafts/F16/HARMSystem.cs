namespace DTC.New.Presets.V1.Aircrafts.F16;

public class HARMSystem
{
    public HARMTable[] Tables { get; set; }
    public bool EnableUpload { get; set; }

    public HARMSystem()
    {
        Tables = new HARMTable[3];
        Tables[0] = new HARMTable(1, 110, 104, 103, 115, 107);
        Tables[1] = new HARMTable(2, 120, 119, 117, 121, 109);
        Tables[2] = new HARMTable(3, 123, 122, 108, 126, 118);
    }

    public static readonly HARMTable[] DefaultTables =
    {
        new HARMTable(1, 110, 104, 103, 115, 107),
        new HARMTable(2, 120, 119, 117, 121, 109),
        new HARMTable(3, 123, 122, 108, 126, 118)
    };
}

public class HARMTable
{
    public int TableNumber;
    public bool ToBeUpdated { get; set; }

    public int[] Emitters { get; set; }

    public HARMTable()
    {
    }

    public HARMTable(int tableNumber, int emitter1, int emitter2, int emitter3, int emitter4, int emitter5)
    {
        TableNumber = tableNumber;
        Emitters = new int[] { emitter1, emitter2, emitter3, emitter4, emitter5 };
    }
}
