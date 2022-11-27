using UnityEngine;

namespace Lukas.Triggers
{
    public class EnableObject : TriggerZone, ITriggerZone
    {
        public GameObject objectToEnable;

        public override void PrivateInteractionEnter()
        {
            objectToEnable.SetActive(true);
        }
    }
}