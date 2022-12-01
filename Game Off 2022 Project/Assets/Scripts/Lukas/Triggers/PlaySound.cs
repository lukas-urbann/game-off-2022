using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Triggers
{
    public class PlaySound : TriggerZone, ITriggerZone
    {
        [SerializeField] private bool PlayOneShot = true;
        public AudioClip clip;

        public override void PrivateInteractionEnter()
        {
            if(PlayOneShot)
                SFXController.Instance.PlaySoundEffectOneShot(clip);
            else
                SFXController.Instance.PlaySoundEffect(clip);
        }
    }
}
