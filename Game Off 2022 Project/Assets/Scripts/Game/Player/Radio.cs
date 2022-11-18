using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [Header("Input system")]
    [SerializeField] private InputSystemFirstPersonControls inputActions;

    [Header("Variables")]
    private bool hasRadio = false;
    private AudioSource audioSource;


    private void Start()
    {
        inputActions = GameObject.Find("Player").GetComponent<PlayerController>().InputActions;
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Radios", 0) == 1)
        {
            hasRadio = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (hasRadio && inputActions.FPSController.Radio.WasPressedThisFrame())
        {
            PlayRadio();
        }
    }

    /// <summary>
    /// Plays a voiceline from radio
    /// </summary>
    public void PlayRadio()
    {
        audioSource.Play();
    }

    public void PickUp()
    {
        hasRadio = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        PlayerPrefs.SetInt("Radios", 1);
    }
}
