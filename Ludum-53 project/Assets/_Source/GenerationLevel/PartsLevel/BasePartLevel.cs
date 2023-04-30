using System.Collections.Generic;
using UnityEngine;

namespace _Source.GenerationLevel.PartsLevel
{
    public class BasePartLevel : APartLevel
    {
        [SerializeField] private List<GameObject> foodsInPart;

        public int GetCountFood
        {
            get
            {
                return foodsInPart.Count;
            }
        }
        public override void PlayerExit()
        {
            foreach (var food in foodsInPart)
            {
                food.SetActive(true);
            }
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(BasePartLevel), this);
        }
    }
}