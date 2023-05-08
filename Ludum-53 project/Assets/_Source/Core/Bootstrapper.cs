using System.Collections.Generic;
using _Source.Input;
using _Source.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerActions player;
        [SerializeField] private List<GameObject> backgrounds;
        [SerializeField] private Transform pointForBackGround;
        private void Awake()
        {
            var input = new PlayerInput();
            var inputHandler = new InputHandler(player);
            var game = new Game(input, inputHandler);
            game.StartGame();
            ChangeBackground();
        }

        private void ChangeBackground()
        {
            var id = Random.Range(0, backgrounds.Count);
            Instantiate(backgrounds[id], pointForBackGround.position, Quaternion.identity);
        }
    }
}
