using _Source.GenerationLevel.PartsLevel;
using UnityEngine;

namespace _Source.GenerationLevel
{
    public class FinishLevel : MonoBehaviour
    { 
        [SerializeField] private LayerMask layerInteractable;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerInteractable.value & (1 << other.gameObject.layer)) > 0)
            {
                var part = other.GetComponent<APartLevel>();
                part.Unvisible();
            }
        }
    }
}