using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MainMenu
{
	[Serializable]
	public class LazyWindow<TWindow> where TWindow : Component
	{
		[SerializeField] private TWindow prefab;
		
		public TWindow Value {
			get {
				if (_window == null)
				{
					_window = Object.Instantiate(prefab, MainMenu.Instance.WindowContainer);
				}

				return _window;
			}
		}

		private TWindow _window = default;
	}
}