using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/New Player",fileName = "New Player")]
public class Player : ScriptableObject
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float life;

    [SerializeField]
    private float rotationSpeed;

    public float Life { get { return this.life; } set { this.life = value; } }
    public float Speed { get { return this.speed; } set { this.speed = value; } }
    public float RotationSpeed { get { return this.rotationSpeed; } set { this.rotationSpeed = value; } }

}
