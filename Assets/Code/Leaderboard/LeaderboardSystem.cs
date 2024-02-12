using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Cysharp.Threading.Tasks;
using Leaderboard.Entities;
using Leaderboard.Local;
using Leaderboard.Responses;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Leaderboard
{
	public class LeaderboardSystem : MonoBehaviour
	{
		public const string ApiUrl = "http://localhost:5044";
		public IReadOnlyCollection<LocalEntry> Entries => _local.Entries;
		
		private LocalDatabase _local = null;

		private void Awake()
		{
			_local = new LocalDatabase();
		}

		public void AddLocalEntry(int scores, int time)
		{
			_local.AddEntry(scores, time);
		}

		public async UniTask<bool> PostGlobalEntry(string nickname, int scores, int time)
		{
			var entry = new Record
			{
				DateTime = DateTime.Now,
				Nickname = nickname,
				Scores = scores,
				Time = time
			};
			const string contentType = "application/json; charset=utf-8";
			var postData = JsonConvert.SerializeObject(entry, new JsonSerializerSettings
			{
				DateTimeZoneHandling = DateTimeZoneHandling.Utc
			});

			var response = await UnityWebRequest
				.Post($"{ApiUrl}/Leaderboard", postData, contentType)
				.SendWebRequest();

			if (response.responseCode != 200)
			{
				throw new Exception($"Code: {response.responseCode}, Error: {response.error}");
			}

			var stringData = response.downloadHandler.text;
			var data = JsonUtility.FromJson<PostResponse>(stringData);

			return !data.Faulted;
		}

		private void OnDestroy()
		{
			_local.Flush();
		}
	}
}