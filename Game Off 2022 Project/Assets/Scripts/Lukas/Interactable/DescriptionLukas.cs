using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class DescriptionLukas : InteractableObject, IInteractableObject
    {
        [SerializeField] protected string itemDescription = "";

        public string SetItemDescription()
        {
            return itemDescription;
        }
    }
}
