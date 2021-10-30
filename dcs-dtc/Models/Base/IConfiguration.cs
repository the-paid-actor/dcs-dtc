namespace DTC.Models.Base
{
	public interface IConfiguration
	{
		string ToJson();
		IConfiguration Clone();
	}
}
