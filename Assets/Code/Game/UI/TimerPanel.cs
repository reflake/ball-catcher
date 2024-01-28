using TMPro;
using UnityEngine;

namespace Game.UI
{
	public class TimerPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text label = default;

		private Timer _timer;

		private void Awake()
		{
			_timer = FindFirstObjectByType<Timer>();
			
			_timer.OnCountdownStarted += CountdownStarted;
			_timer.OnCountdownComplete += CountdownComplete;
		}

		private void CountdownStarted()
		{
			label.gameObject.SetActive(true);

			enabled = true;
		}

		private void CountdownComplete()
		{
			enabled = false;
		}

		private void Update()
		{
			var timeLeft = _timer.TimeLeft;
			
			int secondsLeft = Mathf.FloorToInt(timeLeft % 60);
			int minutesLeft = Mathf.FloorToInt(timeLeft / 60);

			label.text = $"{minutesLeft}:{secondsLeft:D2}";
		}
	}
}