using System.Collections.Generic;

namespace DTC.Models.DCS
{
	public class Device
	{
		public readonly int ID;
		public readonly string Name;
		public readonly Dictionary<string, Command> Commands = new Dictionary<string, Command>();

		public Device(int id, string name)
		{
			this.ID = id;
			this.Name = name;
		}

		public void AddCommand(Command cmd)
		{
			Commands.Add(cmd.Name, cmd);
		}

		public string GetCommand(string cmdName)
		{
			var cmd = Commands[cmdName];
			var activate = ("" + cmd.Activate + "").Replace(",",".");
			var str = "{'device': '" + ID + "', 'code': '" + cmd.ID + "', 'delay': '" + cmd.Delay + "', 'activate': '" + activate + "'},";
			return str.Replace("'", "\"");
		}
	}
}
