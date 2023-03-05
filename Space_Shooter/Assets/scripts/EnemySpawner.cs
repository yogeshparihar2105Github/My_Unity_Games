using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	float spawnDistance = 4.3f;

	float enemyRate = 5;
	float nextEnemy = 1;

	// Update is called once per frame
	void Update () {
		nextEnemy -= Time.deltaTime;

		if(nextEnemy <= 0) {
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if(enemyRate < 2)
				enemyRate = 2;

			Vector3 offset = Random.onUnitSphere;
			// Vector3 offset = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));

			offset.z = 0;

			offset = offset.normalized * spawnDistance;

			Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
		}
	}
}
