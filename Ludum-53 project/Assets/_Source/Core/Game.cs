using _Source.Input;

namespace _Source.Core
{
    public class Game
    {
        public Game(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
        }

        private PlayerInput _input;
        private InputHandler _inputHandler;

        public void StartGame()
        {
            
        }

        private void Bind()
        {
            
        }

        public void ResumeGame()
        {
            
        }

        public void PauseGame()
        {
            
        }

        public void ExitGame()
        {
            
        }
    }
}