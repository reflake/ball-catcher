using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MainMenu.Delegates;
using TMPro;
using UnityEngine;

namespace MainMenu.Dialog
{
	[Window(Path = "Dialog/Window")]
	public class DialogWindow : MonoBehaviour, ICloseableWindow
	{
		[SerializeField] private TMP_Text descriptionLabel = null;
		[SerializeField] private DialogOptionButton optionButtonPrefab = null;
		[SerializeField] private Transform buttonContainer = null;
		
		public event WindowCloseDelegate OnWindowClose = default;

		private List<DialogOptionButton> _optionButtons = new();

		public async UniTask<TOption> ShowDialogAsync<TOption>(string description,
			ICollection<(TOption, string)> options, TOption defaultOption)
			where TOption : Enum
		{
			descriptionLabel.text = description;
			
			foreach (var (optionValue, text) in options)
			{
				var instanceOfButton = Instantiate(optionButtonPrefab, buttonContainer);

				instanceOfButton.Setup(optionValue, text);
				
				_optionButtons.Add(instanceOfButton);
			}

			var windowClosedTask = this.OnClosedAsync(defaultOption);
			var optionsClickTasks = _optionButtons.Select(button => button.Clicked<TOption>());
			var (_, option) = await UniTask.WhenAny(optionsClickTasks.Append(windowClosedTask));
			
			Close();

			return option;
		}

		public void Open()
		{
			SetFocused(true);
		}

		public void SetFocused(bool value)
		{
			gameObject.SetActive(value);
		}

		public void Close()
		{
			SetFocused(false);
			
			foreach (var button in _optionButtons)
			{
				Destroy(button.gameObject);
			}
			
			_optionButtons.Clear();
			
			OnWindowClose?.Invoke(this);
		}
	}
}