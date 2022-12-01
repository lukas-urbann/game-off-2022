using System;
using Lukas.Player;
using UnityEngine;

namespace Lukas.Interactable
{
    public class PlayAnimationTrigger : InteractableObject, IInteractableObject
    {
        [SerializeField] private string animationName;
        [SerializeField] private Animator animator;
        
        public override void PrivateInteraction()
        {
            animator.Play(animationName);
        }
    }
}