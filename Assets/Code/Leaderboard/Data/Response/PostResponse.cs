namespace Leaderboard.Responses
{
	public record PostResponse
	{
		public bool Faulted { get; set; } = false;
		
		public int? Id { get; set; }
		public string? ErrorMessage { get; set; }
	}
}