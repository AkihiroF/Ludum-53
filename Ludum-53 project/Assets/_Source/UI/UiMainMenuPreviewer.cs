using UnityEngine;
using UnityEngine.UI;

namespace _Source
{
    public class UiMainMenuPreviewer : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private Button loadGameButton;
        [SerializeField] private Button startNewGameButton;
        [SerializeField] private Button quitButton;

        private bool _isLoad;

        private void Awake()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            loadGameButton.onClick.AddListener(() => sceneLoader.LoadGame());
            startNewGameButton.onClick.AddListener(() => sceneLoader.LoadNewGame());
            quitButton.onClick.AddListener(() => sceneLoader.QuitGame());
        }
        
        
    }
}