using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCollision : MonoBehaviour
{
    public GameObject explosion;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != null && col.gameObject.tag!="area")
        {
            explosion.SetActive(true);
            Destroy(gameObject,0.260f);
        }
    }
}
