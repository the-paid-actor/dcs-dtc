using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.UI.Base;

internal abstract class WaypointCapture<T, U> where T : IWaypoint where U : IWaypointSystem<T>
{
    protected void CommonAddWaypoint(T wpt, WaypointCaptureSystem capt, U wptSystem)
    {
        if (!wpt.Target)
        {
            if (capt.NavPointsMode == SteerpointCaptureMode.AddToEndOfList)
            {
                wpt.Sequence = wptSystem.GetNextSequence();
                if (wpt.Sequence == 0) wpt.Sequence = 1;
            }
            else if (capt.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
            {
                wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                if (wpt.Sequence == 0) wpt.Sequence = 1;
            }
            else if (capt.NavPointsMode == SteerpointCaptureMode.AddToRange)
            {
                wpt.Sequence = wptSystem.GetNextSequenceFromSequence(capt.NavPointsRangeFrom);
            }
            wpt.Name = "STPT " + wpt.Sequence;
            wptSystem.Add(wpt);
        }
        else
        {
            if (capt.TgtPointsMode == SteerpointCaptureMode.AddToEndOfList)
            {
                wpt.Sequence = wptSystem.GetNextSequence();
                if (wpt.Sequence == 0) wpt.Sequence = 1;
            }
            else if (capt.TgtPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
            {
                wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                if (wpt.Sequence == 0) wpt.Sequence = 1;
            }
            else if (capt.TgtPointsMode == SteerpointCaptureMode.AddToRange)
            {
                wpt.Sequence = wptSystem.GetNextSequenceFromSequence(capt.TgtPointsRangeFrom);
            }
            wpt.Name = "TGT " + wpt.Sequence;
            wptSystem.Add(wpt);
        }
    }
}
