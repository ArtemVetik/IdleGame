using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class JoystickInput : PlayerInput
    {
        [SerializeField] private Joystick _joystick;

        public override Vector2 Direction => _joystick.Direction;
    }
}