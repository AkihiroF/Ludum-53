using System;
using UnityEngine;

namespace _Source.GenerationLevel.PartsLevel
{
    public abstract class APartLevel : MonoBehaviour
    {
        [SerializeField] protected Vector2 SizePart;
        [SerializeField] private GameObject prefabPart;
        private float _speed;
        
        private Transform _transformPrefab;
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
            var transform1 = _transformPrefab;
            var nextPos = transform1.position - Vector3.right * _speed;
            transform1.position = Vector3.Lerp(transform1.position,nextPos , Time.deltaTime);
        }

        public void SetParameters(PoolPartsLevel pool, float speedMoving)
        {
            _poolParts = pool;
            _speed = speedMoving;
            _transformPrefab = prefabPart.transform;
        }
        public abstract void PlayerExit();

        protected abstract void ReturnToPool();
    }
}