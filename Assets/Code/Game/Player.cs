using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(CharacterController))]
	public class Player : MonoBehaviour
	{
		[SerializeField] private float playerSpeed = 4f;
		
		private CharacterController _characterController;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			
			Debug.Assert(_characterController != null);
		}

		private void Update()
		{
			var horizontalAxisValue = Input.GetAxis("Horizontal");
			var axisThreshold = 0.1f;

			if (horizontalAxisValue > axisThreshold)
			{
				Walk(playerSpeed);
			}
			else if (horizontalAxisValue < -axisThreshold)
			{
				Walk(-playerSpeed);
			}
		}

		private void Walk(float velocity)
		{
			var offset = transform.right * velocity;
			
			_characterController.Move(offset * Time.deltaTime);
		}
	}
}