using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;

namespace Lukas.Triggers
{
    public class EnterNextScene : TriggerZone, ITriggerZone
    {
        [SerializeField] private string sceneName = "";
        
        public override void PrivateInteractionEnter()
        {
            LoadingScreen.Instance.StartLoading(sceneName);
        }
    }
}

