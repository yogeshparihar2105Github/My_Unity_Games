using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpanner : MonoBehaviour
{
    [SerializeField] List<waveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while(looping);
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var curretWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(curretWave)); 
        }

        looping = true;

    }

    IEnumerator SpawnAllEnemiesInWave(waveConfig waveConfigs)
    {
        for (int enemyCount = 0; enemyCount < waveConfigs.GetNumberOfEnemies(); enemyCount++)
        {

            var newEnemy = Instantiate(waveConfigs.GetEnemyPrefab(), waveConfigs.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<enemyPathing>().SetWaveConfig(waveConfigs);

            yield return new WaitForSeconds(waveConfigs.GetTimeBetweenSpawns());

        }
        
    }

    
}
