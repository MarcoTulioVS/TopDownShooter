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
    private float currentLife;

    [SerializeField]
    private float auxSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    private float damage;

    
    public float Speed { get { return this.speed; } set { this.speed = value; } }
    public float AuxSpeed { get { return this.auxSpeed; } private set { this.auxSpeed = value; } }
    public float Life { get { return this.life; } private set { this.life = value; } }
    public float RotationSpeed { get { return this.rotationSpeed; } set { this.rotationSpeed = value; } }
    public float ShootForce { get { return this.shootForce; } set { this.shootForce = value; } }
    public float CurrentLife { get { return this.currentLife; } set { this.currentLife = value; } }
    public float Damage { get { return this.damage; } set { this.damage = value; } }
    

    

}
