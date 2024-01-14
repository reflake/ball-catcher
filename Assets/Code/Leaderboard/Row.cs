using MainMenu;
using TMPro;
using UnityEngine;

namespace Leaderboard
{
	public class Row : BaseRow<LocalEntry>
	{
		[SerializeField] private TMP_Text scoresLabel = null;
		[SerializeField] private TMP_Text dateLabel = null;
		[SerializeField] private TMP_Text timeLabel = null;
		[SerializeField] private RectTransform rectTransform = null;
		
		public override void SetAsHeader()
		{
			scoresLabel.fontStyle |= FontStyles.Bold;
			dateLabel.fontStyle |= FontStyles.Bold;
			timeLabel.fontStyle |= FontStyles.Bold;

			scoresLabel.text = "SCORE";
			dateLabel.text = "DATE";
			timeLabel.text = "TIME";
			
			// Need to wait one frame before unparenting
			Invoke("Unparent", 0.02f);
		}

		private void Unparent()
		{
			float rowHeight = rectTransform.sizeDelta.y;
			
			rectTransform.parent = rectTransform.parent.parent.parent;
			rectTransform.anchoredPosition += new Vector2(0, rowHeight);
		}
		
		public override void SetData(LocalEntry data)
		{
			scoresLabel.text = data.Scores.ToString();
			dateLabel.text = data.Date.ToString("f");

			int minutes = data.Time / 60;
			int seconds = data.Time % 60;
			
			timeLabel.text = $"{minutes}:{seconds:D2}";
		}
	}
}