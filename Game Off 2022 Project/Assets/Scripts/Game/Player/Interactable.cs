using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.name.Equals("Baterkos") && PlayerPrefs.GetInt("Baterkos", 0) == 1) 
        {
            Debug.Log("Player already has a flashlight. Destroying flashlight gameobject...\nIf you wish to reset player progress, use the PlayerPrefs button, located at the top of the sreen");
            Destroy(gameObject);
        }
        else if (gameObject.name.Equals("Radios") && PlayerPrefs.GetInt("Radios", 0) == 1)
        {
            Debug.Log("Player already has a radio. Destroying radio gameobject...\nIf you wish to reset player progress, use the PlayerPrefs button, located at the top of the sreen");
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        if (gameObject.name.Equals("Baterkos")) //actual gameobject
        {
            GameObject.Find("Player flashlight").GetComponent<Flashlight>().PickUp();  //lightsource on player
            Destroy(gameObject);
        }
        else if (gameObject.name.Equals("Radios"))  //actual gameobject
        {
            GameObject.Find("Player radio").GetComponent<Radio>().PickUp();  //radio on player
            Destroy(gameObject);
        }
        else if (gameObject.name.Equals("doorWing"))
        {
            gameObject.GetComponent<Door>().Rotate();
        }
        else if (gameObject.name.Contains("_interactable"))
        {
            PlayerPrefs.SetInt(gameObject.name, 1);
        }
        else
        {
            Debug.LogError("Trying to interact with non-interactable object");
        }
    }
}
