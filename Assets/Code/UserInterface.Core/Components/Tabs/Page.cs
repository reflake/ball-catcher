using UnityEngine;

namespace MainMenu.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class Page : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		public void SetSelected(bool value)
		{
			_canvasGroup.alpha = value ? 1 : 0;
			_canvasGroup.blocksRaycasts = value;
		}
	}
}