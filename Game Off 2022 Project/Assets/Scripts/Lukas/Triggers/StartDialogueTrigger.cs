using UnityEngine;

namespace Lukas.Triggers
{
    public class StartDialogueTrigger : TriggerZone, ITriggerZone
    {
        [SerializeField] private Story.Dialogue dialogue;
        
        public override void PrivateInteractionEnter()
        {
            dialogue.BeginDialogue();
        }
    }
}