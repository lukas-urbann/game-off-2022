using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    [RequireComponent(typeof(cakeslice.Outline))]
    [RequireComponent(typeof(Collider))]
    public class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected string ItemDescription;

        private void Start()
        {
            if (ItemDescription.Equals("null") && GetComponent<Description>())
                ItemDescription = GetComponent<Description>().description;
        }

        public void Interact()
        {
            PrivateInteraction();
        }

        public string GetItemDescription()
        {
            return ItemDescription;
        }
        
        public virtual void PrivateInteraction() {}
    }

    public interface IInteractableObject
    {
        public void PrivateInteraction();
    }
}
