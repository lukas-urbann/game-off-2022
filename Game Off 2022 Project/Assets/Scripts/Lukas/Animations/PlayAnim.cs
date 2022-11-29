using System.Collections;
using System.Collections.Generic;
using Lukas.Interactable;
using Lukas.Triggers;
using UnityEngine;

namespace Lukas.Animations
{
    public class PlayAnim : TriggerZone, ITriggerZone
    {
        public string animName;
        public Animator anim;
        public bool independent;

        public void PlaySelectedAnimationIndependent()
        {
            PlaySelectedAnimation();
        }
        
        public override void PrivateInteractionEnter()
        {
            if(!independent)
                PlaySelectedAnimation();
        }

        private void PlaySelectedAnimation()
        {
            if (anim == null && GetComponent<Animator>() != null)
                anim = GetComponent<Animator>();
            
            if(anim != null)
                anim.Play(animName);
        }
    }
}
