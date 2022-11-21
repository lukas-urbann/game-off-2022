using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Input system")]
    [SerializeField] private InputSystemFirstPersonControls inputActions;

    [Header("Variables")]
    private bool hasFlashlight = false;
    [SerializeField] private Light baterkos;
    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        inputActions = GameObject.Find("Player").GetComponent<PlayerController>().InputActions;

        if (PlayerPrefs.GetInt("Baterkos", 0) == 1)
        {
            hasFlashlight = true;
        }

        if (baterkos == null)
        {
            baterkos = GetComponent<Light>();
            Debug.LogWarning("baterkos is not referenced");
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            Debug.LogWarning("audioSource is not referenced");
        }

        if (PlayerPrefs.GetInt("Sviti baterkos", -1) == -1)
        {
            baterkos.enabled = false;
        }
        else
        {
            baterkos.enabled = true;
        }
    }

    private void Update()
    {
        if (hasFlashlight && inputActions.FPSController.Flashlight.WasPressedThisFrame())   //switching the flashlight on/off
        {
            audioSource.Play();
            baterkos.enabled = !baterkos.isActiveAndEnabled;
            PlayerPrefs.SetInt("Sviti baterkos", PlayerPrefs.GetInt("Sviti baterkos", -1) * -1);
        }
    }

    public void PickUp()
    {
        hasFlashlight = true;
        PlayerPrefs.SetInt("Baterkos", 1);
    }
}
