using System.Collections.Generic;
using System.Linq;
using Game.Enum;
using UnityEngine;

namespace Game.UI
{
	public class HitPointsPanel : MonoBehaviour
	{
		[SerializeField] private Player player = null;
		[SerializeField] private HeartIcon heartIconPrefab = null;
		[SerializeField] private Transform container = null;

		private List<HeartIcon> _icons = default;

		private void Start()
		{
			// Player doesn't have hit points in Rush mode
			//   so dont display them
			var gameManager = FindFirstObjectByType<GameManager>();

			if (gameManager.GameMode == GameMode.Rush)
			{
				Destroy(gameObject);
				return;
			}
			
			SetHitPoints(player.MaximalHp);

			player.OnHitPointsUpdates += PlayerHitPointsUpdates;
		}

		public void SetHitPoints(int hitPointsAmount)
		{
			SetHeartIcons(hitPointsAmount);
		}

		private void SetHeartIcons(int hitPointsAmount)
		{
			_icons ??= new ();

			if (hitPointsAmount < _icons.Count)
			{
				foreach (var icon in _icons
					.Skip(hitPointsAmount)
					.ToList())
				{
					_icons.Remove(icon);
					Destroy(icon.gameObject);
				}
			}

			for (int i = 0; i < hitPointsAmount; i++)
			{
				if (_icons.Count <= i)
				{
					CreateNewIcon();
				}

				var icon = _icons[i];
				
				icon.SetFillLevel(100f);
			}
		}

		private void CreateNewIcon()
		{
			var icon = Instantiate(heartIconPrefab, container);
			
			icon.transform.SetAsLastSibling();
			
			_icons.Add(icon);
		}
		
		private void PlayerHitPointsUpdates(float value)
		{
			foreach (var icon in _icons)
			{
				icon.SetFillLevel(Mathf.Clamp01(value) * 100f);

				value -= 1f;
			}
		}
	}
}