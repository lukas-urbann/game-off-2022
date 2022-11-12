using System.Collections;
using System.Collections.Generic;
using Game.Utility;
using UnityEngine;
using Random = UnityEngine.Random;
using Singletons;

namespace Lighting
{
    public class LightFlash : MonoBehaviour
    {
        public AudioClip flashSound;
        public float minTimer, maxTimer;
        public float flashIntensity;
        private float flashTimer;
        private List<int> litUp;
        [SerializeField] private List<Light> lights = new List<Light>();

        private void Start()
        {
            StartCoroutine(RefreshTimer());
            
            litUp = new List<int>(new int[lights.Count]);
        }

        private IEnumerator RefreshTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minTimer, maxTimer));
                FlashLights();
            }
        }

        private void FlashLights()
        {
            PlayFlashSound();
            
            foreach (Light light in lights)
            {
                if (litUp[lights.IndexOf(light)] == 0)
                {
                    light.intensity += flashIntensity;
                    litUp[lights.IndexOf(light)] = 1;
                }
                else
                {
                    light.intensity -= flashIntensity;
                    litUp[lights.IndexOf(light)] = 0;
                }
            }
        }

        private void PlayFlashSound()
        {
            if (BooleanChecker.CheckSFXController())
                SFXController.Instance.PlaySoundEffect(flashSound);
        }
    }
}
