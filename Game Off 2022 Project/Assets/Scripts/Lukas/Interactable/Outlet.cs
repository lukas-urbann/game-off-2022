using Lukas.Interactable;
using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class Outlet : InteractableObject, IInteractableObject
    {
        public AudioClip ouch;
        
        public override void PrivateInteraction()
        {
            SFXController.Instance.PlaySoundEffect(ouch);
        }
    }
}
