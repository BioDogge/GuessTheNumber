using BLL.Abstractions;

namespace BLL.Implementations
{
	public class NumberGenerator : INumberGenerator
	{
		private readonly Random _random = new();

		public int GenerateNumber(int minValue, int maxValue)
		{
			return _random.Next(minValue, maxValue + 1);
		}
	}
}