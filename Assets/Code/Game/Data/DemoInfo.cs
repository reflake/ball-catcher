using System;
using Random = UnityEngine.Random;

namespace Game.Data
{
	[Serializable]
	public record DemoInfo(DateTime DateTime, Random.State RandomState)
	{
		public DateTime DateTime { get; } = DateTime;
		public Random.State RandomState { get; } = RandomState;
	}
}