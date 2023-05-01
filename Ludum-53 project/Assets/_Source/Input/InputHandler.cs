using _Source.EventSystem;
using _Source.Player;
using UnityEngine.InputSystem;

namespace _Source.Input
{
    public class InputHandler
    {
        private PlayerActions _player;
        private bool _isPaused = false;

        public InputHandler(PlayerActions player)
        {
            _player = player;
        }

        public void ActionJump(InputAction.CallbackContext obj)
        {
            _player.Jump();
        }

        public void ActionPause(InputAction.CallbackContext obj)
        {
            if (_isPaused)
            {
                Signals.Get<OnResume>().Dispatch();
                _isPaused = false;
            }
            else
            {
                _isPaused = true;
                Signals.Get<OnPaused>().Dispatch();
            }
        }
    }
}