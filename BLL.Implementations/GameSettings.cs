namespace BLL.Implementations
{
	public record GameSettings
	{
		public int MinNumber { get; init; }
		public int MaxNumber { get; init; }
		public int Attempts { get; init; }
	}
}