using System;

namespace Leaderboard.Local
{
	[Serializable]
	public record LocalEntry(DateTime Date, int Scores, int Time)
	{
		public DateTime Date { get; } = Date;
		public int Scores { get; } = Scores;
		public int Time { get; } = Time; // In seconds
	}
}