using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class HeartIcon : MonoBehaviour
	{
		[SerializeField] private Image fillImage = null;

		public void SetFillLevel(float percentage)
		{
			fillImage.fillAmount = percentage * 0.01f;
		}
	}
}