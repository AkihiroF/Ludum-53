using System;
using _Source.Input;
using _Source.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerActions player;
        private void Awake()
        {
            var input = new PlayerInput();
            var inputHandler = new InputHandler(player);
            var game = new Game(input, inputHandler);
            
            game.StartGame();
        }
    }
}
