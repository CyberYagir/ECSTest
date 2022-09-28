using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using Input;
using Leopotam.Ecs;
using Mono;
using Player;
using UnityEngine;

public sealed class Game : MonoBehaviour
{
    [SerializeField] private SceneView sceneView;
    [SerializeField] private GameData gameData;
    [SerializeField] private EnemyPool pool;
    
    private EcsSystems systems;
    private EcsSystems systemsFixed;
    
    private EcsWorld world;
    private EcsEntity player;
    private List<EcsEntity> enemies = new List<EcsEntity>(100);


    public EcsEntity Player => player;
    public EcsWorld World => world;
    public List<EcsEntity> Enemies => enemies;

    private void Awake()
    {

        pool.Init();
        
        world = new EcsWorld ();

        // // // // // // // //        
        
        systems = new EcsSystems (world);
        systems
            .Add(new PlayerService(sceneView, gameData, this))
            .Add(new InputService(sceneView, this))
            .Add(new EnemySpawnService(gameData, this, sceneView, pool))
            .Init();

        // // // // // // // // 
        
        systemsFixed = new EcsSystems(world);
        systemsFixed
            .Add(new PlayerMoveService(this))
            .Add(new EnemyService(this, pool))
            .Init();
    }


    private void Update()
    {
        systems?.Run();
    }

    private void FixedUpdate()
    {
        systemsFixed?.Run();
    }

    void OnDestroy () {
        // Уничтожаем подключенные системы.
        if (systems != null) {
            systems.Destroy ();
            systems = null;
        }
        // Очищаем окружение.
        if (systems != null) {
            systems.Destroy ();
            systems = null;
        }
    }

    public void SetPlayer(EcsEntity newEntity)
    {
        player = newEntity;
    }
}