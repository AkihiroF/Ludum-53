using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class UiMainMenuPreviewer : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button showResultButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            startGameButton.onClick.AddListener(() => sceneLoader.LoadGame());
            //showResultButton.onClick.AddListener(() => sceneLoader.LoadNewGame());
            quitButton.onClick.AddListener(() => sceneLoader.QuitGame());
        }
        
        
    }
}