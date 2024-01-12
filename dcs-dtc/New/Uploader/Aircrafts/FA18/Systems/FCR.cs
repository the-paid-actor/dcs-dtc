using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildFCR()
    {
        if (!config.Upload.FCR ||
            config.FCR == null)
        {
            return;
        }

        Cmd(HOTAS.AMRAAM);

        Cmd(RMFD.OSB16); //DATA
        Loop(FCRDeclutter(Enum.GetName(typeof(FCRDeclutterMode), config.FCR.DeclutterMode)), RMFD.OSB17);
        If(FCRRWRBoxed(config.FCR.EnableRWR), RMFD.OSB05);
        If(FCRBRABoxed(config.FCR.EnableBRA), RMFD.OSB19);
        Cmd(RMFD.OSB16); //DATA

        Loop(FCRRange(config.FCR.AMRAAMSettings.Range), RMFD.OSB11);
        Loop(FCRBars(config.FCR.AMRAAMSettings.Bars), RMFD.OSB06);
        Loop(FCRAzimuth(config.FCR.AMRAAMSettings.Azimuth), RMFD.OSB19);
        Loop(FCRPRF(Enum.GetName(typeof(FCRPRFMode), config.FCR.AMRAAMSettings.PRF)), RMFD.OSB01);
        Cmd(RMFD.OSB16); //DATA
        Loop(FCRAging(config.FCR.AMRAAMSettings.Aging), RMFD.OSB10);
        Cmd(RMFD.OSB16); //DATA
        Cmd(RMFD.OSB13); //SET
        Cmd(Wait(3000));

        Cmd(HOTAS.SPARROW);
        Loop(FCRRange(config.FCR.AIM7Settings.Range), RMFD.OSB11);
        Loop(FCRBars(config.FCR.AIM7Settings.Bars), RMFD.OSB06);
        Loop(FCRAzimuth(config.FCR.AIM7Settings.Azimuth), RMFD.OSB19);
        Loop(FCRPRF(Enum.GetName(typeof(FCRPRFMode), config.FCR.AIM7Settings.PRF)), RMFD.OSB01);
        Cmd(RMFD.OSB16); //DATA
        Loop(FCRAging(config.FCR.AIM7Settings.Aging), RMFD.OSB10);
        Cmd(RMFD.OSB16); //DATA
        Cmd(RMFD.OSB13); //SET
        Cmd(Wait(3000));

        Cmd(HOTAS.SIDEWINDER);
        Loop(FCRRange(config.FCR.AIM9Settings.Range), RMFD.OSB11);
        Loop(FCRBars(config.FCR.AIM9Settings.Bars), RMFD.OSB06);
        Loop(FCRAzimuth(config.FCR.AIM9Settings.Azimuth), RMFD.OSB19);
        Loop(FCRPRF(Enum.GetName(typeof(FCRPRFMode), config.FCR.AIM9Settings.PRF)), RMFD.OSB01);
        Cmd(RMFD.OSB16); //DATA
        Loop(FCRAging(config.FCR.AIM9Settings.Aging), RMFD.OSB10);
        Cmd(RMFD.OSB16); //DATA
        Cmd(RMFD.OSB13); //SET
        Cmd(Wait(3000));

        Cmd(SMS.AA);
    }

    private Condition FCRAging(int aging)
    {
        return new Condition($"FCRAging('{aging}')");
    }

    private Condition FCRPRF(string v)
    {
        return new Condition($"FCRPRF('{v}')");
    }

    private Condition FCRAzimuth(int azimuth)
    {
        return new Condition($"FCRAzimuth('{azimuth}')");
    }

    private Condition FCRBars(int bars)
    {
        return new Condition($"FCRBars('{bars}')");
    }

    private Condition FCRRange(int range)
    {
        return new Condition($"FCRRange('{range}')");
    }

    private Condition FCRBRABoxed(bool enableBRA)
    {
        return new Condition($"FCRBRABoxed({enableBRA.ToString().ToLower()})");
    }

    private Condition FCRRWRBoxed(bool enableRWR)
    {
        return new Condition($"FCRRWRBoxed({enableRWR.ToString().ToLower()})");
    }

    private Condition FCRDeclutter(string declutterMode)
    {
        return new Condition($"FCRDeclutter('{declutterMode}')");
    }
}