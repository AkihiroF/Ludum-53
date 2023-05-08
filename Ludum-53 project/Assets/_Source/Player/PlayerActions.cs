using _Source.EventSystem;
using UnityEngine;

namespace _Source.Player
{
    public class PlayerActions : MonoBehaviour
    {
        [SerializeField] private AnimationController animationController;
        [SerializeField] private float powerForce;
        [SerializeField] private LayerMask layerGround;
        private Rigidbody2D _rb;
        private Vector2 _sizePlayer;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sizePlayer = GetComponent<CapsuleCollider2D>().size;
        }

        public void Jump()
        {
            if(CheckIsGrounded())
            {
                animationController.PlayJump();
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * powerForce * 100);
            }
        }

        private bool CheckIsGrounded()
        {
            // return Physics2D.OverlapCapsule(transform.position, _sizePlayer,
            //     CapsuleDirection2D.Vertical, 0, layerGround);
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down,
                _sizePlayer.x + 0.2f, layerGround);
            return ray.collider;
        }
        
        public void Dead()
        {
            Signals.Get<OnDead>().Dispatch();
        }
    }
}