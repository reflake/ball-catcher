using Leaderboard;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private LeaderboardSystem _leaderboardSystem = default;
		[SerializeField] private ScoreManager _scoreManager = default;
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
			int timeElapsed = (int)Time.timeSinceLevelLoad;
			int currentScores = _scoreManager.CurrentScore;

			_leaderboardSystem.AddEntry(currentScores, timeElapsed);
			
			SceneManager.LoadScene("MainMenuScene");
		}
	}
}