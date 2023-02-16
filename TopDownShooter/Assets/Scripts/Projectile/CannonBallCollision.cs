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

    private void Update()
    {
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
                SpawnEnemy.instance.quantEnemy--;
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
}
