using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Data;
using UnityEngine;

namespace Game
{
	public class DemoRecorder : MonoBehaviour
	{
		[SerializeField] private Input _playerInput = null;
		
		private Stream _demoStream = null;
		private BinaryFormatter _demoBinaryFormatter = null;

		private void Awake()
		{
			_demoStream = new MemoryStream();
			_demoBinaryFormatter = new BinaryFormatter();
			
			var info = new DemoInfo(DateTime.Now, UnityEngine.Random.state);
			
			_demoBinaryFormatter.Serialize(_demoStream, info);
		}

		private void OnDestroy()
		{
			_demoStream.Dispose();
		}

		private void Update()
		{
			var cmd = _playerInput.GetCmd();
			
			_demoBinaryFormatter.Serialize(_demoStream, cmd);
		}
	}
}