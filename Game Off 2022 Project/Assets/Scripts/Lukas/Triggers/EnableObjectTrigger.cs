using UnityEngine;

namespace Lukas.Triggers
{
    public class EnableObjectTrigger : TriggerZone, ITriggerZone
    {
        public GameObject objectToEnable;

        public override void PrivateInteractionEnter()
        {
            objectToEnable.SetActive(true);
        }
    }
}