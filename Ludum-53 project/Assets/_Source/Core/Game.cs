using _Source.Input;

namespace _Source.Core
{
    public class Game
    {
        public Game(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
            Bind();
        }

        private PlayerInput _input;
        private InputHandler _inputHandler;

        public void StartGame()
        {
            EnableInput();
        }

        private void Bind()
        {
            var inp = _input.Player;
            inp.Jump.performed += _inputHandler.ActionJump;
            inp.RollingDown.performed += _inputHandler.ActionRolling;
        }

        private void UnBind()
        {
            var inp = _input.Player;
            inp.Jump.performed -= _inputHandler.ActionJump;
            inp.RollingDown.performed -= _inputHandler.ActionRolling;
        }

        private void EnableInput() 
            => _input.Player.Enable();

        private void DisableInput()
            => _input.Player.Disable();

        public void ResumeGame()
        {
            EnableInput();
        }

        public void PauseGame()
        {
            DisableInput();
        }

        public void ExitGame()
        {
            UnBind();
        }
    }
}