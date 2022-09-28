using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    [SerializeField] private float spawnCooldown;
    [SerializeField] private int maxCount = 200;

    public float SpawnTime => spawnCooldown;
    public float MaxUnits => maxCount;
}
