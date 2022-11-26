using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    [RequireComponent(typeof(cakeslice.Outline))]
    public class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected string ItemDescription;
        
        public void Interact()
        {
            PrivateInteraction();
        }

        public string GetItemDescription()
        {
            return ItemDescription;
        }
        
        protected virtual void PrivateInteraction() {}
    }

    public interface IInteractableObject
    {
        
    }
}
