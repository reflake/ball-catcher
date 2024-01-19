using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
	public class BackgroundController : MonoBehaviour
	{
		[SerializeField] private Image backgroundImage = null;
		[SerializeField] private WindowManager windowManager = null;

		private void Awake()
		{
			windowManager.OnWindowFocused += WindowFocused;
		}

		private void WindowFocused(IWindow window)
		{
			if (window is IControlBackColor control)
			{
				backgroundImage.color = control.BackgroundColor;
			}
			else
			{
				backgroundImage.color = Color.clear;
			}
		}
	}
}