using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCollision : MonoBehaviour
{
    public GameObject explosion;

    public Player player;

    public Enemy enemyShooter;

    private bool damageApplied;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != null && col.gameObject.tag!="area")
        {
            explosion.SetActive(true);
            Destroy(gameObject,0.260f);
        }

        if (col.gameObject.tag=="enemy") 
        {
            col.GetComponent<EnemyUI>().Life -= player.Damage;

            if(col.GetComponent<EnemyUI>().Life <= 0 && !damageApplied)
            {
                damageApplied = true;
                col.GetComponent<Collider2D>().enabled = false;
                GameController.instance.scoreValue += 10;
            }
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
}
