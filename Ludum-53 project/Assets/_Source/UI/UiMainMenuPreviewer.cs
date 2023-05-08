using _Source.Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class UiMainMenuPreviewer : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private Button startGameButton;
        [SerializeField] private GameObject resultObject;
        [SerializeField] private TextMeshProUGUI resultText;

        private void Awake()
        {
            BindButtons();
            ActivateResults();
        }

        private void ActivateResults()
        {
            if (PlayerPrefs.HasKey(ScoreManager.DataName))
            {
                var bestScore = JsonUtility.FromJson<SavedScore>(PlayerPrefs.GetString(ScoreManager.DataName))
                    .bestScore;
                resultText.text = $"Best score = {bestScore}";
            }
            else
            {
                resultObject.SetActive(false);
            }
        }
        private void BindButtons()
        {
            startGameButton.onClick.AddListener(() => sceneLoader.LoadGame());
        }
        
        
    }
}