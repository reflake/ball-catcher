using UnityEngine;

namespace MainMenu
{
	public class HomeWindow : MonoBehaviour, IWindow
	{
		[SerializeField] private CanvasGroup canvasGroup = default;

		public void Open()
		{
			SetFocused(true);
		}

		public void SetFocused(bool value)
		{
			canvasGroup.alpha = value ? 1 : 0;
			canvasGroup.blocksRaycasts = value;
		}
	}
}