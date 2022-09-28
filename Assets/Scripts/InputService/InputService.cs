using Leopotam.Ecs;

namespace Input
{
    public class InputService : IEcsInitSystem
    {
        private SceneView sceneView;
        private Game game;

        public InputService(SceneView sceneView, Game game)
        {
            this.sceneView = sceneView;
            this.game = game;
        }

        public void Init()
        { 
            ref  InputData input = ref game.Player.Get<InputData>();
            input = new InputData(sceneView.uiData.Joystick);
        }
    }
}
