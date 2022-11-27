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
        private bool OverrideLegacy = true;
        protected string ItemDescription = "null";

        private void Start()
        {
            if (ItemDescription.Equals("null") && GetComponent<global::Description>() != null)
                ItemDescription = GetComponent<global::Description>().description;

            if (GetComponent<global::Interactable>() != null)
                OverrideLegacy = false;
            
            if (GetComponent<Lukas.Interactable.DescriptionLukas>() != null)
                ItemDescription = GetComponent<Lukas.Interactable.DescriptionLukas>().SetItemDescription();

            if (ItemDescription.Equals("null"))
                ItemDescription = "";
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
        
        public bool ReturnOverrideLegacy()
        {
            return OverrideLegacy;
        }
    }

    public interface IInteractableObject
    {
        public void PrivateInteraction();
    }
}
