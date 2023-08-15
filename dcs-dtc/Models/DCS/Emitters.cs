using DTC.Utilities;

namespace DTC.Models.DCS
{
	public static class Emitters
	{
		private static Emitter[] emitters;

		public static Emitter[] EmittersList
		{
			get
			{
				if (emitters == null)
				{
					emitters = FileStorage.LoadEmitters();
				}
				return emitters;
			}
		}
	}

	public class Emitter
	{
		public string Country { get; set; }
		public int HARMCode { get; set; }
		public int HTSTable { get; set; }
		public string F16RWR { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string NATO { get; set; }

		public override string ToString()
		{
			return $"{F16RWR} - {Name}";
		}
	}
}
