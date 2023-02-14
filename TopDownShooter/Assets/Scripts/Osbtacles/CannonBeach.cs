using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBeach : MonoBehaviour
{
    public Rigidbody2D prefabCannonBall;

    [SerializeField]
    private float speed;

    public Transform point;

    [SerializeField]
    private bool isUp;

    [SerializeField]
    private float timeShoot;
    void Start()
    {
        StartCoroutine("ShootCannonBall");
    }

    
    void Update()
    {
        
    }

    IEnumerator ShootCannonBall()
    {
        yield return new WaitForSeconds(timeShoot);
        Rigidbody2D rbShoot = Instantiate(prefabCannonBall, point.position, Quaternion.identity);
        
        if (!isUp)
        {
            rbShoot.velocity = new Vector2(speed, rbShoot.velocity.y);
        }
        else
        {
            rbShoot.velocity = new Vector2(rbShoot.velocity.x, speed);
        }
        
        StartCoroutine(ShootCannonBall());
    }
}
