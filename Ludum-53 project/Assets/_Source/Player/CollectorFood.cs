using System;
using _Source.EventSystem;
using _Source.Score;
using UnityEngine;

namespace _Source.Player
{
    public class CollectorFood : MonoBehaviour
    {
        [SerializeField] private LayerMask layerFood;
        private int _currentCountFood;
        private int _currentTargetFood;

        private void Start()
        {
            Signals.Get<OnUpdateTargetScore>().AddListener(UpdateTarget);
            UpdateUI();
        }

        private void UpdateTarget(int count)
        {
            _currentTargetFood = count;
            _currentCountFood = 0;
            UpdateUI();
        }

        private void UpdateUI()
        {
            var info = $"Food {_currentCountFood} / {_currentTargetFood}";
            Signals.Get<OnGetFood>().Dispatch(info);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((layerFood.value & (1 << other.gameObject.layer)) > 0)
            {
                _currentCountFood++;
                other.gameObject.SetActive(false);
                UpdateUI();
            }
        }
    }
}