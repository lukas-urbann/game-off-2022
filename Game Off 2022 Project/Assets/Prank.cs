using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prank : MonoBehaviour
{
    [SerializeField] GameObject[] turnOn;
    [SerializeField] GameObject[] turnOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject g in turnOn)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in turnOff)
            {
                g.SetActive(false);
            }
        }
    }
}
