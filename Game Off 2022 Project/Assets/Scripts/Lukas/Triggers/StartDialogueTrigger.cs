using System;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Triggers
{
    public class StartDialogueTrigger : TriggerZone, ITriggerZone
    {
        [SerializeField] private Lukas.Story.Dialogue dialogue;
        
        public override void PrivateInteractionEnter()
        {
            dialogue.BeginDialogue();
        }
    }
}