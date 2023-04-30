using _Source.Player;
using UnityEngine.InputSystem;

namespace _Source.Input
{
    public class InputHandler
    {
        private PlayerActions _player;

        public InputHandler(PlayerActions player)
        {
            _player = player;
        }

        public void ActionJump(InputAction.CallbackContext obj)
        {
            _player.Jump();
        }

        public void ActionRolling(InputAction.CallbackContext obj)
        {
            _player.RollingDown();
        }
    }
}