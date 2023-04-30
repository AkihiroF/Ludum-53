using UnityEngine;

namespace _Source
{
    public class ObstacleComponent : MonoBehaviour
    {
        [SerializeField] private int countMinus;

        public int GetPrice
        {
            get
            {
                return countMinus;
            }
        }
    }
}