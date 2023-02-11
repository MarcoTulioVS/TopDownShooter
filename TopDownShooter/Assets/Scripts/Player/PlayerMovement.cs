using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public Player player;

    private float movementHor;
    private float movementVert;

    void Start()
    {

    }

    private void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        
    }

    private void Movement()
    {
        movementHor = Input.GetAxis("Horizontal");
        movementVert = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(movementHor,movementVert);

        float inputMagnitude = Mathf.Clamp01(move.magnitude);
        move.Normalize();

        transform.Translate(move * player.Speed * inputMagnitude * Time.deltaTime, Space.World);
       
        
        if(move != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward,move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,player.RotationSpeed * Time.deltaTime);
        }
    }
}
