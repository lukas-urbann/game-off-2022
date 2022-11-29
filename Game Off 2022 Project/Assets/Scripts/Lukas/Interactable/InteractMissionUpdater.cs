using System;
using Lukas.Objective;
using Lukas.Player;
using Lukas.Triggers;
using UnityEngine;

namespace Lukas.Interactable
{
    public class InteractMissionUpdater : InteractableObject, IInteractableObject
    {
        public bool disableOnInteract = false;
        public string missionText = "";
        
        public override void PrivateInteraction()
        {
            Mission.Instance.UpdateMission(missionText, 3);

            if (disableOnInteract)
                Destroy(GetComponent<InteractMissionUpdater>());
        }
    }
}