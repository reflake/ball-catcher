using UnityEngine;
using UnityEngine.EventSystems;

namespace MainMenu
{
	public class MenuHintPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField, TextArea] private string hintText = string.Empty;
		
		public void OnPointerEnter(PointerEventData _)
		{
			MenuHint.Instance.ShowHint(hintText);
		}

		public void OnPointerExit(PointerEventData _)
		{
			MenuHint.Instance.HideHint();
		}
	}
}