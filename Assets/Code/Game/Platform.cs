using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class Platform : MonoBehaviour
	{
		private IEnumerable<Player> _players = null;

		private void Awake()
		{
			_players = GameObject
				.FindGameObjectsWithTag("Player")
				.Select(p => p.GetComponent<Player>());
		}

		public void AppleHit()
		{
			foreach (var player in _players)
			{
				player.TakeDamage(.5f);
			}
		}
	}
}