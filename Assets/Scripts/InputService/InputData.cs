using UnityEngine;

namespace Input
{
    public struct InputData
    {
        private Joystick joystick;

        public Vector2 Direction => joystick.Direction;
        public bool IsCanControll => UnityEngine.Input.GetKey(KeyCode.Mouse0);
    
        public InputData(Joystick joystick)
        {
            this.joystick = joystick;
        }

    }
}