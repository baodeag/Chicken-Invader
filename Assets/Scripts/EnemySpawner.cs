using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs; // List of wave configurations
    [SerializeField] float timeBetweenWaves = 0f; // Time between waves
    WaveConfigSO currentWave;

    [SerializeField ]bool isLooping = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do { 
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave; // Set the current wave to the current wave in the loop
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform); // Instantiate each enemy prefab at the starting waypoint position
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves); // Wait for the specified time between waves
            }
        } while (isLooping); // Continue looping if isLooping is true
    }
    
}
