using UnityEngine;

namespace Game
{
	public class ScoreManager : MonoBehaviour
	{
		public delegate void ScoreUpdateDelegate(int newScore);
		
		[SerializeField] private int currentScore = 0;

		public event ScoreUpdateDelegate OnScoreUpdate = default;

		public int CurrentScore => currentScore;
		
		public void IncrementScore()
		{
			currentScore++;
			
			OnScoreUpdate?.Invoke(currentScore);
		}
	}
}