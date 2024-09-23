using BLL.Abstractions;

namespace BLL.Implementations
{
	public class UserView : IUserView
	{
		public string? ReadUsersMessage() => Console.ReadLine();

		public void ShowMessage(string text) => Console.WriteLine(text);
	}
}