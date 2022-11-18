using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        if (gameObject.name.Equals("Baterkos")) //actual gameobject
        {
            GameObject.Find("Flashlight").GetComponent<Flashlight>().PickUp();  //lightsource on player
            Destroy(gameObject);
        }
        else if (gameObject.name.Equals("Radios"))
        {
            //gameObject.GetComponent<Radio>().PickUp();
        } 
        else
        {
            Debug.LogError("není implementované LOL");
        }
    }
}
