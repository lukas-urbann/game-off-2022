using System;
using Lukas.Player;
using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class PlaySoundInteractable : InteractableObject, IInteractableObject
    {
        public AudioClip sound;
        public bool playOneShot = true;
        
        public override void PrivateInteraction()
        {
            if (playOneShot)
                SFXController.Instance.PlaySoundEffectOneShot(sound);
            else
                SFXController.Instance.PlaySoundEffect(sound);
        }
    }
}