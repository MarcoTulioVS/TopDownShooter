using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    [Header("OBJECT EXPLOSION")]
    public GameObject explosion;

    [Header("ENEMY CONFIGURATION REFERENCE")]
    public Enemy enemy;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            explosion.SetActive(true);
            col.gameObject.GetComponent<PlayerUI>().player.Life -= enemy.Damage;
            Destroy(gameObject, 0.4f);
        }
    }

   
}
