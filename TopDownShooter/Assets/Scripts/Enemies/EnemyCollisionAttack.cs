using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    private bool isShooting;

    private bool startAttack;

    [Header("SHIP")]
    public Transform ship;

    [Header("REFERENCE POINT TO THE SHOOT")]
    public Transform pointShoot;

    public Rigidbody2D rbShoot;

    [Header("PROJECTILE")]
    public Rigidbody2D prefabCannonBall;

    void Start()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();

    }

    
    void Update()
    {
        if (startAttack && !isShooting)
        {
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            enemyMovement.enemy.Speed = 0;
            startAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D notCol)
    {
        if (notCol.gameObject.tag == "Player")
        {
            enemyMovement.enemy.Speed = enemyMovement.enemy.AuxSpeed;
            startAttack=false;
            
        }
    }

    IEnumerator Attack()
    {
        isShooting = true;
        SoundController.instance.PlayAudio(SoundController.instance.audios[0]);
        Vector3 shootDirection = (pointShoot.position - ship.position).normalized;
        rbShoot = Instantiate(prefabCannonBall, pointShoot.position, ship.rotation);
        rbShoot.AddForce(shootDirection * enemyMovement.enemy.ShootForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }
}
