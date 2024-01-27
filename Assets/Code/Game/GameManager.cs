using System;
using Game.Enum;
using Leaderboard;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameMode _defaultGameMode = GameMode.Survival;
		[SerializeField] private LeaderboardSystem _leaderboardSystem = default;
		[SerializeField] private ScoreManager _scoreManager = default;
		[SerializeField] private Player player = default;

		public GameMode GameMode
		{
			get
			{
				if (_gameMode != null) return _gameMode.Value;

				throw new Exception("Game mode is not set!");
			}
		}

		private GameMode? _gameMode = null;
		
		private void Awake()
		{
			var menuContext = FindFirstObjectByType<MenuContext>();
			
			if (menuContext != null)
				SetGameMode(menuContext.GameMode);
			
			if (!_gameMode.HasValue)
				SetGameMode(_defaultGameMode);
			
			Debug.Log($"Game mode is {GameMode}");
		}

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

		public void SetGameMode(GameMode gameMode)
		{
			_gameMode = gameMode;
		}
	}
}