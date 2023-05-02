using System;
using _Source.EventSystem;
using UnityEngine;

namespace _Source
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource audio;

        private void Start()
        {
            Signals.Get<OnPaused>().AddListener(PauseMusic);
            Signals.Get<OnDead>().AddListener(PauseMusic);
            Signals.Get<OnResume>().AddListener(ResumeMusic);
            Signals.Get<OnPlayAnimationDead>().AddListener(PauseMusic);
        }

        private void ResumeMusic()
        {
            audio.Play();
        }

        private void PauseMusic()
        {
            audio.Pause();
        }

        private void OnDestroy()
        {
            Signals.Get<OnPaused>().RemoveListener(PauseMusic);
            Signals.Get<OnDead>().RemoveListener(PauseMusic);
            Signals.Get<OnResume>().RemoveListener(ResumeMusic);
            Signals.Get<OnPlayAnimationDead>().RemoveListener(PauseMusic);
        }
    }
}