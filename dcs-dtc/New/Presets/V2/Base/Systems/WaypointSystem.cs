namespace DTC.New.Presets.V2.Base.Systems;

public interface IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }
    public string ExtraDescription { get; }
}

public abstract class WaypointSystem<T> where T : class, IWaypoint, new()
{
    public List<T> Waypoints { get; set; } = new();

    public T NewWaypoint()
    {
        return new T()
        {
            Sequence = GetNextSequence()
        };
    }

    public void Add(T wpt)
    {
        Waypoints.Add(wpt);
    }

    public void ReorderBySequence()
    {
        Waypoints = Waypoints.OrderBy(w => w.Sequence).ToList();
    }

    public bool IsEqual(IWaypoint a, IWaypoint b)
    {
        return
            a.Sequence == b.Sequence &&
            a.Name == b.Name &&
            a.Latitude == b.Latitude &&
            a.Longitude == b.Longitude &&
            a.Elevation == b.Elevation &&
            a.TimeOverSteerpoint == b.TimeOverSteerpoint &&
            a.Target == b.Target;
    }

    public void Remove(T wpt)
    {
        var startIdx = Waypoints.IndexOf(wpt);
        Waypoints.Remove(wpt);

        ReSequence(startIdx, wpt.Sequence, false);
    }

    private int ReSequence(int startIdx, int sequence, bool increment)
    {
        var lastIdx = -1;
        var prevSeq = sequence;

        for (var i = startIdx; i < Waypoints.Count; i++)
        {
            var w = Waypoints[i];
            if (w.Sequence <= prevSeq + 1)
            {
                prevSeq = w.Sequence;
                lastIdx = i;
            }
            else
            {
                break;
            }
        }

        if (lastIdx != -1)
        {
            for (var i = startIdx; i <= lastIdx; i++)
            {
                Waypoints[i].Sequence += increment ? 1 : -1;
            }
        }

        return lastIdx;
    }

    public int GetNextSequence()
    {
        var seq = 0;
        foreach (var wpt in Waypoints)
        {
            if (wpt.Sequence > seq)
            {
                seq = wpt.Sequence;
            }
        }

        return seq + 1;
    }

    internal int GetNextSequenceOfFirstGap()
    {
        var seq = 0;
        for (int i = 0; i < Waypoints.Count; i++)
        {
            var wpt = Waypoints[i];
            var next = i < Waypoints.Count - 1 ? Waypoints[i + 1] : null;
            if (next != null && next.Sequence > wpt.Sequence + 1)
            {
                return wpt.Sequence + 1;
            }
            else if (wpt.Sequence > seq)
            {
                seq = wpt.Sequence;
            }
        }
        return seq + 1;
    }
    internal int GetNextSequenceFromSequence(int navPointsRangeFrom)
    {
        var seq = navPointsRangeFrom;
        foreach (var wpt in Waypoints)
        {
            if (wpt.Sequence < seq) continue;

            if (wpt.Sequence == seq)
            {
                seq++;
            }
        }
        return seq;
    }

    public T? GetBySequence(int seq)
    {
        return Waypoints.FirstOrDefault(w => w.Sequence == seq);
    }

    public bool IsSequenceInUse(int value, T? wptToExclude = null)
    {
        foreach (T wpt in Waypoints)
        {
            if (wpt != wptToExclude && wpt.Sequence == value)
            {
                return true;
            }
        }
        return false;
    }

    internal void ShiftSequence(T other, int seqStart)
    {
        var idx = Waypoints.IndexOf(other);
        for (var i = idx; i < Waypoints.Count; i++)
        {
            var thisWp = Waypoints[i];
            var prevWp = i > 0 ? Waypoints[i - 1] : null;
            if (i == idx || prevWp == null || thisWp.Sequence <= prevWp.Sequence)
            {
                Waypoints[i].Sequence = seqStart++;
            }
            else
            {
                break;
            }
        }
    }

    internal int FirstSequence()
    {
        return Waypoints.First().Sequence;
    }

    internal int LastSequence()
    {
        return Waypoints.Last().Sequence;
    }

    internal void ShiftUp(int[] rows)
    {
        for (var i = rows[0]; i <= rows[rows.Length - 1]; i++)
        {
            var wpt = Waypoints[i];
            var newSeq = wpt.Sequence;
            if (i > 0)
            {
                var prevWpt = Waypoints[i - 1];
                if (prevWpt.Sequence == wpt.Sequence - 1)
                {
                    continue;
                }
            }

            newSeq -= 1;
            if (newSeq < 1)
            {
                newSeq = 1;
            }
            wpt.Sequence = newSeq;
        }
    }

    internal void ShiftDown(int[] rows)
    {
        for (var i = rows[rows.Length - 1]; i >= rows[0]; i--)
        {
            var wpt = Waypoints[i];
            var newSeq = wpt.Sequence;
            if (i < Waypoints.Count - 1)
            {
                var nextWpt = Waypoints[i + 1];
                if (nextWpt.Sequence == wpt.Sequence + 1)
                {
                    continue;
                }
            }

            newSeq += 1;
            wpt.Sequence = newSeq;
        }
    }
}
