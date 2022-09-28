using Input;
using Leopotam.Ecs;
using UnityEngine;
using Views;

namespace Player
{
    public class PlayerMoveService : IEcsRunSystem, IEcsInitSystem
    {
        private Game game;

        public PlayerMoveService(Game game)
        {
            this.game = game;
        }

        private float currentSpeed;
        
        
        public void Run()
        {
            ref PlayerData playerData = ref game.Player.Get<PlayerData>();
            ref InputData inputData = ref game.Player.Get<InputData>();

            if (inputData.IsCanControll && inputData.Direction.sqrMagnitude > 0.1f)
            {
                var angle = Mathf.Atan2(inputData.Direction.x, inputData.Direction.y) * Mathf.Rad2Deg;
                playerData.Transform.localEulerAngles = Vector3.up * angle;

                currentSpeed = Mathf.Lerp(currentSpeed, CalcSpeed(ref playerData), 2 * Time.deltaTime);
                
                
                playerData.Rigidbody.velocity = new Vector3(inputData.Direction.x, 0, inputData.Direction.y) * currentSpeed;
                playerData.PlayerView.SetRun(true);
            }
            else
            {
                playerData.Rigidbody.velocity = new Vector3(0, playerData.Rigidbody.velocity.y, 0);
                playerData.PlayerView.SetRun(false);
            }
        }


        public float CalcSpeed(ref PlayerData playerData)
        {
            if (Physics.Raycast(playerData.Transform.position + Vector3.up, playerData.Transform.forward, out RaycastHit hit, playerData.MaxKillDistance))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.GetComponent<EnemyView>())
                    {
                        return playerData.RushSpeed;
                    }
                }
            }

            return playerData.Speed;
        }

        public void Init()
        {
            ref PlayerData playerData = ref game.Player.Get<PlayerData>();
            currentSpeed = playerData.Speed;
        }
    }
}
