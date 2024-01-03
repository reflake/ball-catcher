using UnityEngine;

namespace Game
{
	public class Ball : MonoBehaviour
	{
		private void OnCollisionEnter(Collision _)
		{
			Remove();
		}

		// Hit the floor
		private void Remove()
		{
			Destroy(gameObject);
		}
	}
}