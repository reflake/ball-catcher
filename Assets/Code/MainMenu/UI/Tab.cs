using MainMenu.Delegates;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.UI
{
	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Button))]
	public class Tab : MonoBehaviour
	{
		[SerializeField] private Color selectedColor;
		[SerializeField] private Color unselectedColor;

		public event TabClicked OnClicked = null;
		
		private Image _image;

		private void Awake()
		{ 
			var button = GetComponent<Button>();
			
			button.onClick.AddListener(Click);

			_image = GetComponent<Image>();
		}

		private void Click()
		{
			OnClicked?.Invoke(this);
		}

		public void SetSelected(bool value)
		{
			if (value)
			{
				_image.color = selectedColor;
			}
			else
			{
				_image.color = unselectedColor;
			}
		}
	}
}