using UnityEngine;
using cakeslice;
using Scenes;
using UnityEngine.SceneManagement;
using Singletons;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    private void Awake()
    {
        if (name.Contains("_interactable") && PlayerPrefs.GetInt(name, 0) == 1)
        {
            Debug.Log("Player already has a" + name + ". Destroying radio gameobject...\nIf you wish to reset player progress, use the PlayerPrefs button, located at the top of the sreen");
            Destroy(gameObject);
        }

        if (name.Equals("Baterkos") && PlayerPrefs.GetInt("Baterkos", 0) == 1) 
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
        if (name.Equals("Baterkos")) //actual gameobject
        {
            GameObject.Find("Player flashlight").GetComponent<Flashlight>().PickUp();  //lightsource on player
            Destroy(gameObject);
        }
        else if (name.Equals("Radios"))  //actual gameobject
        {
            GameObject.Find("Player radio").GetComponent<Radio>().PickUp();  //radio on player
            Destroy(gameObject);
        }
        else if (gameObject.name.Equals("doorWing") || (gameObject.CompareTag("Object") && gameObject.layer.Equals(8)))
        {
            gameObject.GetComponent<Door>().Rotate();
        }
        else if (name.Equals("Padlock"))
        {
            GameObject.Find("Padlock UI").GetComponent<Padlock>().StartPadlock();
        }
        else if (name.Equals("teleport"))
        {
            LoadingScreen.Instance.StartLoading(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (name.Contains("_interactable"))
        {
            PlayerPrefs.SetInt(gameObject.name, 1); //"picking up" a object
            SFXController.Instance.PlayPickUp();
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Trying to interact with non-interactable object");
        }
    }
}
