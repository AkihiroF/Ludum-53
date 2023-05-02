using _Source.EventSystem;
using _Source.Input;
using UnityEngine;

namespace _Source.Core
{
    public class Game
    {
        public Game(PlayerInput input, InputHandler inputHandler)
        {
            _input = input;
            _inputHandler = inputHandler;
            Bind();
            Subscribe();
        }

        private PlayerInput _input;
        private InputHandler _inputHandler;

        public void StartGame()
        {
            EnableInput();
            ResumeGame();
        }

        private void Bind()
        {
            var inp = _input.Player;
            inp.Jump.performed += _inputHandler.ActionJump;
            inp.Pause.performed += _inputHandler.ActionPause;
        }

        private void UnBind()
        {
            var inp = _input.Player;
            inp.Jump.performed -= _inputHandler.ActionJump;
            inp.Pause.performed -= _inputHandler.ActionPause;
        }


        #region Actions

        private void ResumeGame()
        {
            EnablePlayerInput();
            Time.timeScale = 1f;
        }

        private void PauseGame()
        {
            DisablePlayerInput();
            Time.timeScale = 0f;
        }

        private void ExitGame()
        {
            UnBind();
            UnSubscribe();
        }

        #endregion

        private void Subscribe()
        {
            Signals.Get<OnPaused>().AddListener(PauseGame);
            Signals.Get<OnResume>().AddListener(ResumeGame);
            Signals.Get<OnDead>().AddListener(PauseGame);
            Signals.Get<OnDead>().AddListener(DisableInput);
        }
        
        private void UnSubscribe()
        {
            Signals.Get<OnPaused>().RemoveListener(PauseGame);
            Signals.Get<OnResume>().RemoveListener(ResumeGame);
            Signals.Get<OnDead>().RemoveListener(PauseGame);
            Signals.Get<OnDead>().RemoveListener(DisableInput);
        }
        private void EnableInput() 
            => _input.Player.Enable();

        private void EnablePlayerInput() => _input.Player.Jump.Enable();
        private void DisablePlayerInput() => _input.Player.Jump.Disable();

        private void DisableInput()
            => _input.Player.Disable();

        
    }
}