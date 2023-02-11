using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/New Enemy",fileName = "New Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float life;

    [SerializeField]
    private float auxSpeed;

    [SerializeField]
    private float minimumDistance;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float shootForce;

    public float Speed { get { return this.speed; } set { this.speed = value; } }
    public float AuxSpeed { get { return this.auxSpeed; } private set { this.auxSpeed = value; } }
    public float Life { get { return this.life; } set { this.life = value; } }
    public float MinimumDistance { get { return this.minimumDistance; } set { this.minimumDistance = value; } }
    public float RotationSpeed { get { return this.rotationSpeed; } set { this.rotationSpeed = value; } }
    public float ShootForce { get { return this.shootForce; } set { this.shootForce = value; } }

    

}