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
        }
        public abstract void Unvisible();

        protected abstract void ReturnToPool();
    }
}