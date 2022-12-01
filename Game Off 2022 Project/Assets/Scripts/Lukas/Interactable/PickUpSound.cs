using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class PickUpSound : InteractableObject, IInteractableObject
    {
        public override void PrivateInteraction()
        {
            SFXController.Instance.Interactable_PlayPickUp();
        }
    }
}