using System;
using _Source.EventSystem;
using _Source.Score;
using UnityEngine;

namespace _Source.Player
{
    public class CollectorFood : MonoBehaviour
    {
        [SerializeField] private LayerMask layerFood;
        [SerializeField] private LayerMask layerObstacle;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if ((layerFood.value & (1 << obj.layer)) > 0)
            {
                _currentCountFood++;
                obj.SetActive(false);
            }

            if ((layerObstacle.value & (1 << obj.layer)) > 0)
            {
                var minus = obj.GetComponent<ObstacleComponent>().GetPrice;
                if (minus >= _currentCountFood)
                {
                    Signals.Get<OnPlayAnimationDead>().Dispatch();
                }
                else
                    _currentCountFood -= minus;
            }
            UpdateUI();
        }

        private void OnDestroy()
        {
            Signals.Get<OnUpdateTargetScore>().RemoveListener(UpdateTarget);
        }
    }
}