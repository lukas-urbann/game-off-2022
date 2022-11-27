using System.Collections;
using System.Collections.Generic;
using Lukas.Objective;
using UnityEngine;

namespace Lukas.Triggers
{
    public class UpdateMission : TriggerZone, ITriggerZone
    {
        public string missionText = "";
        public float missionDisplayTime = 1;
        
        public override void PrivateInteractionEnter()
        {
            Mission.Instance.UpdateMission(missionText, missionDisplayTime);
        }
    }
}
