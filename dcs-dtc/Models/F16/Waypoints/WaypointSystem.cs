using System.Collections.Generic;

namespace DTC.Models.F16.Waypoints
{
	public class WaypointSystem
	{
		public List<Waypoint> Waypoints { get; set; }

		public WaypointSystem()
		{
			Waypoints = new List<Waypoint>();
		}

		public Waypoint Add(Waypoint wpt)
		{
			var seq = Waypoints.Count + 1;
			wpt.Sequence = seq;
			Waypoints.Add(wpt);
			return wpt;
		}

		public void Remove(Waypoint wpt)
		{
			Waypoints.Remove(wpt);
			RecalculateSequence();
		}

		public void Reorder(int idxFrom, int idxTo)
		{
			var wpt = Waypoints[idxFrom];
			Waypoints.Remove(wpt);
			Waypoints.Insert(idxTo, wpt);
			RecalculateSequence();
		}

		private void RecalculateSequence()
		{
			for (int i = 0; i < Waypoints.Count; i++)
			{
				Waypoint wpt = Waypoints[i];
				wpt.Sequence = i + 1;
			}
		}
	}
}
