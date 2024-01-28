using System;
using System.Linq;
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
		[SerializeField] private Timer timer = default;
		[SerializeField] private Player player = default;
		[SerializeField] private Spawner[] spawnerPrefabs = default;

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
			
			// Each game mode has its own spawner with their own parameters
			var gameModeSpawnerPrefab = spawnerPrefabs
				.Single(spawnerPrefab => spawnerPrefab.TargetGameMode == GameMode);

			Instantiate(gameModeSpawnerPrefab);
		}

		private void Start()
		{
			// Player can't lose in rush mode!
			if (GameMode != GameMode.Rush)
				
				player.OnLose += GameOver;

			// Launch timer for Rush mode
			if (GameMode == GameMode.Rush)
			{
				timer.LaunchCountdown(2 * 60);
				timer.OnCountdownComplete += GameOver;
			}
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