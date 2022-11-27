using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class EnableObject : InteractableObject, IInteractableObject
    {
        [SerializeField] private bool disableObject = false;
        public GameObject objectToEnable;

        public override void PrivateInteraction()
        {
            if(objectToEnable != null)
                objectToEnable.SetActive(!disableObject);
        }
    }
}
