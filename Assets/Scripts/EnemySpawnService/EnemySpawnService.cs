using Leopotam.Ecs;
using Mono;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawnService : IEcsRunSystem
    {
        private GameData gameData;
        private Game game;
        private SceneView scene;
        private EnemyPool pool;
        private float time;

        public EnemySpawnService(GameData gameData, Game game, SceneView scene, EnemyPool enemyPool)
        {
            this.gameData = gameData;
            this.game = game;
            this.scene = scene;
            this.pool = enemyPool;
        }

        public void Run()
        {
            time += Time.deltaTime;

            if (time >= gameData.SpawnTime && game.Enemies.Count <= gameData.MaxUnits)
            {
                var enemyView = pool.GetFromPool();

                if (enemyView != null)
                {
                    enemyView.gameObject.SetActive(true);
                    
                    var newUnit = game.World.NewEntity();

                    ref EnemyData enemy = ref newUnit.Get<EnemyData>();

                    enemy = new EnemyData(enemyView, enemyView.GetEnemy());

                    var playerTransform = game.Player.Get<PlayerData>().Transform;
                    do
                    {
                        enemyView.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
                    } while (Vector3.Distance(playerTransform.position, enemyView.transform.position) < 10);

                    game.Enemies.Add(newUnit);
                }

                time = 0;
            }
        }
    }
}
