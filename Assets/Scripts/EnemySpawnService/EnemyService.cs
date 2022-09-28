using Leopotam.Ecs;
using Mono;
using UnityEngine;

namespace Enemy
{
    public class EnemyService : IEcsRunSystem
    {
        private Game game;
        private EnemyPool enemyPool;

        public EnemyService(Game game, EnemyPool pool)
        {
            this.game = game;
            this.enemyPool = pool;
        }

        public void Run()
        {
            ref PlayerData player = ref game.Player.Get<PlayerData>();
            var playerPos = player.Transform.position;
            foreach (var entity in game.Enemies)
            {
                ref EnemyData enemy = ref entity.Get<EnemyData>();
                if (!enemy.EnemyView.IsDeath)
                {
                    if (!enemy.ReadyShoot)
                    {
                        NotShoot(ref enemy, playerPos);
                    }
                    else
                    {
                        Shoot(ref enemy, playerPos);
                    }
                }
                else
                {
                    RemoveEnemy(ref enemy, entity);
                    break;
                }
            }
        }

        public void RemoveEnemy(ref EnemyData enemy, EcsEntity entity)
        {
            enemy.EnemyView.Ragdoll.Ragdoll(enemyPool);
            game.Enemies.Remove(entity);
            entity.Destroy();
        }
        
        public void Shoot(ref EnemyData enemyData, Vector3 playerPos)
        {
            if ((enemyData.Transform.position - playerPos).sqrMagnitude <= (enemyData.Distance * enemyData.Distance) * 3f)
            {
                enemyData.EnemyView.MoveAim(playerPos);
                enemyData.ShootCalculate();
            }
            else
            {
                enemyData.NotReady();
            }
        }
        
        public void NotShoot(ref EnemyData enemy, Vector3 playerPos)
        {
            if ((enemy.Transform.position - playerPos).sqrMagnitude >= enemy.Distance * enemy.Distance)
            {
                MoveToPlayer(ref enemy, playerPos);
            }
            else
            {
                enemy.EnemyView.SetRun(false);
                enemy.SetReadyShoot();
            }
        }
        

        public void MoveToPlayer(ref EnemyData enemy, Vector3 target)
        {
            enemy.EnemyView.SetRun(true);
            var enemyPos = enemy.Transform.position;
            enemy.Rigidbody.velocity = (target - enemyPos).normalized * enemy.Speed;
            enemy.Transform.rotation = Quaternion.Lerp(enemy.Transform.rotation, Quaternion.LookRotation(target - enemyPos), 10 * Time.fixedDeltaTime);
        }
    }
}
