using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singletons
{
    public class SFXController : MonoBehaviour
    {
        public static SFXController Instance;
        private static AudioSource defaultAudioSource;

        public AudioClip buttonHover, buttonClick;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            defaultAudioSource = GetComponent<AudioSource>();
        }

        public void PlaySoundEffect(AudioClip sfx)
        {
            defaultAudioSource.PlayOneShot(sfx);
        }
        
        public void PlaySoundEffect(AudioClip sfx, AudioSource audioSource)
        {
            audioSource.PlayOneShot(sfx);
        }

        public void Button_PlayHover()
        {
            defaultAudioSource.PlayOneShot(buttonHover);
        }

        public void Button_PlayClick()
        {
            defaultAudioSource.PlayOneShot(buttonClick);
        }
    }
}
