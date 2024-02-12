using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Leaderboard.Entities;
using UnityEngine;

namespace Leaderboard.Local
{
	public class LocalDatabase
	{
		public string LocalLeaderboardDataPath => Path.Combine(Application.persistentDataPath, "records.bin");
		public IReadOnlyCollection<Record> Entries => _entries;

		private List<Record> _entries = new();
		private int _version = 1_00;
		private bool _dirty = false;

		public LocalDatabase()
		{
			if (!File.Exists(LocalLeaderboardDataPath))
				return;
			
			var fileDataBytes = File.ReadAllBytes(LocalLeaderboardDataPath);
			
			using (var fileDataStream = new MemoryStream(fileDataBytes))
			{
				var formatter = new BinaryFormatter();
				var header = (LocalDataHeader)formatter.Deserialize(fileDataStream);

				if (header.Version > _version)
				{
					throw new Exception("Unsupported leaderboard data version!");
				}

				_entries = new ();
			
				for (int i = 0; i < header.NumberOfEntries; i++)
				{
					_entries.Add((Record)formatter.Deserialize(fileDataStream));
				}
			}
		}

		public void AddEntry(string nickname, int scores, int time)
		{
			// Do not add entry if scores is lower than the highest score
			if (_entries.Count > 0 && _entries.Select(r => r.Scores).Max() >= scores)
			{
				return;
			}
			
			var dateTime = DateTime.Now;

			_dirty = true;
			_entries.Add(new Record
			{
				Nickname = nickname,
				DateTime = dateTime,
				Scores = scores,
				Time = time
			});
		}

		public void Flush()
		{
			if (!_dirty)
				return;
			
			// Update records file
			using (var fileStream = new FileStream(LocalLeaderboardDataPath, FileMode.Create, FileAccess.Write))
			{
				var formatter = new BinaryFormatter();

				formatter.Serialize(fileStream, new LocalDataHeader(_version, _entries.Count));

				foreach (var entry in _entries)
				{
					formatter.Serialize(fileStream, entry);
				}
			}
		}
	}
}