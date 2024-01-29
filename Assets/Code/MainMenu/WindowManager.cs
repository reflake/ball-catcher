using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MainMenu.Delegates;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MainMenu
{
	public class WindowManager : MonoBehaviour
	{
		[SerializeField] private HomeWindow homeWindow = default;
		
		public event WindowOpenDelegate OnWindowOpened = null;

		public event WindowFocusedDelegate OnWindowFocused = null;
		public event WindowCloseDelegate OnWindowClosed = null;
		
		private List<IWindow> _cachedWindows = new();
		private List<IWindow> _windowBreadcrumbs = new();
		private IWindow _currentWindow = default;

		private void Awake()
		{
			RegisterWindow(homeWindow);
			Open(homeWindow);
		}

		private void RegisterWindow<TWindow>(TWindow instanceOfWindow) where TWindow : IWindow
		{
			_cachedWindows.Add(instanceOfWindow);
			
			if (instanceOfWindow is ICloseableWindow window)
			{
				window.OnWindowClose += WindowClosed;
			}
		}

		public TWindow Open<TWindow>() where TWindow : Component, IWindow
		{
			TWindow instanceOfWindow;
			
			if (_cachedWindows.Any(x => x.GetType() == typeof(TWindow)))
			{
				instanceOfWindow = _cachedWindows
									.OfType<TWindow>()
									.Single();
			}
			else
			{
				var attribute = typeof(TWindow).GetCustomAttribute<WindowAttribute>();
				var prefab = Addressables.LoadAssetAsync<GameObject>(attribute.Path).WaitForCompletion();
			
				instanceOfWindow = Instantiate(prefab, transform).GetComponent<TWindow>();
				instanceOfWindow.name = nameof(TWindow);
				
				RegisterWindow(instanceOfWindow);
			}
			
			Open(instanceOfWindow);

			return instanceOfWindow;
		}

		private void Open<TWindow>(TWindow instanceOfWindow) where TWindow : Component, IWindow
		{
			_currentWindow?.SetFocused(false);

			// Add window to history list
			_windowBreadcrumbs.Add(_currentWindow);
			
			SetCurrentWindow(instanceOfWindow);

			instanceOfWindow.Open();
			
			OnWindowOpened?.Invoke(instanceOfWindow);
		}

		private void WindowClosed(IWindow window)
		{
			OnWindowClosed?.Invoke(window);
			
			_windowBreadcrumbs.Remove(window);
			
			// Open last window from history list
			if (window == _currentWindow)
			{
				SetCurrentWindow(_windowBreadcrumbs.Last());
			}
		}

		private void SetCurrentWindow(IWindow window)
		{
			_currentWindow = window;
			_currentWindow.SetFocused(true);

			OnWindowFocused?.Invoke(_currentWindow);
		}
	}
}