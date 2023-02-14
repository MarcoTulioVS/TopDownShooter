using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D prefabCannonBall;
    
    public Transform pointShoot;

    [SerializeField]
    private float shootForce;

    private Rigidbody2D rbCannonBall;
    
    public List<Transform> pointsShoot = new List<Transform>();

    private bool activeTrippleShot;


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

        //Triple Attack Right
        TrippleAttack(pointsShoot[0],true);
        TrippleAttack(pointsShoot[1],true);
        TrippleAttack(pointsShoot[2],true);

        //Triple Attack Left
        TrippleAttack(pointsShoot[3],false);
        TrippleAttack(pointsShoot[4],false);
        TrippleAttack(pointsShoot[5],false);
    }


    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 shootDirection = (pointShoot.position - transform.position).normalized;
            rbCannonBall = Instantiate(prefabCannonBall, pointShoot.position, Quaternion.identity);
            rbCannonBall.AddForce(shootDirection  * shootForce,ForceMode2D.Impulse);
        
        }
    }


    private void TrippleAttack(Transform trShoot,bool isRight)
    {

        if (isRight)
        {
            if (Input.GetMouseButtonDown(1) && activeTrippleShot)
            {
                TrippleShoot(trShoot);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && activeTrippleShot)
            {
                TrippleShoot(trShoot);
            }
        }

    }


    private void TrippleShoot(Transform trShoot)
    {
        Vector3 shoot = (trShoot.position - transform.position).normalized;
        rbCannonBall = Instantiate(prefabCannonBall, trShoot.position, Quaternion.identity);
        rbCannonBall.AddForce(shoot * shootForce, ForceMode2D.Impulse);
    }

}
