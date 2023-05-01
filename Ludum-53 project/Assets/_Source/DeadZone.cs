using _Source.EventSystem;
using UnityEngine;

namespace _Source
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private LayerMask layerPlayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((layerPlayer.value & (1 << other.gameObject.layer)) > 0)
            {
                Signals.Get<OnDead>().Dispatch();
            }
        }
    }
}