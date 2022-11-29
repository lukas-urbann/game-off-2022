using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;

namespace Lukas.Interactable
{
    public class EnterNextSceneInteractable : InteractableObject, IInteractableObject
    {
        public string nameScene = "";
        
        public override void PrivateInteraction()
        {
            LoadingScreen.Instance.StartLoading(nameScene);
        }
    }
}

