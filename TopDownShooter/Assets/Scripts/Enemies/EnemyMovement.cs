using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("ENEMY CONFIGURATION REFERENCE")]
    public Enemy enemy;

    [HideInInspector]
    public Transform target;
    private void Start()
    {
        enemy.Speed = enemy.AuxSpeed;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (enemy.CurrentLife > 0)
        {
            Movement();
            Rotation();
            
        }
    }

    private void Movement()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * enemy.Speed * Time.deltaTime;
    }

    private void Rotation()
    {
        Vector2 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward,direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,enemy.RotationSpeed * Time.deltaTime);

    }
    
}
