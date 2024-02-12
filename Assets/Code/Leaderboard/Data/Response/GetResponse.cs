using Leaderboard.Entities;

namespace Leaderboard.Responses
{
	public record GetResponse
	{
		public Record Entry { get; set; } = null;
		public Record[] Entries { get; set; } = null;
	}
}