using System;
using _Source.EventSystem;
using TMPro;
using UnityEngine;

namespace _Source.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textScore;
        [SerializeField] private TextMeshProUGUI textFood;

        private void Start()
        {
            Signals.Get<OnGetFood>().AddListener(UpdateTextFood);
        }

        private void UpdateTextFood(string score)
        {
            textFood.text = score;
        }
    }
}