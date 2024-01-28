using System;
using Game.Delegates;
using TMPro;
using UnityEngine;

namespace Game
{
	public class Timer : MonoBehaviour
	{
		public event CountdownStartedDelegate OnCountdownStarted = null;
		public event CountdownCompleteDelegate OnCountdownComplete = null;

		public float TimeLeft { get; private set; }
		
		private float _countdownCompletionTime;

		public void LaunchCountdown(float timeInSeconds)
		{
			_countdownCompletionTime = Time.timeSinceLevelLoad + timeInSeconds;

			enabled = true;
			
			OnCountdownStarted?.Invoke();
		}

		private void Update()
		{
			TimeLeft = _countdownCompletionTime - Time.timeSinceLevelLoad;
			TimeLeft = Mathf.Clamp(TimeLeft, 0f, Single.PositiveInfinity);

			bool isAnyTimeLeft = TimeLeft <= 0;
			
			if (isAnyTimeLeft)
			{
				enabled = false;
				
				OnCountdownComplete?.Invoke();
			}
		}
	}
}