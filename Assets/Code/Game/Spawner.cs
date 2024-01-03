using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Transform ballPrefab = null;
		[SerializeField] private float nextSpawnTime = 0f;
		[SerializeField] private float spawnRange = 7.2f;

		private void Update()
		{
			var eps = 0.0001f;
			
			if (nextSpawnTime < Time.time - eps)
			{
				var spawnInterval = 1.5f;
				
				nextSpawnTime += spawnInterval;

				SpawnBall();
			}
		}

		private void SpawnBall()
		{
			var randomSideOffset = Vector3.right * Random.Range(-spawnRange, +spawnRange);
			var randomPosition = transform.position + randomSideOffset;
			var randomRotation = Random.rotationUniform;
			
			Instantiate(ballPrefab, randomPosition, randomRotation);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(transform.position, new Vector3(spawnRange, 1f, 1f));
		}
	}
}