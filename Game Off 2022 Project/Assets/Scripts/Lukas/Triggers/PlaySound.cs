using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Triggers
{
    public class PlaySound : TriggerZone, ITriggerZone
    {
        public AudioClip clip;
        
        public override void PrivateInteractionEnter()
        {
            SFXController.Instance.PlaySoundEffect(clip);
        }
    }
}
