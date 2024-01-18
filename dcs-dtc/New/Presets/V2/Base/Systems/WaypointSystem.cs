using DTC.Utilities.Extensions;

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
        var seq = GetNextSequence();
        return new T()
        {
            Sequence = seq,
            Name = "STPT " + seq,
        };
    }

    protected abstract int GetFirstSequence();

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
        var block = GetSequenceBlock(startIdx);
        Waypoints.Remove(wpt);
        block.End--;
        Renumerate(block);
    }

    public int GetNextSequence()
    {
        var seq = GetFirstSequence() - 1;
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
        var seq = GetFirstSequence() - 1;
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

    private void Renumerate(Block block)
    {
        var startSeq = block.StartSeq;
        for (var i = block.Start; i <= block.End; i++)
        {
            var wpt = Waypoints[i];
            wpt.Sequence = startSeq++;
        }
    }

    internal void Reorder(int from, int between1, int between2)
    {
        var src = this.Waypoints[from];
        var blockSource = GetSequenceBlock(from);

        T tgtBefore = null;
        T tgtAfter = null;
        Block blockBefore = null;
        Block blockAfter = null;

        if (this.Waypoints.InBounds(between1))
        {
            tgtBefore = this.Waypoints[between1];
            blockBefore = GetSequenceBlock(between1);
        }
        if (this.Waypoints.InBounds(between2))
        {
            tgtAfter = this.Waypoints[between2];
            blockAfter = GetSequenceBlock(between2);
        }

        if (blockSource.Equals(blockBefore) || blockSource.Equals(blockAfter))
        {
            this.Waypoints.Remove(src);
            if (tgtBefore != null)
            {
                this.Waypoints.InsertAfter(src, tgtBefore);
            }
            else if (tgtAfter != null)
            {
                this.Waypoints.InsertBefore(src, tgtAfter);
            }
            Renumerate(blockSource);
        }
        else
        {
            this.Waypoints.Remove(src);
            blockSource.End--;
            Renumerate(blockSource);

            if (tgtAfter != null)
            {
                this.Waypoints.InsertBefore(src, tgtAfter);
                if (blockSource.End < blockAfter.Start)
                {
                    blockAfter.Start--;
                }
                else
                {
                    blockAfter.End++;
                }
                Renumerate(blockAfter);
            }
            else if (tgtBefore != null)
            {
                this.Waypoints.InsertAfter(src, tgtBefore);
                blockBefore.Start--;
                Renumerate(blockBefore);
            }

        }
    }

    private class Block : IEquatable<Block>
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int StartSeq { get; set; }
        public int EndSeq { get; set; }

        public bool Equals(WaypointSystem<T>.Block? other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Start == other.Start && this.End == other.End;
        }
    }

    private Block GetSequenceBlock(int from)
    {
        var start = 0;
        var end = 0;
        
        for (var i = from; i > -1; i--)
        {
            var seq = this.Waypoints[i].Sequence;
            start = i;
            if (i > 0 && this.Waypoints[i - 1].Sequence < seq - 1)
            {
                break;
            }
        }

        for (var i = from; i < this.Waypoints.Count; i++)
        {
            var seq = this.Waypoints[i].Sequence;
            end = i;
            if (i < this.Waypoints.Count - 1 && this.Waypoints[i + 1].Sequence > seq + 1)
            {
                break;
            }
        }

        var startSeq = this.Waypoints[start].Sequence;
        var endSeq = this.Waypoints[end].Sequence;

        return new Block { Start = start, End = end, StartSeq = startSeq, EndSeq = endSeq };
    }
}
