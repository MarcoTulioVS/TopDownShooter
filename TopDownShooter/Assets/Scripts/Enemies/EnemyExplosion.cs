using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    [Header("OBJECT EXPLOSION")]
    public GameObject explosion;

    [Header("ENEMY CONFIGURATION REFERENCE")]
    public Enemy enemy;

    public SpawnCollection spawnCollection;

    private bool startVerification;

    private void Start()
    {
        spawnCollection = GameObject.FindGameObjectWithTag("spawnCollection").GetComponent<SpawnCollection>();
    }

    private void Update()
    {
        DecrementEnemyQuantity();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            explosion.SetActive(true);
            SoundController.instance.PlayAudio(SoundController.instance.audios[1]);
            col.gameObject.GetComponent<PlayerUI>().player.Life -= enemy.Damage;

            startVerification = true;
            Destroy(gameObject, 0.4f);
        }
    }

    private void DecrementEnemyQuantity()
    {
        if (startVerification)
        {
            for (int i = 6; i < 10; i++)
            {
                if (gameObject.layer == i)
                {
                    spawnCollection.spawnList[i - 6].GetComponent<SpawnEnemy>().spawnConfig.QuantEnemy--;
                    startVerification = false;
                }
            }
        }
    }


}
