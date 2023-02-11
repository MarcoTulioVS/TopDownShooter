using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;

    public Transform target;

    public Transform pointShoot;

    [HideInInspector]
    public Rigidbody2D rbShoot;

    public Rigidbody2D prefabCannonBall;

    
    private void Start()
    {
        enemy.Speed = enemy.AuxSpeed;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * enemy.Speed * Time.deltaTime;

        //float distance = Vector3.Distance(target.position, transform.position);

        //if (distance <= enemy.MinimumDistance && !isShooting)
        //{
        //    enemy.Speed = 0;
        //    StartCoroutine("Attack");
        //}
        //else
        //{
        //    enemy.Speed = enemy.AuxSpeed;
        //}

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, target.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, enemy.RotationSpeed * Time.deltaTime);
    }

    

    

}
