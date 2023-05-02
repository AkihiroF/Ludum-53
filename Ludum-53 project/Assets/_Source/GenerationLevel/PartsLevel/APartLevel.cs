using System;
using _Source.EventSystem;
using UnityEngine;

namespace _Source.GenerationLevel.PartsLevel
{
    public abstract class APartLevel : MonoBehaviour
    {
        [SerializeField] protected Vector2 SizePart;
        [SerializeField] private GameObject prefabPart;
        private float _speed;
        
        private Transform _transformPrefab;
        private bool _isDead;
        protected PoolPartsLevel _poolParts;
        
        public Vector2 GetDistance
        {
            get
            {
                return SizePart;
            }
        }
        public GameObject GetObject
        {
            get
            {
                return prefabPart;
            }
        }
        

        private void FixedUpdate()
        {
            if(_isDead)
                return;
            var position = _transformPrefab.position;
            var nextPos = position - Vector3.right * _speed;
            position = Vector3.Lerp(position,nextPos , Time.deltaTime);
            _transformPrefab.position = position;
        }

        public void SetParameters(PoolPartsLevel pool, float speedMoving)
        {
            _poolParts = pool;
            _speed = speedMoving;
            _transformPrefab = prefabPart.transform;
            Signals.Get<OnPlayAnimationDead>().AddListener(StopMoving);
        }

        private void StopMoving()
        {
            _isDead = true;
        }
        public abstract void Unvisible();

        protected abstract void ReturnToPool();

        private void OnDestroy()
        {
            Signals.Get<OnPlayAnimationDead>().RemoveListener(StopMoving);
        }
    }
}