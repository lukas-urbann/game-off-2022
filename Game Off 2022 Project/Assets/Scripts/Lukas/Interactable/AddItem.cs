using System;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class AddItem : InteractableObject, IInteractableObject
    {
        [SerializeField] private string itemName;
        
        public override void PrivateInteraction()
        {
            Inventory.Instance.AddItem(itemName);
        }
    }
}