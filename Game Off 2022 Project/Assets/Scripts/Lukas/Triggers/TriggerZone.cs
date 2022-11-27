using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private bool deleteAfterCollision;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
                PrivateInteractionEnter();
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
                PrivateInteractionExit();
            
            if(deleteAfterCollision)
                gameObject.SetActive(false);
        }
        
        public virtual void PrivateInteractionEnter() {}
        public virtual void PrivateInteractionExit() {}
    }
    
    public interface ITriggerZone
    {
        void PrivateInteractionExit();
        void PrivateInteractionEnter();
    }
}

