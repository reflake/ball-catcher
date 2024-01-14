using MainMenu;
using MainMenu.Delegates;
using UnityEngine;

namespace Leaderboard
{
	[Window(Path = "Leaderboard/Window")]
	public class LeaderboardWindow : MonoBehaviour, IWindow
	{
		[SerializeField] private CanvasGroup canvasGroup = null;
		[SerializeField] private LeaderboardSystem system = null;
		[SerializeField] private Table table = null;

		public event WindowCloseDelegate OnWindowClose = null;
		
		private void Start()
		{
			foreach (var entryData in system.Entries)
			{
				table.AddRow(entryData);
			}
		}

		public void Open()
		{
			canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;
		}

		public void Close()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.blocksRaycasts = false;
			
			OnWindowClose.Invoke();
		}
	}
}