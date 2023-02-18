using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCollision : MonoBehaviour
{
    [Header("OBJECT EXPLOSION")]
    public GameObject explosion;

    [Header("PLAYER CONFIGURATION REFERENCE")]
    public Player player;

    [Header("ENEMY SHOOTER CONFIGURATION REFERENCE")]
    public Enemy enemyShooter;

    private bool damageApplied;

    public SpawnCollection spawnCollection;

    private bool startVerification;

    private GameObject collidedObj;
    private void Start()
    {
        spawnCollection = GameObject.FindGameObjectWithTag("spawnCollection").GetComponent<SpawnCollection>();
    }
    private void Update()
    {
        DecrementEnemyQuantity();
        DestroyObject();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag!="area" && gameObject.tag!="ballEnemy")
        {
            explosion.SetActive(true);
            Destroy(gameObject,0.260f);
        }

        if (col.gameObject.tag=="enemy" && gameObject.tag!="ballEnemy") 
        {
            col.GetComponent<EnemyUI>().Life -= player.Damage;

            if(col.GetComponent<EnemyUI>().Life <= 0 && !damageApplied)
            {
                damageApplied = true;
                col.GetComponent<Collider2D>().enabled = false;
                GameController.instance.scoreValue += 10;
                
                startVerification = true;
                collidedObj = col.gameObject;
                
            }
        }

        if(col.gameObject.tag == "Player" && gameObject.tag=="ballEnemy")
        {
            explosion.SetActive(true);
            Destroy(gameObject, 0.260f);
        }

        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerUI>().player.Life -= enemyShooter.Damage;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            damageApplied = false;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject, 3f);
    }

    private void DecrementEnemyQuantity()
    {
        if (startVerification)
        {
            for (int i = 6; i < 10; i++)
            {
                if (collidedObj.gameObject.layer == i)
                {
                    spawnCollection.spawnList[i - 6].GetComponent<SpawnEnemy>().spawnConfig.QuantEnemy--;
                    startVerification = false;
                }
            }
        }
    }
}
