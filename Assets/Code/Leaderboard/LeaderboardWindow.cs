using System.Linq;
using MainMenu;
using MainMenu.Delegates;
using UnityEngine;

namespace Leaderboard
{
	[Window(Path = "Leaderboard/Window")]
	public class LeaderboardWindow : MonoBehaviour, ICloseableWindow, IControlBackColor
	{
		[SerializeField] private CanvasGroup canvasGroup = null;
		[SerializeField] private LeaderboardSystem system = null;
		[SerializeField] private Table table = null;
		[SerializeField] private Color backgroundColor = default;

		public event WindowCloseDelegate OnWindowClose = null;

		public Color BackgroundColor => backgroundColor;
		
		private void Start()
		{
			var orderedEntries = system.Entries
				.OrderByDescending(x => x.Scores)
				.ThenBy(x => x.Time);
			
			foreach (var entryData in orderedEntries)
			{
				table.AddRow(entryData);
			}
		}

		public void Open()
		{
			SetFocused(true);
		}

		public void SetFocused(bool value)
		{
			canvasGroup.alpha = value ? 1 : 0;
			canvasGroup.blocksRaycasts = value;
		}

		public void Close()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.blocksRaycasts = false;
			
			OnWindowClose.Invoke(this);
		}
	}
}