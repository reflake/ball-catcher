using System;

namespace Leaderboard
{
	[Serializable]
	public record LocalDataHeader(int Version, int NumberOfEntries)
	{
		public int Version { get; } = Version;
		public int NumberOfEntries { get; } = NumberOfEntries;
	}
}