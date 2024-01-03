using UnityEngine;

namespace Game
{
	public class Ball : MonoBehaviour
	{
		private ScoreManager _scoreManager;

		public void Setup(ScoreManager scoreManager)
		{
			_scoreManager = scoreManager;
			
			Debug.Assert(_scoreManager != null);
		}
		
		private void OnTriggerEnter(Collider colliderData)
		{
			if (colliderData.gameObject.CompareTag("Player"))
			{
				_scoreManager.IncrementScore();
			}
			
			Remove();
		}

		// Hit the floor
		private void Remove()
		{
			Destroy(gameObject);
		}
	}
}