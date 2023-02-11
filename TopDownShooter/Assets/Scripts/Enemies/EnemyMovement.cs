using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;

    public Transform target;

    
    private void Start()
    {
        enemy.Speed = enemy.AuxSpeed;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        Movement();
        Rotation();
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

        
    }

    private void Movement()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * enemy.Speed * Time.deltaTime;
    }

    private void Rotation()
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, target.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, enemy.RotationSpeed * Time.deltaTime);
    }


}
