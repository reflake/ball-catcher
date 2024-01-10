using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Player player = default;
		
		private void Start()
		{
			player.OnLose += GameOver;
		}

		private void GameOver()
		{
			LeaveGame();
		}

		public void LeaveGame()
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}
}