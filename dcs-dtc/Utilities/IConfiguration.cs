namespace DTC.Utilities;

public interface IConfiguration
{
	string ToJson();
	IConfiguration Clone();
	void AfterLoadFromJson();
}
