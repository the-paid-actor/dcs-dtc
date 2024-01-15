using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildMFDs()
    {
        if (!config.Upload.MFDs) return;

        var cfgs = new List<ModeConfiguration>();

        if (config.MFD.Configurations.Any(c => c.ToBeUpdated))
        {
            foreach (var cfg in config.MFD.Configurations)
            {
                if (!cfg.ToBeUpdated)
                    continue;

                if (cfg.Mode != Mode.NAV)
                {
                    cfgs.Add(cfg);
                }
            }

            foreach (var cfg in config.MFD.Configurations)
            {
                if (!cfg.ToBeUpdated)
                    continue;

                if (cfg.Mode == Mode.NAV)
                {
                    cfgs.Add(cfg);
                }
            }

            foreach (var cfg in cfgs)
            {
                ResetToNavMode();

                if (cfg.Mode == Mode.AA)
                {
                    Cmd(UFC.AA);
                }
                else if (cfg.Mode == Mode.AG)
                {
                    Cmd(UFC.AG);
                }
                else if (cfg.Mode == Mode.DGFT)
                {
                    Cmd(HOTAS.DGFT);
                }
                else if (cfg.Mode == Mode.MSL)
                {
                    Cmd(HOTAS.MSL);
                }

                BuildMFD(LMFD, cfg.Mode, cfg.LeftMFD);
                BuildMFD(RMFD, cfg.Mode, cfg.RightMFD);
            }

            ResetToNavMode();
        }
    }

    private void BuildMFD(Device d, Mode mode, MFDConfiguration mfd)
    {
        Cmd(d.GetCommand("OSB14"));
        Cmd(d.GetCommand("OSB13"));
        
        Cmd(d.GetCommand("OSB14"));
        Cmd(d.GetCommand("OSB14"));
        BuildPage(d, mfd.Page1, mode, mfd);

        Cmd(d.GetCommand("OSB13"));
        Cmd(d.GetCommand("OSB13"));
        BuildPage(d, mfd.Page2, mode, mfd);

        Cmd(d.GetCommand("OSB12"));
        Cmd(d.GetCommand("OSB12"));
        BuildPage(d, mfd.Page3, mode, mfd);

        if (mfd.SelectedPage == 1)
        {
            Cmd(d.GetCommand("OSB14"));
        }
        else if (mfd.SelectedPage == 2)
        {
            Cmd(d.GetCommand("OSB13"));
        }
    }

    private void BuildPage(Device d, Page page, Mode mode, MFDConfiguration mfd)
    {
        if (page == Page.BLANK)
        {
            Cmd(d.GetCommand("OSB01"));
        }
        else if (page == Page.DTE)
        {
            Cmd(d.GetCommand("OSB08"));
        }
        else if (page == Page.FCR)
        {
            Cmd(d.GetCommand("OSB20"));
            Cmd(Wait());
            SetupFCR(d, page, mode, mfd);
        }
        else if (page == Page.FLCS)
        {
            Cmd(d.GetCommand("OSB10"));
        }
        else if (page == Page.FLIR)
        {
            Cmd(d.GetCommand("OSB16"));
        }
        else if (page == Page.HAD)
        {
            Cmd(d.GetCommand("OSB02"));
        }
        else if (page == Page.HSD)
        {
            Cmd(d.GetCommand("OSB07"));
        }
        else if (page == Page.RCCE)
        {
            Cmd(d.GetCommand("OSB04"));
        }
        else if (page == Page.SMS)
        {
            Cmd(d.GetCommand("OSB06"));
            Cmd(d.GetCommand("OSB04"));
        }
        else if (page == Page.TEST)
        {
            Cmd(d.GetCommand("OSB09"));
        }
        else if (page == Page.TFR)
        {
            Cmd(d.GetCommand("OSB17"));
        }
        else if (page == Page.TGP)
        {
            Cmd(d.GetCommand("OSB19"));
        }
        else if (page == Page.WPN)
        {
            Cmd(d.GetCommand("OSB18"));
        }
    }

    private void SetupFCR(Device d, Page page, Mode masterMode, MFDConfiguration mfd)
    {
        if (masterMode == Mode.DGFT) return;

        if (mfd.FCRMode == null) return;

        if (masterMode == Mode.NAV)
        {
            Cmd(UFC.AG);
            Cmd(UFC.AG);
        }

        var mfdSide = d == LMFD ? "left" : "right"; 
        var mode = Enum.GetName(typeof(FCRMode), mfd.FCRMode)!;
        if (mfd.FCRMode == FCRMode.RWS || mfd.FCRMode == FCRMode.TWS || mfd.FCRMode == FCRMode.VSR)
        {
            Cmd(d.GetCommand("OSB01"));
            Cmd(d.GetCommand("OSB20"));
            Cmd(Wait());
            Loop(CRMMode(mfdSide, mode), d.GetCommand("OSB02"), Wait());

            if (mfd.FCRBars != null)
            {
                Cmd(Wait());
                Loop(FCRBars(mfdSide, mfd.FCRBars.Value), d.GetCommand("OSB17"), Wait());
            }
        }
        else if (mfd.FCRMode == FCRMode.GM || mfd.FCRMode == FCRMode.GMT || mfd.FCRMode == FCRMode.SEA)
        {
            Cmd(d.GetCommand("OSB01"));
            if (mfd.FCRMode == FCRMode.GM) Cmd(d.GetCommand("OSB06"));
            if (mfd.FCRMode == FCRMode.GMT) Cmd(d.GetCommand("OSB07"));
            if (mfd.FCRMode == FCRMode.SEA) Cmd(d.GetCommand("OSB08"));
        }

        if (mfd.FCRAzimuth != null)
        {
            Cmd(Wait());
            Loop(FCRAzimuth(mfdSide, mfd.FCRAzimuth.Value), d.GetCommand("OSB18"), Wait());
        }

        if (mfd.FCRRange != null)
        {
            if (mfd.FCRRange == -1)
            {
                Cmd(Wait());
                IfNot(FCRRangeAuto(mfdSide), d.GetCommand("OSB02"));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Cmd(d.GetCommand("OSB19"));
                }

                Cmd(Wait());
                Loop(FCRRange(mfdSide, mfd.FCRRange.Value), d.GetCommand("OSB20"), Wait());
            }
        }
    }

    private Condition CRMMode(string mfd, string mode)
    {
        return new Condition("CRMMode('" + mfd + "','" + mode + "')");
    }

    private Condition FCRBars(string mfd, int bars)
    {
        return new Condition("FCRBars('" + mfd + "','" + bars + "')");
    }

    private Condition FCRAzimuth(string mfd, int az)
    {
        return new Condition("FCRAzimuth('" + mfd + "','" + az + "')");
    }

    private Condition FCRRange(string mfd, int range)
    {
        return new Condition("FCRRange('" + mfd + "','" + range + "')");
    }

    private Condition FCRRangeAuto(string mfd)
    {
        return new Condition("FCRRangeAuto('" + mfd + "')");
    }
}