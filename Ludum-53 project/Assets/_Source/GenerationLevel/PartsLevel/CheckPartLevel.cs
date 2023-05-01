using _Source.EventSystem;
using UnityEngine;

namespace _Source.GenerationLevel.PartsLevel
{
    public class CheckPartLevel : APartLevel
    {
        [SerializeField] private LayerMask layerPlayer;
        private bool _isGenerated = false;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if ((layerPlayer.value & (1 << obj.layer)) > 0)
            {
                PlayerEnter();
            }
        }
        private void PlayerEnter()
        {
            if(_isGenerated)
                return;
            Signals.Get<OnGenerateNextLevel>().Dispatch();
            _isGenerated = true;
        }
        public override void Unvisible()
        {
            ReturnToPool();
            _isGenerated = false;
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(CheckPartLevel), this);
        }
    }
}