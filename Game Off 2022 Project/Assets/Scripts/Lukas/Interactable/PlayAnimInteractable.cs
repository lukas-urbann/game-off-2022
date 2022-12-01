using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class PlayAnimInteractable : InteractableObject, IInteractableObject
    {
        public string animName;
        public Animator anim;
        public bool requireItems;
        
        public override void PrivateInteraction()
        {
            if(requireItems)
                if (GetComponent<RemoveItem>() != null)
                    return;
            
            Debug.Log("asdasdasdsad");
            
            PlaySelectedAnimation();
            
            Destroy(GetComponent<PlayAnimInteractable>());
        }
        
        public void PlaySelectedAnimation()
        {
            if (anim == null && GetComponent<Animator>() != null)
                anim = GetComponent<Animator>();
            
            if(anim != null)
                anim.Play(animName);
        }
    }
}
