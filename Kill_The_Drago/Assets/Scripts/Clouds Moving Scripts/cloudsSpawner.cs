using UnityEngine;
using System.Collections;

public class cloudsSpawner : MonoBehaviour {

	public GameObject cloudPrefab;

	float spawnDistance = 1f;

	float cloudRate = 5;
	float nextCloud = 1f;

	// Update is called once per frame
	void Update () {
		nextCloud -= Time.deltaTime;

		if(nextCloud <= 0) {
			nextCloud = cloudRate;
			cloudRate *= 0.9f;
			if(cloudRate < 2)
				cloudRate = 2;

			Vector3 offset = Random.onUnitSphere;
			// Vector3 offset = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));

			offset.z = 0;

			offset = offset.normalized * spawnDistance;

			//When normalized, a vector keeps the same direction but its length is 1
			//If the vector is too small to be normalized a zero vector will be returned

			Instantiate(cloudPrefab, transform.position + offset, Quaternion.identity);
			
		}
	}
}
