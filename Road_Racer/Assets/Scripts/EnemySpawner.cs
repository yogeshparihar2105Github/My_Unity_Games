using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;


    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawner();
        }

    }

    public void StopSpawnning()
    {
        spawn = false;
    }

    void Spawner()
    {
       GameObject enemy = Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], transform.position, transform.rotation);

    }
}
