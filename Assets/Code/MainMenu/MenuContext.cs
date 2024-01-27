using Game.Enum;
using UnityEngine;

namespace MainMenu
{
	public class MenuContext : MonoBehaviour
	{
		public GameMode GameMode { get; set; }

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}