using System;
using Lukas.Objective;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class RemoveItem : InteractableObject, IInteractableObject
    {
        [SerializeField] private string itemName;
        public string itemNotFound = "";
        
        public override void PrivateInteraction()
        {
            if(Inventory.Instance.CheckItem(itemName))
                Inventory.Instance.RemoveItem(itemName);
            else
            {
                if (itemName.Equals("self-type"))
                    itemName = "You need to have " + itemName + " to be able to interact!";
                
                Mission.Instance.UpdateMission(itemNotFound, 2);
            }
        }
    }
}