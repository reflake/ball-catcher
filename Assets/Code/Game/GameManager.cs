using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		private void Awake()
		{
			Random.InitState((int)DateTime.Now.Ticks);
		}

		public void LeaveGame()
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}
}