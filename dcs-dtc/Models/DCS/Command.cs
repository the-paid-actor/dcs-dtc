namespace DTC.Models.DCS
{
	public class Command
	{
		public readonly int ID;
		public readonly string Name;
		public readonly int Delay;
		public readonly int Activate;

		public Command(int id, string name, int delay, int activate)
		{
			ID = id;
			Name = name;
			Delay = delay;
			Activate = activate;
		}
	}
}
