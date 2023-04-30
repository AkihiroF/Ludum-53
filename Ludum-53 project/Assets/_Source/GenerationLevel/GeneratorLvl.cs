using System.Collections.Generic;
using _Source.EventSystem;
using _Source.GenerationLevel.PartsLevel;
using UnityEngine;

namespace _Source.GenerationLevel
{
    public class GeneratorLvl : MonoBehaviour
    {
        [SerializeField] private List<APartLevel> partsLvl;
        [SerializeField] private APartLevel emptyPointObject;
        [SerializeField] private APartLevel checkPointObject;
        [SerializeField] private int startLenght;
        [SerializeField] private int countAdditionalParts;

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
            _pool.AddToPool(typeof(EmptyPartLvl), emptyPointObject);
            GenerateStartLocation();
            Signals.Get<OnGenerateNextLevel>().AddListener(GenerateNewLevel);
        }

        private void GenerateStartLocation()
        {
            for (int i = 0; i < startLenght; i++)
            {
                var part = _pool.GetPartLevel(typeof(EmptyPartLvl));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
            }
            var checkPart = _pool.GetPartLevel(typeof(CheckPartLevel));
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            GenerateEmptyParts();
            _currentLenghtLevel = startLenght + 1;
            IncreaseRandomly();
        }

        private void GenerateNewLevel()
        {
            var countFoodInLvl = 0;
            _positionSpawn = _lastPart.transform.position;
            for (int i = 0; i < _currentLenghtLevel; i++)
            {
                var part = _pool.GetPartLevel(typeof(BasePartLevel));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
                var currentPart = (BasePartLevel)part;
                countFoodInLvl += currentPart.GetCountFood;
            }
            var checkPart = _pool.GetPartLevel(typeof(CheckPartLevel));
            checkPart.transform.position = _positionSpawn;
            _lastPart = checkPart;
            GenerateEmptyParts();
            Signals.Get<OnUpdateTargetScore>().Dispatch(countFoodInLvl);
            IncreaseRandomly();
        }

        private void GenerateEmptyParts()
        {
            _positionSpawn = (Vector2)_lastPart.transform.position + _lastPart.GetDistance/2 + emptyPointObject.GetDistance/2;
            for (int i = 0; i < countAdditionalParts; i++)
            {
                var part = _pool.GetPartLevel(typeof(EmptyPartLvl));
                part.transform.position = _positionSpawn;
                _positionSpawn += part.GetDistance;
                if (i == countAdditionalParts - 1)
                {
                    _lastPart = part;
                }
            }
        }
        private void IncreaseRandomly()
        {
            _currentLenghtLevel += Random.Range(2, 10);
        }

    }
}