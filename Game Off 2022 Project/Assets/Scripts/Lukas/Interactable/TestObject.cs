using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Interactable
{
    public class TestObject : InteractableObject, IInteractableObject
    {
        public override void PrivateInteraction()
        {
            Debug.Log("Test");
        }
    }
}
