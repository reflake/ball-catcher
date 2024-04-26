using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Dialog
{
	public class DialogOptionButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text label = null;
		[SerializeField] private Button button = null;

		private object _value = null;
		
		public void Setup<TOption>(TOption optionValue, string text) where TOption : Enum
		{
			label.text = text;
			
			_value = optionValue;
		}

		public async UniTask<TOption> Clicked<TOption>() where TOption : Enum
		{
			await button.OnClickAsync();

			return (TOption)_value;
		}
	}
}