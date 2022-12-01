using UnityEngine;
using Lukas.Story;

namespace Lukas.Triggers
{
    public class StartDialogueTrigger : TriggerZone, ITriggerZone
    {
        [SerializeField] private Dialogue dialogue;
        [HideInInspector] public bool pomoc = false;
        
        public override void PrivateInteractionEnter()
        {
            dialogue.BeginDialogue();
            pomoc = true;
        }
    }
}