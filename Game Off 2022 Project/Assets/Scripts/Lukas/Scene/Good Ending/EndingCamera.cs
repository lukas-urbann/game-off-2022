using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Scene.GoodEnding
{
    public class EndingCamera : MonoBehaviour
    {
        public AudioClip say;
        
        public void PlaySay()
        {
            SFXController.Instance.PlaySoundEffectOneShot(say);
        }
        
    }
}
