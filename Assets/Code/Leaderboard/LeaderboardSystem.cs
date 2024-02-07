using System.Collections.Generic;
using UnityEngine;

namespace Leaderboard
{
	public class LeaderboardSystem : MonoBehaviour
	{
		public IReadOnlyCollection<LocalEntry> Entries => _local.Entries;
		
		private LocalDatabase _local = null;

		private void Awake()
		{
			_local = new LocalDatabase();
		}

		public void AddEntry(int scores, int time)
		{
			_local.AddEntry(scores, time);
		}

		private void OnDestroy()
		{
			_local.Flush();
		}
	}
}