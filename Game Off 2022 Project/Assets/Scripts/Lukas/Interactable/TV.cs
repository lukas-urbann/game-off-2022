using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class TV : InteractableObject, IInteractableObject
    {
        public GameObject screen;
        
        public override void PrivateInteraction()
        {
            screen.SetActive(!screen.activeSelf);
        }
    }
}
