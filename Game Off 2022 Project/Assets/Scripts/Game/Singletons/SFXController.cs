using System;
using UnityEngine;

namespace Singletons
{
    public class SFXController : MonoBehaviour
    {
        public static SFXController Instance;
        private static AudioSource defaultAudioSource;
        private AudioSource pickUp;

        [SerializeField] private AudioClip buttonHover, buttonClick;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            AudioSource [] temp = GetComponents<AudioSource>();
            defaultAudioSource = temp[0];

            try //aspoň sem dej podmínku nebo něco tyvole všude mi to teď háže errory, stejně je to celé funky tohle
            {
                pickUp = temp[1];
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.LogWarning(ex.Message);
                pickUp = gameObject.AddComponent<AudioSource>();
            }
        }

        /// <summary>
        /// Plays an sound effect from default audio source
        /// </summary>
        /// <param name="sfx">effect to be played</param>
        public void PlaySoundEffect(AudioClip sfx)
        {
            defaultAudioSource.PlayOneShot(sfx);
        }
        
        /// <summary>
        /// Plays an sound effect from given audio source
        /// </summary>
        /// <param name="sfx">effect to be played</param>
        /// <param name="audioSource">from which audio source</param>
        public void PlaySoundEffect(AudioClip sfx, AudioSource audioSource)
        {
            audioSource.PlayOneShot(sfx);
        }

        /// <summary>
        /// Plays pick up effect
        /// </summary>
        public void PlayPickUp()
        {
            pickUp.Play();
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
