namespace BLL.Abstractions
{
	public interface INumberGenerator
	{
		int GenerateNumber(int minValue, int maxValue);
	}
}
