using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public ConfigurationsGame gameConfig;

    [SerializeField]
    private int maxSpawn;

    
    public int quantEnemy;

    public static SpawnEnemy instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine("StartSpawn");
    }

    private void Spawn()
    {
        if (quantEnemy<maxSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            quantEnemy++;
        }
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1);
        Spawn();
        yield return new WaitForSeconds(gameConfig.TimeSpawnEnemy);
        StartCoroutine("StartSpawn");
    }
}
