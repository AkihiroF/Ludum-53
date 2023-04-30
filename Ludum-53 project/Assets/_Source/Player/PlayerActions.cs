using _Source.GenerationLevel.PartsLevel;
using UnityEngine;

namespace _Source.Player
{
    public class PlayerActions : MonoBehaviour
    {
        [SerializeField] private float powerForce;
        [SerializeField] private LayerMask layerGround;
        private Rigidbody2D _rb;
        private Vector2 _sizePlayer;
         [SerializeField] private LayerMask layerInteractable;

         private void OnCollisionEnter2D(Collision2D other)
         {
             var obj = other.gameObject;
             if ((layerInteractable.value & (1 << obj.layer)) > 0)
             {
                 var part = obj.GetComponent<CheckPartLevel>();
                 part.PlayerEnter();
             }
         }

         private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sizePlayer = GetComponent<CapsuleCollider2D>().size;
        }

        public void Jump()
        {
            if(CheckIsGrounded())
            {
                Debug.Log("Jump");
                _rb.AddForce(Vector2.up * powerForce * 100);
            }
        }

        private bool CheckIsGrounded()
        {
            return Physics2D.OverlapCapsule(transform.position, _sizePlayer, CapsuleDirection2D.Vertical, 0, layerGround);
        }
    }
}