
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildCMS()
    {
        if (!config.Upload.CMS || config.CMS == null) return;

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);

        Cmd(UFC.LIST);
        Cmd(UFC.D7);

        Cmd(Digits(UFC, IntegerString(config.CMS.ChaffBingo)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(config.CMS.FlareBingo)));
        Cmd(UFC.ENTR);
        Cmd(UFC.UP);

        Cmd(UFC.SEQ);

        for (var i = 0; i < config.CMS.Programs.Length; i++)
        {
            var program = config.CMS.Programs[i];
            if (!program.ToBeUpdated)
            {
                Cmd(UFC.INC);
                continue;
            }

            Cmd(Digits(UFC, IntegerString(program.ChaffBurstQty)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, BurstIntervalString(program.ChaffBurstInterval)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, IntegerString(program.ChaffSalvoQty)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, SalvoIntervalString(program.ChaffSalvoInterval)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(UFC.INC);
        }

        Cmd(UFC.SEQ);

        for (var i = 0; i < config.CMS.Programs.Length; i++)
        {
            var program = config.CMS.Programs[i];
            if (!program.ToBeUpdated)
            {
                Cmd(UFC.INC);
                continue;
            }

            Cmd(Digits(UFC, IntegerString(program.FlareBurstQty)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, BurstIntervalString(program.FlareBurstInterval)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, IntegerString(program.FlareSalvoQty)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, SalvoIntervalString(program.FlareSalvoInterval)));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(UFC.INC);
        }

        Cmd(UFC.RTN);
    }

    private string BurstIntervalString(decimal v)
    {
        var str = v.ToString("00.000", CultureInfo.InvariantCulture);
        str = str.Replace(".", "");
        return str;
    }

    private string SalvoIntervalString(decimal v)
    {
        var str = v.ToString("00.00", CultureInfo.InvariantCulture);
        str = str.Replace(".", "");
        return str;
    }
}