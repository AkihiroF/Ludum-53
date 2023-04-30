using System;
using System.Collections.Generic;
using _Source.GenerationLevel.PartsLevel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.GenerationLevel
{
    public class PoolPartsLevel
    {
        private Dictionary<Type, List<APartLevel>> _parts;
        private float _speedMovingPart;
        private int _countBaseParts;

        public PoolPartsLevel(float speed, int countBaseParts)
        {
            _parts = new Dictionary<Type, List<APartLevel>>();
            _speedMovingPart = speed;
            _countBaseParts = countBaseParts;
        }

        public APartLevel GetPartLevel(Type type)
        {
            
            try
            {
                if (_parts[type].Count > _countBaseParts)
                {
                    var part =_parts[type][Random.Range(_countBaseParts,_parts[type].Count)];
                    _parts[type].Remove(part);
                    return part;
                }
                var newPart =CreatorPartsLevel.CreatePart(_parts[type][Random.Range(0, _countBaseParts)].GetObject).GetComponent<APartLevel>();
                newPart.SetParameters(this,_speedMovingPart);
                return newPart;
            }
            catch
            {
                return null;
            }
        }

        public void AddToPool(Type type, APartLevel objectPart)
        {
            try
            {
                _parts[type].Add(objectPart);
            }
            catch
            {
                try
                {
                    _parts.Add(type, new List<APartLevel>(){objectPart});
                }
                catch 
                {
                    Debug.Log("Nu ti i debil");
                }
            }
        }
    }
}