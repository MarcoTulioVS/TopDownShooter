using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/New Player",fileName = "New Player")]
public class Player : ScriptableObject
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float auxSpeed;

    [SerializeField]
    private float life;

    [SerializeField]
    private float auxLife;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float damage;
    public float Life { get { return this.life; } set { this.life = value; } }
    public float Speed { get { return this.speed; } set { this.speed = value; } }
    public float AuxSpeed { get { return this.auxSpeed; } private set { this.auxSpeed = value; } }
    public float RotationSpeed { get { return this.rotationSpeed; } set { this.rotationSpeed = value; } }
    public float Damage { get { return this.damage; } set { this.damage = value; } }
    public float AuxLife { get { return this.auxLife; } private set { this.auxLife = value; } }

}
