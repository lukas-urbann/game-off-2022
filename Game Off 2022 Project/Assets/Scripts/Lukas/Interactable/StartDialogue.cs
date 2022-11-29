using System;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class StartDialogue : InteractableObject, IInteractableObject
    {
        [SerializeField] private Lukas.Story.Dialogue dialogue;
        
        public override void PrivateInteraction()
        {
            dialogue.BeginDialogue();
        }
    }
}