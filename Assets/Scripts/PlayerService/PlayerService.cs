using Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class PlayerService : IEcsRunSystem, IEcsInitSystem
    {
        private SceneView scene;
        private GameData gameData;
        private Game game;
        public PlayerService(SceneView sceneView, GameData gameData, Game game)
        {
            this.scene = sceneView;
            this.gameData = gameData;
            this.game = game;
        }

        public void Init()
        {
            game.SetPlayer(game.World.NewEntity());
            ref PlayerData playerData = ref game.Player.Get<PlayerData>();
            playerData = new PlayerData(scene.Player, scene.Player.GetStartData());
        }

        public void Run()
        {

        }

    }
}
