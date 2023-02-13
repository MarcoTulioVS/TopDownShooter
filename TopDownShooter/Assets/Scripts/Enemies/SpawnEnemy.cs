using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public ConfigurationsGame gameConfig;
    void Start()
    {
        StartCoroutine("StartSpawn");
    }

    private void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1);
        Spawn();
        yield return new WaitForSeconds(gameConfig.TimeSpawnEnemy);
        StartCoroutine("StartSpawn");
    }
}
