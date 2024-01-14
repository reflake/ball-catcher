using UnityEngine;

namespace MainMenu
{
	public class BackgroundController : MonoBehaviour
	{
		[SerializeField] private Camera mainCamera = null;
		[SerializeField] private WindowManager windowManager = null;

		private void Awake()
		{
			windowManager.OnWindowFocused += WindowFocused;
		}

		private void WindowFocused(IWindow window)
		{
			if (window is IControlBackColor control)
			{
				mainCamera.backgroundColor = control.BackgroundColor;
			}
		}
	}
}