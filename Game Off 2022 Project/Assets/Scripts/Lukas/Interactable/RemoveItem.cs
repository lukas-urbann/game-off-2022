using System;
using System.Collections;
using System.Linq;
using Lukas.Objective;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class RemoveItem : InteractableObject, IInteractableObject
    {
        [SerializeField] private string[] itemName;
        private bool didRemoveItem = false;
        public string itemNotFound = "";
        
        public override void PrivateInteraction()
        {
            //Pojebanej kanon potrebuje 2 itemy...
            var itemNameList = itemName.ToList();
            int index = 0;
            
            foreach (string item in itemName)
            {
                if (Inventory.Instance.CheckItem(item))
                {
                    Inventory.Instance.RemoveItem(item);

                    if(item == itemNameList[index])
                        itemNameList.RemoveAt(index);

                    
                }
                else
                {
                    string missingItems = "";
                    
                    for (int i = 0; i < itemName.Length; i++)
                    {
                        missingItems += " [" + itemName[i] + "]";
                    }
                    
                    if (itemNotFound.Equals("self-type"))
                        itemNotFound = "You need to have" + missingItems + " to be able to interact!";
                
                    Mission.Instance.UpdateMission(itemNotFound, 3);
                }
                index++;
                
                if (itemName.Length == 0 || itemName == null)
                {
                    if (GetComponent<EnableObject>() != null)
                    {
                        EnableObject obj = GetComponent<EnableObject>();
                        obj.EnableForceCall();
                        obj.Interact();
                        //kms
                    }
                        
                    Destroy(GetComponent<RemoveItem>());
                }
            }

            itemName = itemNameList.ToArray();
        }
    }
}