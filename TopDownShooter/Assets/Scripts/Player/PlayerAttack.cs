using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D prefabCannonBall;
    //public Transform prefabCannonBall;
    public Transform pointShoot;

    [SerializeField]
    private float shootForce;

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
            Vector3 shootDirection = (pointShoot.position - transform.position).normalized;
            Rigidbody2D rbCannonBall = Instantiate(prefabCannonBall, pointShoot.position, Quaternion.identity);
            rbCannonBall.AddForce(shootDirection  * shootForce,ForceMode2D.Impulse);
        
        }
    }
}
