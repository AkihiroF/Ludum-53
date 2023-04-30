using System.Collections.Generic;
using _Source.EventSystem;
using _Source.GenerationLevel.PartsLevel;
using UnityEngine;

namespace _Source.GenerationLevel
{
    public class GeneratorLvl : MonoBehaviour
    {
        [SerializeField] private List<APartLevel> partsLvl;
        [SerializeField] private APartLevel checkPointObject;
        [SerializeField] private int startLenght;

        [SerializeField] private float speedMoving;

        private int _currentLenghtLevel;
        private PoolPartsLevel _pool;
        private Vector2 _positionSpawn;
        private APartLevel _lastPart;

        private void Start()
        {
            _pool = new PoolPartsLevel(speedMoving, partsLvl.Count);
            foreach (var part in partsLvl)
            {
                _pool.AddToPool(typeof(BasePartLevel), part);
            }
            _pool.AddToPool(typeof(CheckPartLevel), checkPointObject);
            GenerateStartLocation();
            Signals.Get<FinishCheck>().AddListener(GenerateNewLevel);
        }

        private void GenerateStartLocation()
        {
            for (int i = 0; i < startLenght; i++)
            {
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
            }

            var checkPart = _pool.GetPartLevel(typeof(CheckPartLevel));
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            _currentLenghtLevel = startLenght;
            IncreaseRandomly();
            GenerateNewLevel();
        }

        private void GenerateNewLevel()
        {
            _positionSpawn = _lastPart.transform.position;
            for (int i = 0; i < _currentLenghtLevel; i++)
            {
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
            }
            var checkPart = _pool.GetPartLevel(typeof(CheckPartLevel));
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            IncreaseRandomly();
        }
        private void IncreaseRandomly()
        {
            _currentLenghtLevel += Random.Range(2, 10);
        }

    }
}