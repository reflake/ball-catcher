using TMPro;
using UnityEngine;

namespace Game.UI
{
	public class ScorePanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text scoreLabel = default;
		
		private ScoreManager _scoreManager = default;

		private void Awake()
		{
			_scoreManager = GameObject.FindFirstObjectByType<ScoreManager>();
			
			Debug.Assert(_scoreManager != null);

			_scoreManager.OnScoreUpdate += UpdateScore;
			
			UpdateScore(_scoreManager.CurrentScore);
		}

		private void UpdateScore(int score)
		{
			scoreLabel.text = $"SCORE: {score}";
		}
	}
}