using System;

namespace Leaderboard.Local
{
	[Serializable]
	public record LocalDataHeader(int Version, int NumberOfEntries)
	{
		public int Version { get; } = Version;
		public int NumberOfEntries { get; } = NumberOfEntries;
	}
}