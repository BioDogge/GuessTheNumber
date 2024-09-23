using BLL.Abstractions;

namespace BLL.Implementations
{
	public class Game
	{
		private readonly INumberGenerator _numberGenerator;
		private readonly IUserView _userView;
		private readonly GameSettings _settings;
		private int _targetValue;

		public Game(INumberGenerator numberGenerator, IUserView userView, GameSettings settings)
		{
			_numberGenerator = numberGenerator;
			_userView = userView;
			_settings = settings;
			_targetValue = numberGenerator.GenerateNumber(settings.MinNumber, settings.MaxNumber);
		}

		public void Start()
		{
			ShowHelloMessage();

			for (var i = 1; i <= _settings.Attempts; i++)
			{
				_userView.ShowMessage("Введите ваше предположение: ");

				if (int.TryParse(_userView.ReadUsersMessage(), out var usersAssumption))
				{
					if (usersAssumption == _targetValue)
					{
						_userView.ShowMessage("Поздравляем! Вы угадали число.");
						return;
					}
					else if (usersAssumption < _targetValue)
						_userView.ShowMessage("Загаданное число больше.");
					else
						_userView.ShowMessage("Загаданное число меньше.");
				}
				else
					_userView.ShowMessage("Пожалуйста, введите корректное число.");
			}

			_userView.ShowMessage($"Вы проиграли. Загаданное число было: {_targetValue}.");
		}

		private void ShowHelloMessage()
		{
			const string FIRST_MESSAGE = "**Добро пожаловать в игру \"Угадай число\"!**";

			var numberRangeMessage = $"Диапазон чисел: от {_settings.MinNumber} до {_settings.MaxNumber}.\n";
			var attemptsMessage = $"Количество ваших попыток: {_targetValue}.";

			var helloMessage = FIRST_MESSAGE + numberRangeMessage + attemptsMessage;

			_userView.ShowMessage(helloMessage);
		}
	}
}