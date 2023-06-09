using _Source.EventSystem;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class UiPreviewer : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [Space]
        
        [SerializeField] private GameObject deadPanel;
        [SerializeField] private Button restartButton;
        [Space] 
        
        [SerializeField] private GameObject pausedPanel;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button toMainMenuButton;
        private void Awake()
        {
            Subscribe();
            BindButton();
            DisablePaused();
            deadPanel.SetActive(false);
        }
        
        
        private void BindButton()
        {
            restartButton.onClick.AddListener((() =>
            {
                UnBindButtons();
                UnSubscribe();
                sceneLoader.LoadGame();
            }));
            resumeButton.onClick.AddListener(() =>
            {
                Signals.Get<OnResume>().Dispatch();
            });
            toMainMenuButton.onClick.AddListener(() =>
            {
                UnBindButtons();
                UnSubscribe();
                sceneLoader.LoadMainMenu();
            });
        }

        private void UnBindButtons()
        {
            restartButton.onClick.RemoveAllListeners();
            resumeButton.onClick.RemoveAllListeners();
            toMainMenuButton.onClick.RemoveAllListeners();
        }

        private void Subscribe()
        {
            Signals.Get<OnPaused>().AddListener(EnablePaused);
            Signals.Get<OnResume>().AddListener(DisablePaused);
            Signals.Get<OnDead>().AddListener(PrintDead);
        }

        private void UnSubscribe()
        {
            Signals.Get<OnPaused>().RemoveListener(EnablePaused);
            Signals.Get<OnResume>().RemoveListener(DisablePaused);
            Signals.Get<OnDead>().RemoveListener(PrintDead);
        }
        
        #region Beatiful

        public void PrintInformationRegion(int idRegion)
        {
            
        }

        #endregion

        #region Dead

        private void PrintDead()
        {
            deadPanel.SetActive(true);
        }

        #endregion

        #region Paused

        private void EnablePaused()
        {
            pausedPanel.SetActive(true);
        }

        private void DisablePaused()
        {
            pausedPanel.SetActive(false);
        }

        #endregion
    }
}