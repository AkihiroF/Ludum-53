using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source
{
    public class SceneLoader:MonoBehaviour
    {
        [SerializeField] private int idMainMenu;
        [SerializeField] private int idGame;

        public void LoadNewGame()
        {
            SceneManager.LoadScene(idGame);
        }
        public void LoadGame()
        {
            SceneManager.LoadScene(idGame);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(idMainMenu);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}