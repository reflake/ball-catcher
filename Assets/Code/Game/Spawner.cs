using System;
using Game.Collectible;
using Game.Enum;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameMode targetGameMode = default;
		[SerializeField] private Apple applePrefab = null;
		[SerializeField] private Heart heartPrefab = null;
		[SerializeField] private float nextSpawnTime = 0f;
		[SerializeField] private float spawnRange = 7.2f;
		[SerializeField] private float spawnInterval = 1.5f;
		[SerializeField] private float spawnMinimalInterval = 0.1f;
		[SerializeField] private float spawnIntervalIncreaseRate = 0.2f;
		[SerializeField] private float heartSpawnChance = 0.1f;

		public GameMode TargetGameMode => targetGameMode;

		private ScoreManager _scoreManager = null;

		private void Awake()
		{
			_scoreManager = FindFirstObjectByType<ScoreManager>();
		}

		private void Update()
		{
			var eps = 0.0001f;
			
			if (nextSpawnTime < Time.timeSinceLevelLoad - eps)
			{
				nextSpawnTime = Time.timeSinceLevelLoad + spawnInterval;

				var item = PickNextItem(out var needRandomRotation);

				SpawnItem(item, needRandomRotation);

				spawnInterval -= spawnIntervalIncreaseRate / 2000;
				spawnInterval = Mathf.Clamp(spawnInterval, spawnMinimalInterval, Single.PositiveInfinity);
			}
		}

		private Component PickNextItem(out bool needRandomRotation)
		{
			if (heartPrefab != null)
			{
				float value = Random.value;

				if (value < heartSpawnChance)
				{
					needRandomRotation = false;
					
					return heartPrefab;
				}
			}

			needRandomRotation = true;
			
			return applePrefab;
		}

		private void SpawnItem(Component item, bool needRandomRotation)
		{
			var randomSideOffset = Vector3.right * Random.Range(-spawnRange, +spawnRange);
			var randomPosition = transform.position + randomSideOffset;
			var randomRotation = needRandomRotation ? Random.rotationUniform : Quaternion.identity;
			var instanceOfItem = Instantiate(item, randomPosition, randomRotation);

			switch (instanceOfItem)
			{
				case Apple apple:
					apple.Setup(_scoreManager);
					break;
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(transform.position, new Vector3(spawnRange * 2f, 1f, 1f));
		}
	}
}