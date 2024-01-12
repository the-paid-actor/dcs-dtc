using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildHMD()
    {
        if (!config.Upload.HMD || config.HMD == null)
        {
            return;
        }

        Loop(IsRightMFDSupt(), RMFD.OSB18);
        StartIf(HMDOn());
        {
            Cmd(RMFD.OSB03);

            var mode = "NORM";
            if (config.HMD.RejectMode == HMDRejectMode.Reject1)
            {
                mode = "REJ 1";
            }
            else if (config.HMD.RejectMode == HMDRejectMode.Reject2)
            {
                mode = "REJ 2";
            }
            Loop(HMDMode(mode), RMFD.OSB07);

            Cmd(RMFD.OSB19);
            Cmd(RMFD.OSB06);

            for (int i = 0; i < HMDSystem.RejectSettingsNames.Length; i++)
            {
                string setting = HMDSystem.RejectSettingsNames[i];
                var rejectMode = HMDSystem.DefaultRejectSettings[i];
                if (config.HMD.RejectSettings != null && config.HMD.RejectSettings.ContainsKey(setting))
                {
                    rejectMode = config.HMD.RejectSettings[setting];
                }

                Command btn = RMFD.OSB03;
                var expected = "ON";
                if (rejectMode == HMDRejectMode.Reject1)
                {
                    expected = "1";
                    btn = RMFD.OSB02;
                }
                else if (rejectMode == HMDRejectMode.Reject2)
                {
                    expected = "2";
                    btn = RMFD.OSB01;
                }
                Cmd(BoxHMDSetting(setting, expected, btn));
            }

            Cmd(RMFD.OSB19);

            Loop(IsRightMFDSupt(), RMFD.OSB18);
            Cmd(RMFD.OSB15); //FCS
        }
        EndIf();
    }
}