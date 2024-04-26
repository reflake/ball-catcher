using UnityEngine;

namespace Game.Collectible
{
	// Heart heals player upon contact
	public class Heart : MonoBehaviour
	{
		[SerializeField] private float _fallingSpeed = 3f;
		[SerializeField] private float _healingAmount = 0.5f;
		
		public void Update()
		{
			transform.position += Vector3.down * _fallingSpeed * Time.smoothDeltaTime;
		}
		
		private void OnTriggerEnter(Collider colliderData)
		{
			var collidedGO = colliderData.gameObject;
			
			if (collidedGO.CompareTag("Player"))
			{
				collidedGO.GetComponent<Player>().Heal(_healingAmount);
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