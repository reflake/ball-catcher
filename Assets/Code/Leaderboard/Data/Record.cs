using System;

namespace Leaderboard.Entities
{
	[Serializable]
	public class Record
	{
		public int Id { get; set; }
		public int Scores { get; set; }
		public int Time { get; set; }
		public DateTime DateTime { get; set; }
		public string Nickname { get; set; } = string.Empty;

		public string? UserId { get; set; }
	}
}