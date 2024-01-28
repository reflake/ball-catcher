using System;
using TMPro;
using UnityEngine;

namespace MainMenu
{
	public class MenuHint : MonoBehaviour
	{
		public static MenuHint Instance = default;
		
		[SerializeField] private TMP_Text label = default;

		public void OnEnable()
		{
			Instance = this;
		}

		public void OnDisable()
		{
			Instance = null;
		}

		public void ShowHint(string text)
		{
			label.enabled = true;
			label.text = text;
		}

		public void HideHint()
		{
			label.enabled = false;
		}
	}
}