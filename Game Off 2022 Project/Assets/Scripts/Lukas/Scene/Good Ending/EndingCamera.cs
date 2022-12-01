using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Scene.GoodEnding
{
    public class EndingCamera : MonoBehaviour
    {
        public AudioClip say, metalPipe;
        
        public void PlaySay()
        {
            SFXController.Instance.PlaySoundEffectOneShot(say);
        }
        
        public void PlayMetalPipe()
        {
            SFXController.Instance.PlaySoundEffectOneShot(metalPipe);
        }
        
    }
}
