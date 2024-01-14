using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MainMenu
{
	public class WindowManager : MonoBehaviour
	{
		private List<object> _cachedWindows = new();
		
		public void Open<TWindow>() where TWindow : Component, IWindow
		{
			TWindow instanceOfWindow;
			
			if (_cachedWindows.Any(x => x.GetType() == typeof(TWindow)))
			{
				instanceOfWindow = _cachedWindows
									.Cast<TWindow>()
									.Single();
			}
			else
			{
				var attribute = typeof(TWindow).GetCustomAttribute<WindowAttribute>();
				var prefab = Addressables.LoadAssetAsync<GameObject>(attribute.Path).WaitForCompletion();
			
				instanceOfWindow = Instantiate(prefab, transform).GetComponent<TWindow>();
				instanceOfWindow.name = nameof(TWindow);
			
				_cachedWindows.Add(instanceOfWindow);
			}
			
			instanceOfWindow.Open();
		}
	}
}