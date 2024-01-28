using System;
using Game.Enum;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameMode targetGameMode = default;
		[SerializeField] private Apple applePrefab = null;
		[SerializeField] private float nextSpawnTime = 0f;
		[SerializeField] private float spawnRange = 7.2f;
		[SerializeField] private float spawnInterval = 1.5f;
		[SerializeField] private float spawnMinimalInterval = 0.1f;
		[SerializeField] private float spawnIntervalIncreaseRate = 0.2f;

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

				SpawnBall();

				spawnInterval -= spawnIntervalIncreaseRate / 2000;
				spawnInterval = Mathf.Clamp(spawnInterval, spawnMinimalInterval, Single.PositiveInfinity);
			}
		}

		private void SpawnBall()
		{
			var randomSideOffset = Vector3.right * Random.Range(-spawnRange, +spawnRange);
			var randomPosition = transform.position + randomSideOffset;
			var randomRotation = Random.rotationUniform;
			var instanceOfBall = Instantiate(applePrefab, randomPosition, randomRotation);
			
			instanceOfBall.Setup(_scoreManager);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(transform.position, new Vector3(spawnRange * 2f, 1f, 1f));
		}
	}
}