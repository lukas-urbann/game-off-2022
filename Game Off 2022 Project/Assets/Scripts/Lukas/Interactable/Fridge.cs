using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class Fridge : InteractableObject, IInteractableObject
    {
        public AudioClip notHungry;
        
        public override void PrivateInteraction()
        {
            SFXController.Instance.PlaySoundEffectOneShot(notHungry);
        }
    }
}

