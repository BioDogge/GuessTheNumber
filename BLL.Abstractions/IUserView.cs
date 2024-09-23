namespace BLL.Abstractions
{
	public interface IUserView
	{
		void ShowMessage(string text);
		string? ReadUsersMessage();
	}
}