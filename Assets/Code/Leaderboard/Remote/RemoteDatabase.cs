using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Leaderboard.Entities;
using Leaderboard.Responses;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Leaderboard.Remote
{
	public class RemoteDatabase
	{
		public const string ApiUrl = "http://localhost:5044";
		
		public async UniTask<IReadOnlyCollection<Record>> GetEntries()
		{
			var response = await UnityWebRequest
				.Get($"{ApiUrl}/Leaderboard?count=10")
				.SendWebRequest();

			if (response.responseCode != 200)
			{
				throw new Exception($"Code: {response.responseCode}, Error: {response.error}");
			}
			
			var stringData = response.downloadHandler.text;
			var data = JsonConvert.DeserializeObject<GetResponse>(stringData,
				new JsonSerializerSettings
			{
				DateTimeZoneHandling = DateTimeZoneHandling.Utc
			});

			return data.Entries;
		}

		public async UniTask<bool> PostEntry(string nickname, int scores, int time)
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
			var data = JsonConvert.DeserializeObject<PostResponse>(stringData);

			return !data.Faulted;
		}
	}
}