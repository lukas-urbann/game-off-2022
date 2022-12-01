using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class EnableObject : InteractableObject, IInteractableObject
    {
        [SerializeField] private bool disableObject = false;
        [SerializeField] private bool disableAfterInteraction = false;
        public GameObject objectToEnable;
        private bool forceCall;

        public void EnableForceCall()
        {
            //Dont question, workaround
            forceCall = true;
        }
        
        public override void PrivateInteraction()
        {
            if (GetComponent<RemoveItem>() != null ^ forceCall)
                return;
            
            if(objectToEnable != null)
                objectToEnable.SetActive(!disableObject);
            
            if(disableAfterInteraction)
                Destroy(GetComponent<EnableObject>());
                
            /*
            
            //Additional check - if it for whatever reason doesn't disable the object
            if(objectToEnable.activeSelf && disableObject)
                Destroy(objectToEnable);
            
            gameObject.SetActive(false);
            */
        }
    }
}
