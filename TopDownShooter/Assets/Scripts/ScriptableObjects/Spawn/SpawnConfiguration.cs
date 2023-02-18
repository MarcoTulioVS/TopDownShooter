using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnConfig/New Spawn Config",fileName = "New Spawn Config")]
public class SpawnConfiguration : ScriptableObject
{
    [SerializeField]
    private int quantEnemy;

    [SerializeField]
    private int maxSpawn;

    [SerializeField]
    private int auxSpawn;

    public int QuantEnemy { get { return this.quantEnemy; } set { this.quantEnemy = value; } }
    public int MaxSpawn { get { return this.maxSpawn; } set { this.maxSpawn = value; } }
    public int AuxSpawn { get { return this.auxSpawn; } private set { this.auxSpawn = value; } }

}
