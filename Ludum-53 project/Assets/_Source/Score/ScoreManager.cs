using System;
using System.Collections.Generic;
using _Source.EventSystem;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public const string DataName = "Data";
        [SerializeField] private Image infoFoodObject;
        [SerializeField] private TextMeshProUGUI textFood;
        [Space]
        
        [SerializeField] private TextMeshProUGUI textInformation;
        [SerializeField] private Image backgroundInformation;

        [SerializeField] private float timeShutDown;
        [SerializeField] private float timeShutUp;
        [SerializeField] private float timeVisible;
        
        private Sequence _animationInfo;

        private int _currentStage;
        private SavedScore _saved;

        private void Start()
        {
            CreateData();
            Signals.Get<OnGetFood>().AddListener(UpdateTextFood);
            Signals.Get<OnGenerateNextLevel>().AddListener(PrintInformation);
            Signals.Get<OnDead>().AddListener(SaveInformation);
            textInformation.DOFade(0, 0);
            backgroundInformation.DOFade(0, 0);
            infoFoodObject.DOFade(0, 0);
            textFood.DOFade(0, 0);
        }

        private void CreateData()
        {
            if (PlayerPrefs.HasKey(DataName))
            {
                _saved = JsonUtility.FromJson<SavedScore>(PlayerPrefs.GetString(DataName));
            }
            else
            {
                _saved = new SavedScore();
            }
        }
        private void CreateAnimation()
        {
            _animationInfo = DOTween.Sequence();
            _animationInfo.Append(infoFoodObject.DOFade(0, timeShutDown));
            _animationInfo.Join(textFood.DOFade(0, timeShutDown));
            _animationInfo.Append(textInformation.DOFade(1,timeShutUp));
            _animationInfo.Join(backgroundInformation.DOFade(1, timeShutUp));

            _animationInfo.AppendInterval(timeVisible);
            
            _animationInfo.Append(infoFoodObject.DOFade(1, timeShutUp));
            _animationInfo.Join(textFood.DOFade(1, timeShutUp));
            _animationInfo.Append(textInformation.DOFade(0,timeShutDown));
            _animationInfo.Join(backgroundInformation.DOFade(0, timeShutDown));
            
        }

        private void PrintInformation()
        {
            CreateAnimation();
            _currentStage++;
            textInformation.text = $"Order number {_currentStage}";
            _animationInfo.Play();
        }

        private void UpdateTextFood(string score)
        {
            textFood.text = score;
        }

        private void SaveInformation()
        {
            if(_currentStage == 1)
                return;
            if(_saved.bestScore >= _currentStage)
                return;
            _saved.bestScore = _currentStage-1;
            string data = JsonUtility.ToJson(_saved);
            PlayerPrefs.SetString(DataName, data);
            PlayerPrefs.Save();
        }

        private void OnDestroy()
        {
            Signals.Get<OnGetFood>().RemoveListener(UpdateTextFood);
            Signals.Get<OnGenerateNextLevel>().RemoveListener(PrintInformation);
            Signals.Get<OnDead>().RemoveListener(SaveInformation);
        }
    }

    [Serializable]
    public class SavedScore
    {
        public int bestScore;
    }
}