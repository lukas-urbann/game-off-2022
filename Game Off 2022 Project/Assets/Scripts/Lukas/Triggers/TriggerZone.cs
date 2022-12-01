using UnityEngine;

namespace Lukas.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private bool deleteAfterCollision;
        [SerializeField] private bool forceDeleteAfterCollision = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {                                   
                PrivateInteractionEnter();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                PrivateInteractionExit();
            }
            
            if(deleteAfterCollision)
            {
                //gameObject.SetActive(false); 
                GetComponent<Collider>().enabled = false;
            }
            
            if(forceDeleteAfterCollision)
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

