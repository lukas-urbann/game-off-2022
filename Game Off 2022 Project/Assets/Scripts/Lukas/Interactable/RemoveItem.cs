using System;
using System.Collections;
using Lukas.Objective;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class RemoveItem : InteractableObject, IInteractableObject
    {
        [SerializeField] private string itemName;
        private bool didRemoveItem = false;
        public string itemNotFound = "";
        
        public override void PrivateInteraction()
        {
            if (Inventory.Instance.CheckItem(itemName))
            {
                Inventory.Instance.RemoveItem(itemName);

                if (GetComponent<EnableObject>() != null)
                {
                    EnableObject obj = GetComponent<EnableObject>();
                    obj.EnableForceCall();
                    obj.Interact();
                    //kms
                }
                
                if (GetComponent<PlayAnimInteractable>() != null)
                {
                    PlayAnimInteractable obj = GetComponent<PlayAnimInteractable>();
                    obj.PlaySelectedAnimation();
                    //kms
                }
                    
                Destroy(GetComponent<RemoveItem>());
            }
            else
            {
                if (itemNotFound.Equals("self-type"))
                    itemNotFound = "You need to have [" + itemName + "] to be able to interact!";
                
                Mission.Instance.UpdateMission(itemNotFound, 3);
            }
        }
    }
}