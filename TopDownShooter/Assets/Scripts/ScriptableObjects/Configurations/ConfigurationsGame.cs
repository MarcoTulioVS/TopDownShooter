using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/New configuration",fileName = "New configuration")]
public class ConfigurationsGame : ScriptableObject
{
    [SerializeField]
    private float timeMatch;

    [SerializeField]
    private float timeSpawnEnemy;

    public float TimeMatch { get { return this.timeMatch; } set { this.timeMatch = value;} }
    public float TimeSpawnEnemy { get { return this.timeSpawnEnemy; } set { this.timeSpawnEnemy = value;} }
}
