using System;
using Game.Delegates;
using TMPro;
using UnityEngine;

namespace Game
{
	public class Timer : MonoBehaviour
	{
		[SerializeField] private TMP_Text label = default;
		
		public event CountdownCompleteDelegate OnCountdownComplete = null;

		private float _countdownCompletionTime;

		public void LaunchCountdown(float timeInSeconds)
		{
			label.gameObject.SetActive(true);
			
			_countdownCompletionTime = Time.timeSinceLevelLoad + timeInSeconds;

			enabled = true;
		}

		private void Update()
		{
			float timeLeft = _countdownCompletionTime - Time.timeSinceLevelLoad;
			
			timeLeft = Mathf.Clamp(timeLeft, 0f, Single.PositiveInfinity);
			
			DisplayTimeLeft(timeLeft);

			bool isAnyTimeLeft = timeLeft <= 0;
			
			if (isAnyTimeLeft)
			{
				enabled = false;
				
				OnCountdownComplete?.Invoke();
			}
		}

		private void DisplayTimeLeft(float timeLeft)
		{
			int secondsLeft = Mathf.FloorToInt(timeLeft % 60);
			int minutesLeft = Mathf.FloorToInt(timeLeft / 60);

			label.text = $"{minutesLeft}:{secondsLeft:D2}";
		}
	}
}