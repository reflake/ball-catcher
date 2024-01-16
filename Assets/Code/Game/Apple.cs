using UnityEngine;

namespace Game
{
	public class Apple : MonoBehaviour
	{
		private ScoreManager _scoreManager;

		public void Setup(ScoreManager scoreManager)
		{
			_scoreManager = scoreManager;
			
			Debug.Assert(_scoreManager != null);
		}
		
		private void OnTriggerEnter(Collider colliderData)
		{
			var collidedGO = colliderData.gameObject;
			
			if (collidedGO.CompareTag("Player"))
			{
				_scoreManager.IncrementScore();
			}
			else if (collidedGO.CompareTag("Platform"))
			{
				var platform = collidedGO.GetComponent<Platform>();
				
				platform.AppleHit();
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