using BLL.Abstractions;
using BLL.Implementations;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

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
			var settings = configuration.GetSection("GameSettings").Value;

			return settings is not null
				? JsonSerializer.Deserialize<GameSettings>(settings)!
				: new GameSettings();
		}
	}
}