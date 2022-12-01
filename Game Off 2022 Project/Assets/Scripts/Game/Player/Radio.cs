using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [Header("Input system")]
    [SerializeField] private InputSystemFirstPersonControls inputActions;

    [Header("Variables")]
    private bool hasRadio = false;
    private AudioSource radioSource;
    private AudioSource click;


    private void Start()
    {
        inputActions = GameObject.Find("Player").GetComponent<PlayerController>().InputActions;

        AudioSource[] temp = GetComponents<AudioSource>();
        radioSource = temp[0];
        click = temp[1];


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
        click.Play();
        if (radioSource.isPlaying)  //TODO tohle je jen doèasné, potom tady bude nìjaké logika rádia
        {                      
            radioSource.Stop();
        }                   
        else
        {       
            radioSource.Play();
        }
    }


    /// <summary>
    /// Events that happen upon picking up the radio by the player
    /// </summary>
    public void PickUp()
    {
        hasRadio = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        PlayerPrefs.SetInt("Radios", 1);
    }
}
