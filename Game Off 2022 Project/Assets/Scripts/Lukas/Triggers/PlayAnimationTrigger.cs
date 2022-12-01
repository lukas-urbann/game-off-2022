using System;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Triggers
{
    public class PlayAnimationTrigger : TriggerZone, ITriggerZone
    {
        [SerializeField] private string animationName;
        [SerializeField] private Animator animator;
        
        public override void PrivateInteractionEnter()
        {
            animator.Play(animationName);
        }
    }
}