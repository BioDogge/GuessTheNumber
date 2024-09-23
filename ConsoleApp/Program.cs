using BLL.Abstractions;
using BLL.Implementations;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("settings.json", optional: false, reloadOnChange: true)
			.Build();

			var settings = GetGameSettings(configuration);

			INumberGenerator numberGenerator = new NumberGenerator();
			IUserView userView = new UserView();

			var game = new Game(numberGenerator, userView, settings);
			game.Start();
		}

		private static GameSettings GetGameSettings(IConfigurationRoot configuration)
		{
			var config = configuration.GetRequiredSection("GameSettings");

			var attempts = int.Parse(config[nameof(GameSettings.Attempts)]!);
			var minValue = int.Parse(config[nameof(GameSettings.MinNumber)]!);
			var maxValue = int.Parse(config[nameof(GameSettings.MaxNumber)]!);

			return new GameSettings
			{
				Attempts = attempts,
				MinNumber = minValue,
				MaxNumber = maxValue
			};
		}
	}
}