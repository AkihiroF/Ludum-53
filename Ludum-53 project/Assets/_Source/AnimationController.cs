using System;
using _Source.EventSystem;
using UnityEngine;

namespace _Source
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private int _idJump;
        private int _idDead;
        void Start()
        {
            _animator = GetComponent<Animator>();
            _idJump = Animator.StringToHash("isJump");
            _idDead = Animator.StringToHash("isDead");
            Signals.Get<OnPlayAnimationDead>().AddListener(PlayDeath);
        }

        public void PlayJump()
        {
            _animator.SetTrigger(_idJump);
        }

        public void PlayDeath()
        {
            _animator.SetBool(_idDead,true);
        }

        private void OnDestroy()
        {
            Signals.Get<OnPlayAnimationDead>().RemoveListener(PlayDeath);
        }
    }
}
