using UnityEngine;

namespace MainMenu
{
	public class HomeWindow : MonoBehaviour, IWindow, IControlBackColor
	{
		[SerializeField] private CanvasGroup canvasGroup = default;
		[SerializeField] private Color backgroundColor;
		
		public Color BackgroundColor => backgroundColor;

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