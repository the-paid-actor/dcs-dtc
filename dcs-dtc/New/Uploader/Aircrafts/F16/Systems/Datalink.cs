using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildDatalink()
    {
        if (!config.Upload.Datalink || config.Datalink == null) return;

        if (config.Datalink.EnableOwnCallsign == true || config.Datalink.EnableMembers == true)
        {
            Cmd(UFC.RTN);
            Cmd(UFC.RTN);

            Cmd(UFC.LIST);
            Cmd(UFC.ENTR);
            Cmd(UFC.SEQ);

            if (config.Datalink.EnableOwnCallsign == true)
            {
                Cmd(UFC.DOWN);
                Cmd(UFC.DOWN);
                Cmd(UFC.DOWN);

                var numbers = config.Datalink.OwnCallsign[2].ToString() + config.Datalink.OwnCallsign[3].ToString();

                Cmd(Digits(UFC, numbers));
                Cmd(UFC.ENTR);

                Loop(30, FirstCallSignLetter(config.Datalink.OwnCallsign[0].ToString()), UFC.INC);
                Cmd(UFC.ENTR);
                Loop(30, SecondCallSignLetter(config.Datalink.OwnCallsign[1].ToString()), UFC.INC);
                Cmd(UFC.ENTR);

                if (config.Datalink.FlightLead == true)
                {
                    If(FlightLead("NO"), UFC.D1);
                }
                else
                {
                    If(FlightLead("YES"), UFC.D1);
                }
            }

            Cmd(UFC.SEQ);

            if (config.Datalink.EnableMembers == true && config.Datalink.Members != null)
            {
                Cmd(UFC.UP);
                Cmd(Digits(UFC, config.Datalink.OwnshipIndex.ToString()));
                Cmd(UFC.ENTR);
                Cmd(UFC.DOWN);

                for (int i = 0; i < 8; i++)
                {
                    var member = config.Datalink.Members[i];
                    var tdoa = false;
                    
                    if (config.Datalink.TDOAMembers != null)
                    {
                        tdoa = config.Datalink.TDOAMembers[i];
                    }

                    if (member < 0) continue;

                    Cmd(UFC.DOWN);
                    Cmd(Digits(UFC, member.ToString()));
                    Cmd(UFC.ENTR);
                    Cmd(UFC.UP);
                    Cmd(UFC.UP);
                    if (tdoa == true)
                    {
                        If(TDOA((i + 1).ToString(), ""), UFC.D1);
                    }
                    else
                    {
                        If(TDOA((i + 1).ToString(), "T"), UFC.D1);
                    }

                    Cmd(UFC.DOWN);
                    Cmd(UFC.DOWN);
                }
            }

            Cmd(UFC.RTN);
            Cmd(UFC.RTN);
        }

        if (config.Datalink.DatalinkMode != null)
        {
            var mode = "OFF";
            if (config.Datalink.DatalinkMode == DatalinkMode.TNDL) mode = "TNDL";
            if (config.Datalink.DatalinkMode == DatalinkMode.SMDL) mode = "SMDL";

            var s = "{" +
                $"firstPageId = {LMFD.OSB14.Id}, " +
                $"secondPageId = {LMFD.OSB13.Id}, " +
                $"thirdPageId = {LMFD.OSB12.Id}, " +
                $"leftMFDDeviceID = {LMFD.Id}, " +
                $"rightMFDDeviceID = {RMFD.Id}, " +
                $"xmitButtonId = {LMFD.OSB06.Id}, " +
                $"delay = {Settings.ViperCommandDelayMs * LMFD.OSB06.DelayFactor}, " +
                $"activation = {LMFD.OSB06.Activation}, " +
                $"expected = '{mode}'" +
                "}";

            Cmd(EnableXMIT(s));
        }
    }
}
