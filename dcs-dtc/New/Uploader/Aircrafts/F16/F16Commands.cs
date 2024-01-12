
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    private Condition IsLeftHdptNotOn()
    {
        return new Condition("LeftHdptNotOn()");
    }

    private Condition IsRightHdptNotOn()
    {
        return new Condition("RightHdptNotOn()");
    }

    private Condition IsRadioNotBoth()
    {
        return new Condition("RadioNotBoth()");
    }

    private Condition IsVIPtoTGTNotSelected()
    {
        return new Condition("VIP_TO_TGT_NotSelected()");
    }

    private Condition IsVIPtoTGTNotHighlighted()
    {
        return new Condition("VIP_TO_TGT_NotHighlighted()");
    }

    private Condition IsVIPtoPUPNotHighlighted()
    {
        return new Condition("VIP_TO_PUP_NotHighlighted()");
    }

    private Condition IsTGTtoVRPNotSelected()
    {
        return new Condition("TGT_TO_VRP_NotSelected()");
    }

    private Condition IsTGTtoVRPNotHighlighted()
    {
        return new Condition("TGT_TO_VRP_NotHighlighted()");
    }

    private Condition IsTGTtoPUPNotHighlighted()
    {
        return new Condition("TGT_TO_PUP_NotHighlighted()");
    }

    private Condition IsBullseyeNotSelected()
    {
        return new Condition("BullseyeNotSelected()");
    }

    private Condition IsTACANBandX()
    {
        return new Condition("TACANBandX()");
    }

    private Condition IsTACANBandY()
    {
        return new Condition("TACANBandY()");
    }

    private Condition IsTACANNotTR()
    {
        return new Condition("TACANNotTR()");
    }

    private Condition IsNotNAVMode()
    {
        return new Condition("NotNAVMode()");
    }

    private Condition IsHARMEnabled()
    {
        return new Condition("HARM()");
    }

    private Condition IsHTSEnabled()
    {
        return new Condition("HTSOnDED()");
    }

    private Condition IsInCRMMode(string mfd, string mode)
    {
        return new Condition("InCRMMode('" + mfd + "','" + mode + "')");
    }

    private Condition IsFCRBars(string mfd, int bars)
    {
        return new Condition("FCRBars('" + mfd + "','" + bars + "')");
    }

    private Condition IsFCRAz(string mfd, int az)
    {
        return new Condition("FCRAz('" + mfd + "','" + az + "')");
    }

    private Condition IsFCRRange(string mfd, int range)
    {
        return new Condition("FCRRange('" + mfd + "','" + range + "')");
    }

    private Condition IsNotAuto(string mfd)
    {
        return new Condition("NotAuto('" + mfd + "')");
    }

    private Condition FirstCallSignLetter(string letter)
    {
        return new Condition("FirstCallSignLetter('" + letter + "')");
    }

    private Condition SecondCallSignLetter(string letter)
    {
        return new Condition("SecondCallSignLetter('" + letter + "')");
    }

    private Condition FlightLead(string status)
    {
        return new Condition("FlightLead('" + status + "')");
    }

    private Condition TDOA(string position, string status)
    {
        return new Condition("FlightLead('" + position + "','" + status + "')");
    }

    private CustomCommand EnableXMIT(string data)
    {
        return new CustomCommand("EnableXMIT(" + data + ")");
    }

    private CustomCommand BuildHTSMFD(string data)
    {
        return new CustomCommand("BuildHTSMFD(" + data + ")");
    }
}