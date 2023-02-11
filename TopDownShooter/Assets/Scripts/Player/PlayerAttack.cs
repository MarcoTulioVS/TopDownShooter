using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D prefabCannonBall;
    public Transform pointShoot;

    void Start()
    {
        
    }

    
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D rb = Instantiate(prefabCannonBall, pointShoot.position, Quaternion.identity);
            rb.velocity = new Vector2(5, 5);

        }
    }
}
