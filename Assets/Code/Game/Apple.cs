using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public class Apple : MonoBehaviour
	{
		[SerializeField] private Vector2 _speedRange = Vector2.zero;
		[SerializeField] private float _fallingSpeed = 3f;
		
		private ScoreManager _scoreManager;
		private float _rotationSpeed;
		private Vector3 _rotationAxis;

		private void Awake()
		{
			var speed = 

			_rotationAxis = Random.onUnitSphere;
			_rotationSpeed = Random.Range(_speedRange.x, _speedRange.y);
		}

		public void Update()
		{
			transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, _rotationAxis);
			transform.position += Vector3.down * _fallingSpeed * Time.smoothDeltaTime;
		}

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