using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views;

[System.Serializable]
public struct PlayerData
{
    private PlayerView player;

    
    [SerializeField] private float speed, rushSpeed;
    [SerializeField] private int level;
    [SerializeField] private int xp;
    [SerializeField] private float maxKillDist;
    public PlayerView PlayerView => player;
    public Transform Transform => player.transform;
    public Rigidbody Rigidbody => player.Rigidbody;
    public float Speed => speed;
    public float RushSpeed => rushSpeed;
    public float MaxKillDistance => maxKillDist;
    
    

    public PlayerData(PlayerView player, PlayerData parameters)
    {
        this.player = player;
        this.speed = parameters.speed;
        this.level = parameters.level;
        this.xp = parameters.xp;
        this.rushSpeed = parameters.rushSpeed;
        this.maxKillDist = parameters.maxKillDist;
    }

}
