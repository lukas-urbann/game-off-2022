using System.Collections;
using System.Collections.Generic;
using Lukas.Interactable;
using UnityEngine;

public class Meth : InteractableObject
{
    public GameObject stareOkno, noveOkno;
    
    public override void PrivateInteraction()
    {
        //stareOkno.SetActive(false);
        noveOkno.SetActive(true);
        
        gameObject.SetActive(false);
    }
}
