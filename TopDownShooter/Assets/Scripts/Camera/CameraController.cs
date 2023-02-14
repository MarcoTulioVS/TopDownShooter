using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float maxX;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minY;

    public Transform target;
    void Start()
    {
        
    }

    
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x,minX,maxX),
            Mathf.Clamp(target.position.y,minY,maxY),transform.position.z);
    }
}
