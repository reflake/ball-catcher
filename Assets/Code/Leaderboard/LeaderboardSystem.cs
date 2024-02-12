using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Leaderboard.Entities;
using Leaderboard.Local;
using Leaderboard.Remote;
using Leaderboard.Responses;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Leaderboard
{
	public class LeaderboardSystem : MonoBehaviour
	{
		public IReadOnlyCollection<Record> Local => _local.Entries;
		public UniTask<IReadOnlyCollection<Record>> Global => _remote.GetEntries();

		private LocalDatabase _local = null;
		private RemoteDatabase _remote = null;

		private void Awake()
		{
			_local = new LocalDatabase();
			_remote = new RemoteDatabase();
		}

		public void AddLocalEntry(string nickname, int scores, int time)
		{
			_local.AddEntry(nickname, scores, time);
		}

		public UniTask<bool> PostGlobalEntry(string nickname, int scores, int time)
		{
			return _remote.PostEntry(nickname, scores, time);
		}

		private void OnDestroy()
		{
			_local.Flush();
		}
	}
}