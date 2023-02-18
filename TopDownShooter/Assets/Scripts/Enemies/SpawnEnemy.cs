using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("ENEMY OBJECT REFERENCE")]
    public GameObject enemyPrefab;

    [Header("GAME CONFIGURATION")]
    public ConfigurationsGame gameConfig;

    [SerializeField]
    private int maxSpawn;

    public int quantEnemy;

    public static SpawnEnemy instance;

    public SpawnConfiguration spawnConfig;


    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        spawnConfig.QuantEnemy = 0;
        StartCoroutine("StartSpawn");

    }

    private void Update()
    {
        quantEnemy = spawnConfig.QuantEnemy;
    }

    private void Spawn()
    {
        if (quantEnemy < maxSpawn)
        {
            GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            obj.layer = this.gameObject.layer;
            this.spawnConfig.QuantEnemy++;
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
