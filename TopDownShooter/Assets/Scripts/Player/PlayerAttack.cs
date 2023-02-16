using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("CANNON BALL")]
    public Rigidbody2D prefabCannonBall;
    
    [Header("PROJECTILE POINT REFERENCE")]
    public Transform pointShoot;

    [SerializeField]
    private float shootForce;

    private Rigidbody2D rbCannonBall;
    
    public List<Transform> pointsShoot = new List<Transform>();

    private bool activeTrippleShot;

    [SerializeField]
    private float fireRate;

    private float nextFire = 0;

    [SerializeField]
    private List<Vector2> shootsDirection = new List<Vector2>();

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activeTrippleShot = !activeTrippleShot;
        }

        if (!activeTrippleShot)
        {
            Attack();
        }

        TrippleAttack();

    }


    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Vector3 shootDirection = (pointShoot.position - transform.position).normalized;
            rbCannonBall = Instantiate(prefabCannonBall, pointShoot.position, Quaternion.identity);
            rbCannonBall.AddForce(shootDirection  * shootForce,ForceMode2D.Impulse);
        
        }
    }


    private void TrippleAttack()
    {
        if(Input.GetMouseButtonDown(1) && activeTrippleShot)
        {
            TrippShootRight(pointsShoot[3], pointsShoot[4], pointsShoot[5]);
        }

        if (Input.GetMouseButtonDown(0) && activeTrippleShot)
        {
            TrippShootLeft(pointsShoot[0], pointsShoot[1], pointsShoot[2]);
        }

    }


    private void TrippShootLeft(Transform tr1,Transform tr2, Transform tr3)
    {
        if (Time.time > nextFire)
        {
            nextFire= Time.time + fireRate;

            shootsDirection[0] = (tr1.position - transform.position).normalized;
            shootsDirection[1] = (tr2.position - transform.position).normalized;
            shootsDirection[2] = (tr3.position - transform.position).normalized;


            for(int i = 0; i < pointsShoot.Count - 3; i++)
            {
                rbCannonBall = Instantiate(prefabCannonBall, pointsShoot[i].position, Quaternion.identity);
                rbCannonBall.AddForce(shootsDirection[i] * shootForce, ForceMode2D.Impulse);
            }
            
        }

    }

    private void TrippShootRight(Transform tr1, Transform tr2, Transform tr3)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            shootsDirection[3] = (tr1.position - transform.position).normalized;
            shootsDirection[4] = (tr2.position - transform.position).normalized;
            shootsDirection[5] = (tr3.position - transform.position).normalized;


            for (int i = 3; i < pointsShoot.Count; i++)
            {
                rbCannonBall = Instantiate(prefabCannonBall, pointsShoot[i].position, Quaternion.identity);
                rbCannonBall.AddForce(shootsDirection[i] * shootForce, ForceMode2D.Impulse);
            }

        }

    }

}

   


